# **Important notes**
- This repository serves as a reference for the development, design, and operation of internal systems while showcasing expertise in IT System Development.
- The data and documentation are **simulated** based on real-world experience,
**does not contain confidential or sensitive information**.
---
# Install Guide - PLC Data Viewer

## 1️. Requirements  
- Windows with **.NET Framework 4.7+** or **.NET Core 6+**  
- **ODBC Driver for SQL Server**  
- **Newtonsoft.Json** library for JSON parsing  

## 2️ Installation Steps  

1. **Install necessary dependencies**  
   - Windows: Ensure .NET is installed from [Microsoft .NET Download](https://dotnet.microsoft.com/en-us/download)  
   - Install Newtonsoft.Json via NuGet:  
     ```sh
     dotnet add package Newtonsoft.Json
     ```

2. **Configure database connection**  
   - Edit `config.json` with correct SQL Server credentials and refresh interval settings.  

3. **Build and Run**  
   - Windows (using .NET Core CLI):  
     ```sh
     dotnet build
     dotnet run
     ```
   - Windows (using .NET Framework):  
     ```sh
     csc /reference:Newtonsoft.Json.dll main.cs
     main.exe
     ```
   - Alternatively, compile in Visual Studio and execute.

4. **Usage**  
   - The application will fetch and display the latest PLC data from the database every set interval.  
   - Press **Enter** to exit the program.
