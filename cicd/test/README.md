# CI/CD

Тема незнакома, поэтому просто попробовал по [Ссылка](https://mahedee.net/configure-ci-cd-pipeline-with-jenkins-github-and-asp.net-core/) повторить.
Решил попробовать связать разработку простейшего ASP .Net Core приложения с Jenkins

Установил

![screenshot 01](screenshots/01.png)

![screenshot 02](screenshots/02.png)


Создал тестовый проект (оригинал с небольшими правками), запустил

![screenshot 03](screenshots/03.png)

На всякий случай проверил из VS публикацию, потом удалил файлы

Настраиваю Jenkins

Создал [pipeline](pipeline.json) 

![screenshot 04](screenshots/04.png)

![screenshot 05](screenshots/05.png)

![screenshot 06](screenshots/06.png)

Правлю, запускаю

![screenshot 07](screenshots/07.png)

Результат ожидаемый, так как нет тесты ещё не закомичены и не запушены,
выполняю

