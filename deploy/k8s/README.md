# k8s

### [ScreenShots](ScreenShots.docx)

- [Пример 1](nginx-deployment.yaml)
- [Пример 2](load-balancer-example.yaml) 


### Notes example 2

kubectl apply -f load-balancer-example.yaml
kubectl get deployments hello-world
kubectl describe deployments hello-world
kubectl get replicasets
kubectl describe replicasets

kubectl expose deployment hello-world --type=LoadBalancer --name=my-service
kubectl get services my-service
kubectl describe services my-service

kubectl delete services my-service
kubectl delete deployment hello-world