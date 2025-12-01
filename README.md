# Secure Order Management API (.NET 8)

## Overview
This is a secure REST API built using **ASP.NET Core 8.0**, designed to manage customer orders. It implements enterprise-level security using **ASP.NET Core Identity** and **JWT Authentication**.

The system ensures data privacy by isolating records per user—customers can only view, edit, or delete their own orders.

## Tech Stack
* **Framework:** .NET 8.0 (Web API)
* **Database:** SQL Server (Entity Framework Core Code-First)
* **Security:** Identity Core + JWT Bearer Tokens
* **Tools:** Visual Studio 2022, Postman, Swagger UI

## Key Features
1.  **User Authentication:** Secure Registration and Login endpoints generating JWT tokens.
2.  **Authorization:** All Order endpoints are protected with `[Authorize]`.
3.  **Data Integrity:**
    * Used **DTOs** to validate input data (e.g., preventing negative prices).
    * **Server-side calculation** for Order Totals to prevent fraud.
    * Strict **Data Isolation** (Users cannot access each other's data).
4.  **CRUD Operations:** Full Create, Read, Update, and Delete functionality.

## How to Run
1.  **Clone the repository.**
2.  Open the solution in **Visual Studio 2022**.
3.  Update the connection string in `appsettings.json` if needed.
4.  Run the following commands in the **Package Manager Console** to set up the database:
    ```powershell
    Update-Database
    ```
5.  Press **F5** to run the application.

## Testing
* Use **Swagger UI** for quick API exploration.
* Use **Postman** (recommended) to test the full authentication flow (Register -> Login -> Copy Token -> Access Orders).