# **Important notes**
- This repository serves as a reference for the development, design, and operation of internal systems while showcasing expertise in IT System Development.
- The data and documentation are **simulated** based on real-world experience,
**does not contain confidential or sensitive information**.
---
# Install & guide
---
## Prerequisites
- **Python Environment**: Ensure Python (>=3.8) is installed.
- **Dependencies**: Install required Python packages:
  ```bash
  pip install sqlalchemy pyodbc paramiko smtplib pandas requests
  ```
- **SQL Server Access**: Ensure credentials and connection details for branch databases are available.
- **Data Warehouse Access**: Ensure credentials and SFTP/API details are configured.
- **Power BI API Access**: Ensure authentication setup for triggering report refresh.
- **Email SMTP Server**: Ensure SMTP details for notification emails.

## Install Steps

### 1. Setup Python Script Execution
- Place the Python script in a dedicated folder (e.g., `C:\Automation\DataSync\`).
- Update script configurations (database details, SFTP credentials, Power BI API keys).

### 2. Configure automation machine
  ```bash
  python C:\Automation\DataSync\main.py
  ```
- Refer to org3/BranchDataAutomation/src/readme_backend.md

### 3. Data Extraction and Upload
- The script will connect to SQL Server via **pyodbc** or **SQLAlchemy**.
- Data is processed and converted into a structured CSV.
- CSV is securely uploaded to the **Data Warehouse** via **SFTP**.

### 4. Trigger Power BI Refresh
- The script will call the **Power BI REST API** to refresh reports.

### 5. Email Notification Setup
- Ensure SMTP settings are configured.
- The script will send success/failure notifications.

### 6. Testing & Validation
- Run the script manually to verify connectivity and data integrity.
- Check the data warehouse for uploaded files.
- Validate Power BI dashboard refresh.
- Review email notifications.