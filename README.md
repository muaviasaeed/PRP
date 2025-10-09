# Population Reporting System

## Project Overview
This is a desktop-based population reporting system developed in **C# (WinForms)** with **SQL Server** as the backend database. The application generates detailed reports about population, countries, cities, and languages, as per real-world reporting needs.

## Technologies Used
- C# (.NET Framework) – WinForms GUI
- SQL Server
- Docker (for containerized SQL setup)
- Git & GitHub (for version control)
- GitHub Actions (CI/CD - setup in progress)

## Getting Started

### Prerequisites
- Visual Studio (with .NET Desktop Development workload)
- SQL Server (local or via Docker)
- Docker Desktop (optional, for database container)
- .NET SDK (for WinForms)

### How to Run the Application

#### Option 1: Run SQL Server via Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Pass123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

#### Option 2: Use Local SQL Server
Ensure SQL Server is running on your local machine and update the connection string in the application accordingly.

### Database Setup
1. Import the database schema from the provided SQL scripts
2. Update the connection string in `App.config` or the application settings

### Running the Application
1. Open the solution in Visual Studio
2. Build the solution
3. Run the application

## Features
- Generate comprehensive population reports
- Query data by country, city, and language
- User-friendly WinForms interface
- SQL Server integration for robust data management

## Contributing
Contributions are welcome! Please feel free to submit a Pull Request.

## License
This project is licensed under the MIT License.
