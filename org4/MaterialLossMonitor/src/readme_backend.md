# MaterialLossMonitor Backend

## Purpose
This backend system designed for automated data extraction, transformation, and integration with Power BI. The system is structured for maintainability and scalability, utilizing environment variables for easy configuration.

## Key Features
- **Scheduled Execution**: Automates data processing every 15 minutes using a scheduler.
- **Data Synchronization**: Extracts data from PLCs, MES, and FTP servers.
- **Data Processing**: Cleans, normalizes, and calculates material loss.
- **Data Storage**: Stores processed reports in FTP.
- **Reporting & Alerts**: Sends periodic reports and instant alerts on material loss.
- **System Logs**: Logs system activities and errors.

## Modules Overview
- `scheduled_execution.py`: Manages the scheduled execution of tasks.
- `data_synchronization.py`: Fetches data from PLC, MES, and FTP.
- `data_processing.py`: Cleans and normalizes the raw data.
- `data_calculation.py`: Calculates material loss percentage.
- `data_storage.py`: Saves processed data to FTP.
- `reporting_alerts.py`: Handles report generation and alert notifications.
- `system_logs.py`: Manages logging and error handling.

## Environment Configuration
The system uses environment variables for configuration. Ensure the `.env` file is set up with the following:

```
MES_SERVER=server
MES_DB=mes_db
MES_USER=user
MES_PASS=password
FTP_SERVER=ftp.server.com
FTP_USER=user
FTP_PASS=password
EMAIL_SMTP=smtp.server.com
EMAIL_USER=your_email@example.com
EMAIL_PASS=your_password
```
## Running the Backend
Ensure dependencies are installed and run the script:

```
pip install -r requirements.txt
python main.py
```
