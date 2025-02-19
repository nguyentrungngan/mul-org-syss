# BranchDataAutomation Backend

## Purpose
This backend designed for automated data extraction, transformation, and integration with Power BI. The system is structured for maintainability and scalability, utilizing environment variables for easy configuration.

## Key Features

- **Scheduled Execution**: Automates data processing every 15 minutes using a scheduler.
- **Data Extraction**: Fetches data from SQL Server databases securely.
- **Data Conversion**: Transforms raw database output into structured formats.
- **Data Upload**: Transfers processed data securely to a central data warehouse via SFTP.
- **Power BI Refresh**: Triggers Power BI reports and dashboards to refresh automatically.
- **Email Notifications**: Sends success or failure status updates to designated recipients.
- **VPN Connection**: Ensures secure communication between branch databases and the central server.

## Modules Overview

- `scheduled_execution.py`: Manages the 15-minute interval job execution.
- `data_extraction.py`: Connects to SQL Server and retrieves relevant data.
- `data_conversion.py`: Processes and converts extracted data.
- `data_upload.py`: Uploads transformed data via SFTP.
- `powerbi_refresh.py`: Calls Power BI API to refresh dashboards.
- `email_notifications.py`: Sends notifications via email.
- `vpn_connection.py`: Handles secure VPN connections.

## Environment Configuration
The system loads essential configuration values from environment variables. Ensure that `.env` is properly set up with the following:

```
DB_SERVER=<your_database_server>
DB_NAME=<your_database_name>
DB_USER=<your_database_user>
DB_PASSWORD=<your_database_password>
SFTP_SERVER=<your_sftp_server>
SFTP_USER=<your_sftp_user>
SFTP_PASSWORD=<your_sftp_password>
SFTP_REMOTE_PATH=<sftp_remote_path>
POWERBI_GROUP=<powerbi_group_id>
POWERBI_DATASET=<powerbi_dataset_id>
POWERBI_ACCESS_TOKEN=<powerbi_access_token>
EMAIL_SENDER=<email_sender>
EMAIL_RECIPIENT=<email_recipient>
SMTP_SERVER=<smtp_server>
SMTP_PORT=<smtp_port>
EMAIL_PASSWORD=<email_password>
VPN_CONNECT_COMMAND=<vpn_connect_command>
VPN_DISCONNECT_COMMAND=<vpn_disconnect_command>
```

## Running the Backend
Ensure dependencies are installed and run the script:

```
pip install -r requirements.txt
python main.py
```

