# Тестирование Service Discovery

## Отчеты

[Скриншоты](screenshots.docx)
[docker-compose.yml](docker-compose.yml)  - consul_1.4.4_linux_amd64.zip копировал локально в context:



## Стенд

Пробовал на Docker под Windows 10  (Версия 21H2)

# Вопросы:
Не получилось пробросить сеть

Что пробовал:

по [notes.txt](notes.txt)  настроил свичи в hyper-v

вначале пробовал с сетью bridge в докер (прописывал 172.20.0.1/16 на всех адаптерах), не рутится с винды

потом сделал сеть ipvlan, parent: eth0, посмотрел на какой свич hyper-v этот eth0 маршрутизируется и прописал на этом адаптере винды 172.20.0.1/16 - не помогло

потом просто вернул сеть в бридж и сделал скриншоты

Сетевые конфиги на момент ipvlan в [config1](config1)
    


