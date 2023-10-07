# <p align="center">Rent a Car</p>
Rent a Car is a car rental solution. This project includes an enterprise-grade solution for building RESTful services using ASP.NET WebAPI and C#.
## Contents
- [Getting Started](#getting-started)
  * [Installation](#installation)
  * [Usage](#usage)
- [Tech Stack](#tech-stack)
- [Associated Project](#associated-project)
- [Contributions](#contributions)

## Getting Started

### Installation

1. Clone the repo:

   ```sh
   git clone https://github.com/yusufsafaa/RentACar.git
   ```
2. Open the `ReCapProject.sln` file with `Visual Studio`
3. Open the `CarRentalContext.cs` file in the `DataAccess.Concrete.EntityFramework` folder and enter your own database connection string
4. Open `Package Manager Console` and run the following commands:

   ```sh
   cd DataAccess
   dotnet ef database update
   ```
   `NOTE:` Requires `dotnet ef` installation. Command for installation:
   ```sh
   dotnet tool install --global dotnet-ef
   ```
   
5. Right click on the `WebAPI` project (layer) from the `Solution Explorer` and select `Set as Startup Project` 
6. Start the project with `IIS Express` in Visual Studio. Web API is ready and running!

### Usage
 
After running the Web API, you can make HTTP requests like:
   
   ```sh
   https://localhost:7291/api/`CONTROLLER_NAME`/`METHOD_NAME`
   ```
 
   `CONTROLLER_NAME` => Each .cs file located in the `WebAPI.Controllers` folder (For example CONTROLLER_NAME for `CarsController`: cars )
   <br><br>
   `METHOD_NAME` => All of the methods in each .cs file in the `WebAPI.Controllers` folder
 
#### Sample HTTP GET requests:

1. List all vehicles:
   ```sh
   https://localhost:44372/api/cars/getall
   ```
2. List a brand by id:
   ```sh
   https://localhost:44372/api/cars/getdetailbycarid?carId=1
   ```
3. List all vehicle colors:
   ```sh
   https://localhost:44372/api/colors/getall
   ```

## Tech Stack
| Technology / Library | Version |
| ------------- | ------------- |
| .NET | 7.0 |
| Autofac | 7.0.1 |
| Autofac.Extensions.DependencyInjection | 8.0.0 |
| Autofac.Extras.DynamicProxy | 7.1.0 |
| FluentValidation | 11.6.0 |
| Microsoft.AspNetCore.Authentication.JwtBearer | 7.0.9 |
| Microsoft.AspNetCore.Http | 2.2.2 |
| Microsoft.AspNetCore.Http.Abstractions | 2.2.0 |
| Microsoft.AspNetCore.Features | 5.0.17 |
| Microsoft.EntityFrameworkCore.Design | 5.0.8 |
| Microsoft.EntityFrameworkCore.SqlServer | 7.0.10 |
| Microsoft.EntityFrameworkCore.Configuration | 5.0.0 |
| Microsoft.EntityFrameworkCore.Configuration.Binder | 7.0.4 |
| Microsoft.IdentityModel.Tokens | 6.12.2 |
| Newtonsoft.Json | 13.0.3 |

## Associated Project

The frontend of this project [RentACarFrontend](https://github.com/yusufsafaa/RentACarFrontend)

## Contributions

Thanks to dear [Engin Demiroğ](https://github.com/engindemirog) for his contributions.
