# Монторинг + попытка разобраться с Docker в Yandex k8s

## Пересоздание кластера

```
$FOLDER_ID = yc config get folder-id

yc iam service-account create --name k8s-res-sa-$FOLDER_ID

$RES_SA_ID = (yc iam service-account get --name k8s-res-sa-$FOLDER_ID --format json | ConvertFrom-Json).id

yc resource-manager folder add-access-binding `
  --id $FOLDER_ID `
  --role editor `
  --subject serviceAccount:$RES_SA_ID

yc iam service-account create --name k8s-node-sa-$FOLDER_ID

$NODE_SA_ID = (yc iam service-account get --name k8s-node-sa-$FOLDER_ID --format json | ConvertFrom-Json).id

yc resource-manager folder add-access-binding ```
  --id $FOLDER_ID `
  --role container-registry.images.puller `
  --subject serviceAccount:$NODE_SA_ID

yc resource-manager folder add-access-binding ```
  --id $FOLDER_ID `
  --role container-registry.images.pusher `
  --subject serviceAccount:$NODE_SA_ID


yc vpc network create --name yc-auto-network

yc vpc subnet create `
  --name yc-auto-subnet-0 `
  --network-name yc-auto-network `
  --range 10.2.0.0/16 `
  --zone ru-central1-a


yc managed-kubernetes cluster create `
  --name k8s-demo --network-name yc-auto-network `
  --zone ru-central1-a --subnet-name yc-auto-subnet-0 `
  --public-ip `
  --service-account-id $RES_SA_ID `
  --node-service-account-id $NODE_SA_ID


yc managed-kubernetes node-group create `
  --name k8s-demo-ng `
  --cluster-name k8s-demo `
  --platform standard-v3 `
  --public-ip `
  --cores 2 `
  --memory 4 `
  --core-fraction 50 `
  --disk-type network-hdd `
  --fixed-size 2 `
  --location subnet-name=yc-auto-subnet-0,zone=ru-central1-a `
  --async
```  

в итоге ошибка
ERROR: rpc error: code = InvalidArgument desc = Validation error:
allocation_policy.locations[0].subnet_id: can't use "allocation_policy.locations[0].subnet_id" together with "node_template.network_interface_specs"

несколько раз поигрался с сетью - в итоге решил через web-интерфейс создать [node-group.txt ](node-group.txt)


## Регистр

```
yc container registry create --name yc-auto-cr

$REGISTRY_ID = (yc container registry get --name yc-auto-cr --format json | ConvertFrom-Json).id

yc container registry configure-docker

cd net_app
docker build . -t cr.yandex/$REGISTRY_ID/net-app:0.1.0
cd ..
docker images

docker push cr.yandex/${REGISTRY_ID}/net-app:0.1.0

yc managed-kubernetes cluster get-credentials --external --name k8s-demo


kubectl run net-app --image cr.yandex/${REGISTRY_ID}/net-app:0.1.0
kubectl get po
kubectl logs net-app

kubectl delete pod net-app

kubectl apply -f net-app.yaml

kubectl expose deployment net-app-test --name my-test --type=LoadBalancer

kubectl get services  my-test

kubectl delete services  my-test
kubectl delete -f net-app.yaml

```