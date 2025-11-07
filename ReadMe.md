# 🚀 .NET 9 API Template with EF Core & Repository Pattern

**A robust starting template for building a Web API using .NET 9, Entity Framework Core (EF Core), and SQL Server. This project features a Generic Repository and Unit of Work implementation for clean data access.**

---

## ⚠️ Important Notice: Example Files

All files labeled as "**Example**" (e.g., `ExampleController.cs`, `IExampleRepository.cs`) are small guides intended for you to **change, replace, or use as a starting point** for your own implementation.

**Please update or remove them as needed for your specific solution.**

---

## 📦 NuGet Packages

This project utilizes the following key NuGet packages across its three layers:

| Project | Key Packages | Purpose |
| :--- | :--- | :--- |
| **Api** | `Microsoft.EntityFrameworkCore.SqlServer`<br>`Swashbuckle.AspNetCore` | Web API logic, configuration, and API documentation (Swagger/OpenAPI). |
| **DataAccess** | `EtBen.DataAccess.EF.Sql` | Data access layer (Repositories, Unit of Work) and EF Core setup. |
| **Entities** | `Microsoft.EntityFrameworkCore.SqlServer`<br>`Microsoft.EntityFrameworkCore.Tools` | Data model/POCO classes for the database entities. |

---

## ⚙️ API Setup & Running Instructions

### Prerequisites

* **[.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)** installed.
* A running **SQL Server** instance.
* **Restore NuGet packages** for all projects in the solution.

### Configuration

1.  Open `appsettings.json` in the **`Api`** project.
2.  Update the `ConnectionStrings` section with your SQL Server details.
    > 💡 **Note:** The connection string key **must** be named `"ExampleConnection"` as referenced in `Api/Program.cs`.

### Build & Run

1.  Set the **`Api`** project as the **Startup Project**.
2.  Build the solution.
3.  Run the **`Api`** project (e.g., press **F5** in Visual Studio).

### Accessing the API

| Feature | URL (Development) | Notes |
| :--- | :--- | :--- |
| **API Endpoints** | `https://localhost:{port}/api/example` | Replace `{port}` with your assigned port number. |
| **Swagger UI** | `https://localhost:{port}/swagger` | Interactive documentation for testing endpoints. (Development only) |

**Example Usage:** `GET /api/example` returns all `Example` entities.

---

## 🛠️ Entity Framework Core (EF Core) Setup

Use these steps to scaffold (`Scaffold-DbContext`) your `DbContext` and model classes from an existing database using the Package Manager Console (PMC).

1.  **Preparation:** Ensure you have **removed or replaced** the existing `Example` files/models if you haven't already.

2.  **Open PMC:** Go to **Tools** > **NuGet Package Manager** > **Package Manager Console**.

3.  **Get Connection String:** Locate the exact connection string for your database (e.g., via **SQL Server Object Explorer**).

4.  **Scaffold `DbContext` and Models:**
    **Ensure you replace `"your connection string"` and `YourDbNameContext` with your actual values before running.**

    ```powershell
    Scaffold-DbContext "your connection string" Microsoft.EntityFrameworkCore.SqlServer -Context YourDbNameContext -Project Entities -StartupProject Api
    ```

5.  **Relocate `DbContext`:**
    * Move the newly created `YourDbNameContext.cs` file from the root of the `Entities` project into the **`DataAccess/Context`** folder.

---

## 🏗️ Creating New Repositories

The project uses a **Generic Repository** and **Unit of Work** pattern. Follow these steps to create a specific repository for a new entity (`YourEntity`):

### 1. Create Repository Interface

* **Location:** `DataAccess/RepositoryInterfaces/`
* **Inherit from `IGenericRepository<YourEntity>`** and add any custom query methods specific to your entity.
    ```csharp
    // Example: IYourEntityRepository.cs
    public interface IYourEntityRepository : IGenericRepository<YourEntity>
    {
        Task<List<YourEntity>> GetEntitiesByStatusAsync(string status);
    }
    ```

### 2. Create Repository Implementation

* **Location:** `DataAccess/Repositories/`
* **Inherit from `GenericRepository<YourEntity>`** and implement your interface.
    ```csharp
    // Example: YourEntityRepository.cs
    public class YourEntityRepository : GenericRepository<YourEntity>, IYourEntityRepository
    {
        public YourEntityRepository(YourDbContext context) : base(context)
        {
        }
        // Implement custom methods here
    }
    ```

### 3. Register the Repository in Dependency Injection (DI)

* **Location:** `Api/Program.cs`
* Add the following lines to register your repository services:
    ```csharp
    // Register the specific repository interface
    builder.Services.AddScoped<IYourEntityRepository, YourEntityRepository>();

    // Register the generic repository for this entity (used by UnitOfWork)
    builder.Services.AddScoped<IGenericRepository<Entities.YourEntity>, YourEntityRepository>();
    ```

### 4. Use the Repository via UnitOfWork

In your controllers or services, inject and use the `IUnitOfWork` to access the repository:

```csharp
// Example: Getting the specific repository instance from UnitOfWork
IYourEntityRepository repo = (IYourEntityRepository)unitOfWork.GetRepository<YourEntity>();
var data = await repo.GetEntitiesByStatusAsync("Active");