# ELK

### Так как в методичке используется ingreы для kibana - не имея своего домена вместо ingres использую LoadBalancer [kibana.svc](kibana.svc)


## Попытка развернуть по методичке

[elasticsearch-ss.yaml](try01/elasticsearch-ss.yaml)
[elasticsearch.svc](try01/elasticsearch.svc)
[kibana.yaml](try01/kibana.yaml)
[kibana.svc](try01/kibana.svc)

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
в [kibana.yaml](try01/kibana.yaml)

и
>    clusterIP: None
в [elasticsearch.svc](try01/elasticsearch.svc)
 