# Tax Management App

This is a simple C# console application for managing and checking municipality tax rates based on dates.  
It supports checking and adding yearly, monthly, and daily tax records.


# Features

- Add and query tax records for municipalities
- Prioritizes specific tax periods (daily > monthly > yearly)
- Includes unit tests (xUnit)
- Includes hard coded tax related data but structured in a way so the app can readily be connected with a db

# Project Structure

Tax Management App/
├── TaxManagementApp/
│ ├── Models/
│ │ └── TaxRecord.cs
│ ├── Repositories/
│ │ ├── ITaxRepository.cs
│ │ └── InMemoryRepository.cs
│ ├── Services/
│ │ └── TaxManager.cs
│ ├── Program.cs
│ └── TaxManagementApp.csproj
│
├── TaxManagementApp.Tests/
│ ├── TaxManagerTests.cs
│ └── TaxManagementApp.Tests.csproj
│
└── README.md

# How to run the app

It is recommended to open the main app folder using Visual Studio Code.

1. Open the main app folder
2. Navigate to TaxManagementApp solution or folder
3. Either run the solution using GUI or open the terminal and write dotnet run (make sure you are in the TaxManagementApp folder in the terminal)
4. You'll see prompts like:
    Choose an option:
    1. Check tax rate (original task)
    2. Add new tax record (bonus task)
5. Follow the on screen instructions to either view tax rates for a date or add a new municipality with dates and corresponding tax rates of your liking.


# How to run unit tests

1. Open the main app folder using VS Code
2. Navigate to TaxManagementApp.Tests solution or folder
3. Either test the solution using GUI or open the terminal and write dotnet test (make sure you are in the TaxManagementApp.Tests folder in the terminal)
4. You should see outputs like
    Passed!  - TaxManagerTests.GetTaxRate_ReturnsCorrectRate_ForMay2025
    Passed!  - TaxManagerTests.MunicipalityExists_ReturnsFalse_ForUnknown

You just tested the following:
1. GetTaxRate_ReturnsCorrectRate_ForExactMatch - Ensures correct tax rate is picked
2. MunicipalityExists_ReturnsFalse_ForUnknownMunicipality - Validates unknown cities are rejected




