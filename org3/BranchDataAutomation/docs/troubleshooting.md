# Troubleshooting Guide

## Purpose
This document outlines common issues and troubleshooting steps for the Modular Python Backend system. It helps identify and resolve potential problems related to data extraction, transformation, integration, and other key functionalities.

## Common Issues & Solutions

### 1. **Database Connection Issues**
   - **Problem**: The system is unable to connect to the SQL Server database.
   - **Cause**: Incorrect database credentials or network connection issues.
   - **Solution**:
     - Verify the following values in the `.env` file:
       - `DB_SERVER`: Ensure the correct database server name or IP is provided.
       - `DB_NAME`: Confirm the correct database name.
       - `DB_USER` and `DB_PASSWORD`: Verify that the user credentials are correct.
     - Check if the database server is accessible from the machine where the script is running.
     - Test the database connection using a database management tool (e.g., SQL Server Management Studio).
     - Ensure there are no firewall or network restrictions blocking the connection.

### 2. **SFTP Upload Failures**
   - **Problem**: Data fails to upload to the SFTP server.
   - **Cause**: Incorrect SFTP credentials or connection issues.
   - **Solution**:
     - Ensure that the following variables in `.env` are correct:
       - `SFTP_SERVER`: Verify the correct SFTP server address.
       - `SFTP_USER` and `SFTP_PASSWORD`: Check that the credentials are accurate.
       - `SFTP_REMOTE_PATH`: Ensure the correct remote path is specified for data upload.
     - Test the SFTP connection manually using an SFTP client (e.g., FileZilla) to confirm credentials and remote path.
     - Verify that the SFTP server is reachable and running.

### 3. **Power BI Refresh Failures**
   - **Problem**: Power BI dashboards fail to refresh.
   - **Cause**: Invalid API credentials or network connectivity issues.
   - **Solution**:
     - Confirm the following values in the `.env` file:
       - `POWERBI_GROUP`, `POWERBI_DATASET`, and `POWERBI_ACCESS_TOKEN` must be accurate.
     - Ensure the access token is still valid and has the required permissions.
     - Test the Power BI API using Postman or another REST client to verify access.
     - Check for network issues or firewall rules blocking communication with the Power BI API.

### 4. **Email Notification Failures**
   - **Problem**: Email notifications for success or failure are not being sent.
   - **Cause**: SMTP server issues or incorrect email configuration.
   - **Solution**:
     - Check the following values in the `.env` file:
       - `SMTP_SERVER`: Ensure the correct SMTP server address is specified.
       - `SMTP_PORT`: Verify the correct port number (usually 587 for TLS or 465 for SSL).
       - `EMAIL_SENDER` and `EMAIL_PASSWORD`: Ensure these are correct for your email account.
       - `EMAIL_RECIPIENT`: Verify that the recipient email address is valid.
     - Test sending a test email using an email client or telnet command to the SMTP server.
     - Check the SMTP server's settings for any restrictions on outgoing mail.

### 5. **VPN Connection Failures**
   - **Problem**: The VPN connection fails or does not establish.
   - **Cause**: Incorrect VPN connection command or access restrictions.
   - **Solution**:
     - Verify that the VPN commands in the `.env` file are correct:
       - `VPN_CONNECT_COMMAND` and `VPN_DISCONNECT_COMMAND`: Ensure the correct commands are provided for connecting and disconnecting the VPN.
     - Test the VPN connection manually using the same command in a terminal.
     - Ensure that the VPN service is running and that the credentials or VPN server settings are accurate.

### 6. **Scheduled Execution Issues**
   - **Problem**: Scheduled jobs (15-minute intervals) are not running as expected.
   - **Cause**: Incorrect scheduling configuration or issues with the task scheduler.
   - **Solution**:
     - Verify that the scheduler is configured correctly in `scheduled_execution.py` and that it's running as expected.
     - Check the system logs to identify any issues with the job execution.
     - Ensure that the task scheduler (e.g., cron jobs or Windows Task Scheduler) is correctly set up and the script is executable.

### 7. **Data Extraction Failures**
   - **Problem**: The system is unable to fetch data from SQL Server.
   - **Cause**: Incorrect SQL queries, database issues, or network problems.
   - **Solution**:
     - Review the `data_extraction.py` file for any errors in SQL queries or connection issues.
     - Verify that the database credentials in the `.env` file are correct.
     - Test the database connection and queries using SQL Server Management Studio or a similar tool.
     - Check the network for any connectivity issues between the backend system and the SQL Server.

## System Logs
Logs are generated for every operation to help with troubleshooting. Check the logs for detailed error messages that may indicate the root cause of an issue.

- **Log Location**: Logs are typically stored in a specified directory. Refer to `system_logs.py` for the exact path.
- **Error Messages**: Logs will contain error messages that will help pinpoint where issues occur. Look for error codes or messages related to the modules where the issue arises.

