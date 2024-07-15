# rent-a-car-project

This is a "Rent a Car" API built with ASP.NET, providing functionalities for user authentication, authorization, and CRUD operations for cars, car brands, and car colors. The API also includes functionalities for renting cars.

## Features

- **Authentication and Authorization**: Secure login and role-based access control.
- **CRUD Operations**:
  - Cars: Create, Read, Update, and Delete cars.
  - Car Brands: Manage car brands.
  - Car Colors: Manage car colors.
- **Renting**: Rent and manage car rentals.

## Technologies Used

- **Backend:**

  - ASP.NET Core
  - Entity Framework Core
  - Autofac

- **Database:**

  - SQL Server Express

## Installation
    ```bash
    git clone https://github.com/omerfarukgulhan/rent-a-car-project
    cd rent-a-car-project
    ```

   ```
   dotnet restore
   dotnet ef database update
   ```

   ```
   dotnet run
   ```
