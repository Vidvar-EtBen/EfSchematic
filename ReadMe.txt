<---------------------->
<-- IMPORTANT NOTICE -->
<---------------------->

All "Example" files in this project are temporary/small guides intended for you to change, replace, or use as a starting point for your own implementation. 
Please update or remove them as needed for your solution.

<-------------------->
<-- NuGet Packages -->
<-------------------->

<-- Api -->
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore

<-- DataAccess -->
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

<-- Entites -->
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

<--------------------------->
<-- create classes for Ef -->
<--------------------------->

<-- Remove example files if not alredy done -->

/ Open Package Manager Console \
Tools > NuGet Package Manager > Package Manager Console

/ Find Connection string \
View > SQL Server ObjectExplorer > Desired db > Properties > Connection string

<-- change "connection string" & "dbNameContext" -->

/ Copy/Paste to Package Manager Console and run with correct connection string and db Context name \
Scaffold-DbContext " connection string "
Microsoft.EntityFrameworkCore.SqlServer -Context dbNameContext -
Project Entities -StartupProject Api

<-- Move "dbNameContext" to Context folder -->

<---------------------------->
<-- Api Setup Instructions -->
<---------------------------->

/ Prerequisites \
- Ensure .NET9 SDK is installed
- Restore NuGet packages for all projects

/ Configuration \
- Update the connection string in appsettings.json (Api project) with your SQL Server details
- Ensure the connection string name matches "ExampleConnection" in Program.cs

/ Build & Run \
- Set Api as the startup project
- Build the solution
- Run the Api project

/ Accessing the API \
- API endpoints are available at: https://localhost:{port}/api/example
- Swagger UI is available at: https://localhost:{port}/swagger (development only)

/ Example Usage \
- GET /api/example: Returns all Example entities

/ Troubleshooting \
- If you encounter database errors, verify your connection string and database accessibility
- Ensure Entity Framework migrations are applied if needed

/ For more details, see Program.cs and ExampleController.cs \

<------------------------------->
<-- Creating New Repositories -->
<------------------------------->	

/ Steps to create a new repository for an entity \
1. Create a repository interface in DataAccess/RepositoryInterfaces:
 - Example: IYourEntityRepository.cs
 - Inherit from IGenericRepository<YourEntity>
 - Add custom query methods if needed

2. Create a repository implementation in DataAccess/Repositories:
 - Example: YourEntityRepository.cs
 - Inherit from GenericRepository<YourEntity> and implement your interface
 - Inject DbContext via constructor

3. Register your repository in Api/Program.cs:
 builder.Services.AddScoped<IYourEntityRepository, YourEntityRepository>();
 builder.Services.AddScoped<IGenericRepository<Entities.YourEntity>, YourEntityRepository>();

4. Use the repository via UnitOfWork in your controllers:
 IYourEntityRepository repo = (IYourEntityRepository)unitOfWork.GetRepository<YourEntity>();

/ See IExampleRepository.cs and ExampleRepository.cs for reference implementations \
