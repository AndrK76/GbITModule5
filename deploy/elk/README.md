# ELK

### Так как в методичке используется ingreы для kibana - не имея своего домена вместо ingres использую LoadBalancer [kibana.svc](kibana.svc)


## Попытка развернуть по методичке

[elasticsearch-ss.yaml](try1/elasticsearch-ss.yaml)
[elasticsearch.svc](try1/elasticsearch.svc)
[kibana.yaml](try1/kibana.yaml)
[kibana.svc](try1/kibana.svc)

```
cd try01
kubectl apply -f elasticsearch-ss.yaml

kubectl apply -f elasticsearch.svc

kubectl apply -f kibana.yaml

kubectl apply -f kibana.svc
```

![screenshot 01](screenshots/01.png)

смотрю сервисы и поды

```
kubectl get services

kubectl get pods
```
и вижу что что-то пошло не так

![screenshot 02](screenshots/02.png)

анализирую файлы
смутило 2 места
>    value: http://elasticsearch:9200 
в [kibana.yaml](try1/kibana.yaml)


>    clusterIP: None
в [elasticsearch.svc](try1/elasticsearch.svc)
 
 
## Попытка 2 

удаляю 

```
kubectl delete -f kibana.svc

kubectl delete -f kibana.yaml

kubectl delete -f elasticsearch.svc

kubectl delete -f elasticsearch-ss.yaml

cd ..
```
изменяю

[elasticsearch-ss.yaml](try2/elasticsearch-ss.yaml)
[elasticsearch.svc](try2/elasticsearch.svc)


запускаю elasticsearch и смотрю адрес сервиса

```
cd try2
kubectl apply -f elasticsearch-ss.yaml

kubectl apply -f elasticsearch.svc

kubectl get services
```

![screenshot 03](screenshots/03.png)

правлю [kibana.yaml](try2/kibana.yaml) и запускаю дальше 

```
kubectl apply -f kibana.yaml

kubectl apply -f kibana.svc

kubectl get services
```

![screenshot 04](screenshots/04.png)

тоже не работает, смотрю поды
```
kubectl get pods
```
![screenshot 05](screenshots/05.png)

и видно что pod с elasticsearch не стартовал нормально

пробую его пробросить

```
kubectl port-forward es-cluster-0 9200:9200 --address='0.0.0.0'
```
разумеется не получается

![screenshot 06](screenshots/06.png)


## Попытка 3

[интернет](https://www.digitalocean.com/community/tutorials/how-to-set-up-an-elasticsearch-fluentd-and-kibana-efk-logging-stack-on-kubernetes-ru)

[kube-logging.yaml](try3/kube-logging.yaml)
[elasticsearch_svc.yaml](try3/elasticsearch_svc.yaml)

```
cd try3
kubectl get namespaces
kubectl create -f kube-logging.yaml
kubectl create -f elasticsearch_svc.yaml
get services -n kube-logging
```
![screenshot 07](screenshots/07.png)

[elasticsearch_statefulset.yaml](try3/elasticsearch_statefulset.yaml)

```
kubectl create -f elasticsearch_statefulset.yaml
kubectl get pods -n kube-logging
kubectl rollout status sts/es-cluster --namespace=kube-logging
```

![screenshot 08](screenshots/08.png)

И тут меня осенило. Дело было не в бобине.

![screenshot 09](screenshots/09.png)

сменил тип диска

```
kubectl create -f elasticsearch_statefulset.yaml
```
![screenshot 10](screenshots/10.png)

и пошла другая ошибка

![screenshot 11](screenshots/11.png)
