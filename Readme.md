# Задание
Стэк - .net, ef, mysql, angular, maui (бывший xamarin), общаются между собой по odata. Все пакеты последних версий.

Надо написать todo лист с базовым функционалом - добавить список задач, удалить список задач, добавить задачу в список, пометить задачу выполненной. 

Внешний вид - material, или какой-то похожий ui-kit.

# Todo Api
Api сервис для общения с клиентом по протоколу odata.

Соберите в docker контейнер, задеплойте на сервер с переменной окружения TODO_CONNECTION, которая должна содержать строку подключения к mysql.

# Todo Client
Клиент для нашего сервиса. 
В файле TodoRepo.cs отредактируйте константу URI, которая должна содержать ссылку на ранее поднятый сервис Todo Api.

# Скриншоты
## Windows
![изображение](https://user-images.githubusercontent.com/64736191/233188909-9c879ca1-be39-473b-b817-18c742d696b7.png)

![изображение](https://user-images.githubusercontent.com/64736191/233188978-e41eaec1-bd57-462d-955b-2c48d5b48f33.png)

![изображение](https://user-images.githubusercontent.com/64736191/233188998-4a98ff58-3c63-41d2-b236-233a2e7bc9ea.png)

## Android
![изображение](https://user-images.githubusercontent.com/64736191/233189040-a580bf74-c09f-4546-9735-2a190e5ce38d.png)

![изображение](https://user-images.githubusercontent.com/64736191/233189060-01faa079-12eb-4209-b80b-81ee9993ad20.png)

![изображение](https://user-images.githubusercontent.com/64736191/233189071-1ad1b6c3-f571-444f-bfe7-77ee7340b1e2.png)

