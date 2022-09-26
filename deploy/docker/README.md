## Docker

- [Заметки](Test/notes.txt)
- [Скриншоты](ScreenShots.docx)

### Docker Compose

Создаем 2 образа и из них запускаем 2 контейнера [yml](docker-compose.yml)
- Nginx с показом статической странички   [tst-app](tst_app/Dockerfile)
- Очень простое .Net приложение [net-app](net_app/Dockerfile)

docker-compose build

docker-compose up
