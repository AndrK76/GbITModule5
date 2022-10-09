# Конфигурирование NGINX

## Подготовка стенда
Для тестов создаю образ [Dockerfile](web-image/Dockerfile)

```
cd web-image
docker build -t web-test .
``` 
![ScreenShot01](ScreenShots/Screenshot01.png)

```
docker images
``` 
![ScreenShot02](ScreenShots/Screenshot02.png)

создаем сеть
```
docker network create --driver=bridge --subnet=192.168.99.0/24 net_99
docker network ls -f name=net_99
```
![ScreenShot03](ScreenShots/Screenshot03.png)


Создаем контейнер, проверяем, выходим, стартуем
```
docker run -it -h ngx --name web-main -p 80:80 --net net_99 --ip 192.168.99.11 -v d:\git5\GbITModule5\deploy\web\u\web-test:/u01 web-test
ifconfig
ps -ef
which nginx
ls -l /u01
выход
docker start web-main
docker ps
```
![ScreenShot04](ScreenShots/Screenshot04.png)

Подключаемся, переносим файлы из /tmp, настраиваем хранение логов каталоги в /u01
```
docker exec -it web-main bash
mc
...
```
![ScreenShot05](ScreenShots/Screenshot05.png)

Далее все конфиги в каталоге [/u01/conf](u/web-test/conf)

основной конфиг nginx скопирован в [/u01/conf/nginx.conf](u/web-test/conf/nginx.conf)
```
nginx -t
nginx
ps -ef
```
![ScreenShot06](ScreenShots/Screenshot06.png)



