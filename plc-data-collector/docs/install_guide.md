# **Important notes**
- This repository serves as a reference for the development, design, and operation of internal systems while showcasing expertise in IT System Development.
- The data and documentation are **simulated** based on real-world experience,
**does not contain confidential or sensitive information**.
---
# Install Guide - PLC Data Collector 
---
## 1. Requirements  
- Windows with **Visual Studio**
- **ODBC Driver for SQL Server**  
- **libmodbus** library (if using Modbus TCP communication)  

## 2. Installation Steps  

### Install required libraries  
- **On Windows:**  
  ```sh
  vcpkg install libmodbus
  ```

### Configure connection settings
Edit the config.ini file with the PLC IP address and SQL Server connection details.

### Complile and run the program

  ```
  cl main.cpp /Ipath/to/libs /link /out:plc_collector.exe
  ```

  Run the application: 

  ```
  ./plc_collector
  ```

