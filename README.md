# DataMgtCoreAPI

An educational ASP.NET Core 8 Web API showing a layered architecture with Dapper, SQL Server,
repository interfaces, a business layer, dependency injection, and Swagger/OpenAPI.

> **Project status:** maintained reference project. It is suitable for learning and local
> experimentation, but it is not production-ready. Authentication, authorization, automated
> tests, complete Product CRUD, database migrations, observability, and deployment hardening
> are not implemented.

## What is implemented

| Area | Status | Notes |
| --- | --- | --- |
| Users | Partial | CRUD endpoints and stored procedures are included. |
| Customers | Partial | Controller and repository exist; matching SQL setup scripts are not included. |
| Products | Prototype | List operation exists; create, read-by-ID, update, and delete are placeholders. |
| API documentation | Implemented | Swagger is enabled in the Development environment. |
| Automated tests | Not implemented | CI currently verifies restore and compilation only. |
| Authentication/authorization | Not implemented | Do not expose this API publicly. |

## Architecture

```text
HTTP request
    -> DataManagement.API
    -> DataManagement.Business
    -> DataManagement.Repository
    -> SQL Server stored procedures
```

Projects:

- `DataManagement.API`: controllers, dependency registration, configuration, and Swagger.
- `DataManagement.Business` / `.Interfaces`: user business-service abstraction.
- `DataManagement.Repository` / `.Interfaces`: Dapper data access.
- `DataManagement.Entities`: domain/data-transfer models.
- `DataManagement.SQL`: numbered SQL Server setup scripts.

## Prerequisites

- .NET 8 SDK
- SQL Server or SQL Server Developer/Express
- A local connection string with permission to create and use the sample database

## Local setup

1. Clone the repository.
2. Run the numbered scripts in
   [`DataManagement/DataManagement.SQL/Scripts`](DataManagement/DataManagement.SQL/Scripts)
   in order. These scripts currently create only the Users schema and procedures.
3. Supply a connection string without committing credentials. The recommended environment
   variable is:

   ```powershell
   $env:ConnectionStrings__MyConnection="Server=localhost;Database=DataManagement;Trusted_Connection=True;TrustServerCertificate=True"
   ```

   On macOS/Linux:

   ```bash
   export ConnectionStrings__MyConnection="Server=localhost;Database=DataManagement;Trusted_Connection=True;TrustServerCertificate=True"
   ```

4. Restore, build, and run:

   ```bash
   dotnet restore DataManagement/DataManagement.sln
   dotnet build DataManagement/DataManagement.sln --configuration Release --no-restore
   dotnet run --project DataManagement/src/DataManagement.WebAPI/DataManagement.API.csproj
   ```

5. Open the development URL shown by `dotnet run`, followed by `/swagger`.

The checked-in `appsettings.json` contains only a local placeholder. For secrets, prefer an
environment variable, .NET user secrets, or a deployment secret store.

## Important limitations

- This repository has no known Azure deployment dependency.
- It contains no authentication or authorization.
- Customer SQL objects are referenced by code but are not provided by the numbered scripts.
- Product CRUD is intentionally incomplete.
- Repository methods are synchronous and intended for demonstration rather than scale.
- No license has been granted; the repository's public visibility does not itself grant reuse
  rights.

See [API-Best-Practices.md](API-Best-Practices.md) for general design notes and
[SECURITY.md](SECURITY.md) for safe-use guidance.
