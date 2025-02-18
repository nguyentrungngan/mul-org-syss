# Solution

## Technical Stack  
- **Backend:** Python (for automation scripts and data processing)  
- **Data Extraction:** SQLAlchemy / pyodbc (to connect and extract data from SQL Server)  
- **Data Storage:** Data Warehouse (to store processed data)  
- **Data Transfer:** Secure FTP (SFTP) or direct API integration with the data warehouse  
- **Email Notifications:** smtplib and email.mime (for sending log notifications via email)  
- **Power BI Integration:** Power BI REST API (for triggering data refresh)  
- **Security:** VPN for secure communication between branch databases and the central server  

## Data Flow  
1. **Scheduled Execution**: A Python script is scheduled to run every 15 minutes using a task scheduler (Task Scheduler for Windows).
2. **Data Extraction**: The script connects to the SQL Server databases at each branch using **SQLAlchemy** or **pyodbc**, and extracts the required data.
3. **Data Conversion**: Extracted data is processed and converted into a structured CSV format.
4. **Data Upload**: The CSV file is uploaded to a **central data warehouse** via SFTP, ensuring data integrity during the transfer.
5. **Power BI Refresh**: Once the data is uploaded to the data warehouse, the Python script triggers the **Power BI REST API** to refresh the related Power BI reports and dashboards.
6. **Email Notifications**: The script sends email notifications using **smtplib** and **email.mime**. If the process is successful, a success email is sent to the internal team; if there is an error, an error message with relevant details is sent to the team.

