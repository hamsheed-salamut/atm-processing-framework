# ATM - Microservice Application

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

> ##Note:
> Project still under development

## Introduction
This is a .Net Core sample application and an example of how to build and implement a microservices based back-end system for a simple automated banking feature like Balance, Deposit, Withdraw in ASP.NET Core Web API with C#.Net, Entity Framework and SQL Server. 

## Application Architecture

The sample application is build based on the microservices architecture. There are serveral advantages in building a application using Microservices architecture like Services can be developed, deployed and scaled independently.The below diagram shows the high level design of Back-end architecture.

- **Identity Microservice** - Authenticates user based on username, password and issues a JWT Bearer token which contains Claims-based identity information in it.
- **Transaction Microservice** - Handles account transactions like Get balance, deposit, withdraw
- **API Gateway** - Acts as a center point of entry to the back-end application, Provides data aggregation and communication path to microservices.

![Application Architecture](https://8dmbiq.dm.files.1drv.com/y4mKz6TDtiwhrfo2mdUgvzle36Bnj7PMCvY6fP6kixwU3c3_CMb_rnnYOxg9WKn8LMmc5F__p2w3NWJc0o1vmCFmhHd5hRbr0S4MnMFnx09qvdSHE_E_40H0pQOxE0om2T2czVDOAInkTXn4xgdx_FmRgo8OaBh2XYqFHTf2zmYmF71tqRqlLzlsYBo1x1_CvdCt8U6AbjMhYznbgeBkGUKPQ?width=625&height=243&cropmode=none)

## Design of Microservice
This diagram shows the internal design of the Transaction Microservice. The business logic and data logic related to transaction service is written in a seperate transaction processing framework. The framework receives input via Web Api and process those requests based on some simple rules. The transaction data is stored up in SQL database.

![Microservice design](https://8dk2lg.dm.files.1drv.com/y4md899yaH9aFP7Z1qhi_kCicZwQMYJWDA4SAdihporow8okXYUFcl-lp-2Awv5ldmlGmOEqwrxv3je-XaQqM7fnZZLzJKFzv7WDrC7Hyd2QLLglJfjNhWaFiCRJXzaXjghqK8y1XZJUuHAJiVdfl3_90NuPyNV-zsb5UOKBpRBbeFx3LpI0gPivXhIRBtFq6ZdInV5ub8r5U-Ibw9Zb-0YzQ?width=631&height=617&cropmode=none)


## Security : JWT Token based Authentication
JWT Token based authentication is implementated to secure the WebApi services. **Identity Microservice** acts as a Auth server and issues a valid token after validating the user credentitals. The API Gateway sends the token to the client. The client app uses the token for the subsequent request.

![JWT Token based Security](https://h9yrga.dm.files.1drv.com/y4mCbiAcoeieS5tBZu_z1z1z42C8eoVGWUmC_re1VkLWpxWtywvsOBH73brVXA4gzKm6G59h3b3vbUVF1C3jbYRlpf-7t-faZE4m8-wYplZusss5Fm-71AH87c1aXlKoULtFoUNl5Oh9h6nZDDfgLXeo_LKOH8Q0b4BGVTpg1w7TcCZQPkX5tBZtSiQj67JGqsg4lySz2ghzB9R9ArGtaA7wA?width=702&height=422&cropmode=none)

## Development Environment

- [.Net Core 3.1 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio .Net 2019](https://visualstudio.microsoft.com/downloads/)
- [SQL Server Management Studio 17.9.1](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017)

## Technologies
- C#.NET
- ASP.NET WEB API Core
- SQL Server

## Opensource Tools Used
- Automapper (For object-to-object mapping)
- Entity Framework Core (For Data Access)
- Swashbucke (For API Documentation)
- XUnit (For Unit test case)
- Ocelot (For API Gateway Aggregation)
