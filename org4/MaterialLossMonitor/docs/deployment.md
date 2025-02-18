# Deployment

## System Requirements
- **Operating System**: Windows Server
- **Python Version**: 3.8
- **Database**: SQL Server (for MES queries)
- **Network**: Access to PLC via Modbus TCP and FTP Server

## Installation Steps

### 1. Set Up Python Environment
1. Install Python 3.8 and from requirement.txt.
2. Install required dependencies:
   ```sh
   pip install pyModbusTCP pyodbc ftplib pandas smtplib
   ```
3. Configure environment variables for database and FTP credentials.

### 2. Configure Database & Network Access
1. Ensure SQL Server authentication is enabled for MES queries.
2. Verify PLC connectivity over **Modbus TCP**.
3. Confirm FTP server credentials and directory structure for data retrieval.

### 3. Deploy Python Scripts
1. Copy Python scripts to the deployment directory.
2. Configure `.env file` or environment variables for dynamic parameters.
3. Configure automation machine: 
    ```
      C:\Automation\MaterialLossMonitor\main.py
    ```
  - Refer to org4/MaterialLossMonitor/src/readme_backend.md

### 5. Testing & Validation
1. Run the script manually to verify data extraction and calculations.
2. Check logs for errors and debug if necessary.
3. Ensure emails and FTP reports are generated as expected.

### 6. Monitoring & Maintenance
- Implement **log rotation** to manage execution logs.
- Schedule periodic **data integrity checks** for PLC and MES synchronization.
- Set up **alert notifications** for script failures.

## Rollback Strategy
- Maintain a backup of previous script versions.

## Security Considerations
- Use **encrypted connections** for FTP (SFTP) and database queries.
- Restrict script execution to authorized users only.
- Store credentials securely in environment variables instead of hardcoding.

