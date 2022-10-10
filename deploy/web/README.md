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
docker run -it -h ngx --name web-main -p 80:80 -p 8080:8080 -p 8081:8081 --net net_99 --ip 192.168.99.11 -v d:\git5\GbITModule5\deploy\web\u\web-test:/u01 web-test
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


## Тесты

### 0. Проверка работы
![ScreenShot1-01](ScreenShots/Screenshot1-01.png)
Копия конфига /etc/nginx/sites-enabled/test.conf -> [/u01/conf/test_0.conf](u/web-test/conf/test_0.conf)

### 1. Динамическая перезагрузка конфигурации
```
nginx -s  reload
```
![ScreenShot2-01](ScreenShots/Screenshot2-01.png)

Копия конфига /etc/nginx/sites-enabled/test.conf -> [/u01/conf/test_1.conf](u/web-test/conf/test_1.conf)

### 2. Добавление location
![ScreenShot2-11](ScreenShots/Screenshot2-11.png)
![ScreenShot2-12](ScreenShots/Screenshot2-12.png)
![ScreenShot2-13](ScreenShots/Screenshot2-13.png)

Копия конфига /etc/nginx/sites-enabled/test.conf -> [/u01/conf/test_2.conf](u/web-test/conf/test_2.conf)

### 3. Proxy
![ScreenShot3-01](ScreenShots/Screenshot3-01.png)
![ScreenShot3-02](ScreenShots/Screenshot3-02.png)
![ScreenShot3-03](ScreenShots/Screenshot3-03.png)
![ScreenShot3-04](ScreenShots/Screenshot3-04.png)
![ScreenShot3-05](ScreenShots/Screenshot3-05.png)

Копия конфига /etc/nginx/sites-enabled/test.conf -> [/u01/conf/test_3.conf](u/web-test/conf/test_3.conf)

### 4. Proxy (вариант)
данные с основного сервера 

![ScreenShot4-01](ScreenShots/Screenshot4-01.png)
![ScreenShot4-02](ScreenShots/Screenshot4-02.png)

данные со второго

![ScreenShot4-03](ScreenShots/Screenshot4-03.png)
![ScreenShot4-04](ScreenShots/Screenshot4-04.png)

Логи

![ScreenShot4-05](ScreenShots/Screenshot4-05.png)

Копия конфига /etc/nginx/sites-enabled/test.conf -> [/u01/conf/test_4.conf](u/web-test/conf/test_4.conf)

#### Каталог [/u01](u/web-test)
