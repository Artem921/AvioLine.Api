# Test site using our own and third-party APIs
# To use the full functionality of the application, log in with your details
## Login: admin Password: Aa1.
## Used the API:[AccuWeather](https://developer.accuweather.com/),[ExchangeRate-API](https://www.exchangerate-api.com/)

## This project has its own implementation of the IUserStore interface, which is defined in the namespace at Microsoft.AspNetCore.Identity.
## All responsibility for authorization and registration of users rests with the project AvioLine.Api.

## Description of projects
### AvioLine main - project.
### AvioLine.Api -  interacts with the database.
### AvioLine.Clients - sends requests toAvioLine.Api
### AvioLine.Dal - Database
### AvioLine.Domain - entities

# Application architecture
<img src="https://github.com/Artem921/AvioLine.Api/blob/master/AvioLine/wwwroot/Images/arhi.png" />

