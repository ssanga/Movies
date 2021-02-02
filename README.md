[![Actions Status](https://github.com/ssanga/Movies/workflows/Movies%20CI/CD/badge.svg)](https://github.com/ssanga/Movies/actions)
[![Coverage Status](https://coveralls.io/repos/github/ssanga/Movies/badge.svg?branch=master)](https://coveralls.io/github/ssanga/Movies?branch=master)

# Movies
A sample project with a Rest API and a Blazor app to test several components



The Movies Rest API is deployed here:
https://movies-rest-api.azurewebsites.net

The Movies Server Blazor application is deployed here:
https://movies-server.azurewebsites.net/

External components and libraries used:

- https://github.com/Blazored/Modal
- https://github.com/Blazored/Toast
- https://github.com/egil/bUnit

Code Coverage in https://coveralls.io/github/ssanga/Movies

Code Analysis in https://sonarcloud.io/dashboard?id=ssanga_Movies



## Links of interest
Steps to deploy the app in Azure:
https://docs.microsoft.com/es-es/azure/app-service/deploy-github-actions?tabs=applevel

Coveralls.io and .net core code coverage
https://stackoverflow.com/questions/53255065/dotnet-unit-test-with-coverlet-how-to-get-coverage-for-entire-solution-and-not

Sonar
https://www.blogdoft.com.br/2020/09/19/validando-codigo-com-github-actions-e-sonarcloud/

## Database
https://stackoverflow.com/questions/56214782/how-to-create-a-new-database-user-with-limited-privileges-for-azure-sql
https://azure.microsoft.com/es-es/blog/adding-users-to-your-sql-azure-database/
https://stackoverflow.com/questions/6058058/creating-new-user-login-in-sql-azure
http://kitsula.com/Article/How-to-create-custom-user-login-for-Azure-SQL-Database

use master;
go
CREATE LOGIN movieslogin WITH password='1231!#ASDF!a';

use AzureTest
Go
CREATE USER movieslogin FROM LOGIN movieslogin;
EXEC sp_addrolemember 'db_datareader', 'movieslogin';