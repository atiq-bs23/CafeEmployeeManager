A .NET Core 8 Project Template using MSSQL and Entity Framework Core.

Prerequisites
Before running the project, ensure you have the following installed:

Visual Studio 2022 (Latest version recommended)
.NET Core 8 SDK
SQL Server (MSSQL)
Entity Framework Core
Steps to Run the Project
1. Clone the Repository
Open a terminal or Git Bash and execute:

git clone https://github.com/atiq-bs23/CafeEmployeeManager.git


2. Update Connection String in appsettings.json
Navigate to the appsettings.json file in the project root directory and update the ConnectionStrings:DefaultConnection property to match your SQL Server configuration:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your-server>;Database=<your-database>;User Id=<your-username>;Password=<your-password>;Trusted_Connection=False;Encrypt=True;"
  }
}

For local development, you can use Trusted_Connection=True if you're using Windows Authentication.

3. Restore Dependencies
Open the project in Visual Studio 2022 and restore dependencies. You can also restore via the command line:

dotnet restore

5. Apply Database Migrations
Run the following command in the Package Manager Console or terminal to apply migrations and create the database:

update-database

6. Build and Run the Project
