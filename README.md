# Circles Web API

#### _A Web API for the Circles app - August 23, 2019_

#### _By **Na Hyung Choi, Kelar Crisp, Erik Irgens, and Emerson Jordan**_

## Description

This is the local database version of the Web API used by the Circles app (https://circlesapp.azurewebsites.net). For full schema, please refer to the Swagger documentation (installation instructions below). 

#### Related GitHub Repositories

* Circles MVC app (local database version): https://github.com/erik-t-irgens/CIRCLES_MVC
* Circles MVC app (Azure hosted version): https://github.com/ejordan1/CirclesMVCAzure
* Circles Web API (Azure hosted version): https://github.com/ejordan1/CirclesApiAzure

## Setup/Installation Requirements

1. Clone this repository:
    ```
    $ git clone https://github.com/schoinh/circles-api.git
    ```
2. Navigate to the project directory (Circles-API). Restore dependencies, update the local database, and run the API:
    ```
    $ dotnet restore
    $ dotnet ef database update
    $ dotnet run
    ```
7. The API is now up and running. For full schema, navigate to the Swagger documentation at http://localhost:5001.

## Known Bugs
None at this time.

## Technologies Used
* C# / .NET Core
* ASP.NET Core MVC
* LINQ
* Microsoft Azure
* OpenAPI aka Swagger

## Support and contact details

_Please comment below if you have feedback._

### License

*GNU GPLv3*

Copyright (c) 2019 **_Na Hyung Choi, Kelar Crisp, Erik Irgens, and Emerson Jordan_**
