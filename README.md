# Bulky BookStore Solution

Bulky is a modular ASP.NET Core MVC application for managing a bookstore, built with a layered architecture. It demonstrates best practices in separation of concerns, repository/unit-of-work patterns, and Entity Framework Core for data access.

---

## Table of Contents

- [Solution Structure](#solution-structure)
- [Projects Overview](#projects-overview)
- [Getting Started](#getting-started)
- [Database Migrations](#database-migrations)
- [Key Features](#key-features)
- [Contributing](#contributing)
- [License](#license)

---

## Solution Structure

```
Bulky/
├── Bulky.sln
├── Bulky.DataAccess/
├── Bulky.Models/
├── Bulky.Utility/
├── BulkyWeb/
├── BulkyWebRazor_Temp/
└── .vs/
```

### Projects

- **Bulky.DataAccess**: Data access layer, repositories, and EF Core context.
- **Bulky.Models**: Entity and ViewModel classes.
- **Bulky.Utility**: Shared constants and utility classes.
- **BulkyWeb**: Main ASP.NET Core MVC web application.
- **BulkyWebRazor_Temp**: (Optional) Razor Pages or temporary web project.

---

## Projects Overview

### Bulky.Models

Contains entity models such as `Category`, `Product`, and view models.  
Example: [`Category.cs`](Bulky.Models/Category.cs), [`Product.cs`](Bulky.Models/Product.cs)

### Bulky.DataAccess

- Implements the repository and unit of work patterns.
- Contains the EF Core `ApplicationDbContext`.
- Handles migrations and database seeding.
- Example repositories: [`CategoryRepository`](Bulky.DataAccess/Repository/CategoryRepository.cs), [`ProductRepository`](Bulky.DataAccess/Repository/ProductRepository.cs), [`UnitOfWork`](Bulky.DataAccess/Repository/UnitOfWork.cs)

### Bulky.Utility

- Contains shared constants (e.g., `SD.cs`) and utility classes.

### BulkyWeb

- The main ASP.NET Core MVC application.
- Contains controllers, views, and configuration files (`appsettings.json`).

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or change connection string for your DB)
- Visual Studio 2022+ or VS Code

### Build and Run

1. **Clone the repository:**
    ```sh
    git clone <your-repo-url>
    cd Bulky
    ```

2. **Restore NuGet packages:**
    ```sh
    dotnet restore
    ```

3. **Apply database migrations:**
    ```sh
    cd Bulky.DataAccess
    dotnet ef database update
    ```

4. **Run the web application:**
    ```sh
    cd ../BulkyWeb
    dotnet run
    ```
    The app will be available at `https://localhost:5001` (or as configured).

---

## Database Migrations

- Migrations are managed in the `Bulky.DataAccess` project.
- To add a migration:
    ```sh
    dotnet ef migrations add <MigrationName> --project Bulky.DataAccess
    ```
- To update the database:
    ```sh
    dotnet ef database update --project Bulky.DataAccess
    ```

---

## Key Features

- **Layered Architecture**: Clean separation between models, data access, utilities, and web UI.
- **Repository & Unit of Work**: Abstracts data access logic for maintainability and testability.
- **Entity Framework Core**: Code-first approach for database management.
- **MVC Pattern**: Clean separation of concerns in the web application.
- **Configuration**: Environment-specific settings in `appsettings.json`.

---

## Contributing

1. Fork the repository.
2. Create your feature branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a Pull Request.

---

## License

This project is licensed under the MIT License.

---

## Acknowledgements

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)