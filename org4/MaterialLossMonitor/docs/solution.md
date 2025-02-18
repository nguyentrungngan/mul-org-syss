# Solution

## Technical Stack  
- **Backend:** Python (for automation scripts and data processing)  
- **Data Extraction:**
  - `pyModbusTCP` (to fetch real-time data from PLC via Modbus TCP)  
  - `pyodbc` (to connect and query data from SQL Server MES)  
  - `ftplib` (to fetch structured material issuance files from FTP)  
- **Data Storage:** Processed data stored in structured FTP folders for easy retrieval.  
- **Data Processing:** Pandas (for data manipulation and material loss calculation).  
- **Data Transfer:** Secure FTP (SFTP) for structured file handling and log storage.  
- **Email Notifications:** `smtplib` and `email.mime` (for sending alert and summary reports).  
- **Task Scheduling:** Windows Task Scheduler / Cron Job (to execute tasks at predefined intervals).  

## Data Flow  
1. **Scheduled Execution**: A Python script runs every 15 minutes to synchronize and analyze data.  
2. **Data Synchronization**: The script collects data from:
   - **PLC via Modbus TCP** – Fetches real-time material consumption data.
   - **MES (SQL Server)** – Queries production order and planned material issuance data.
   - **FTP Server** – Retrieves structured files containing actual issued material data.
3. **Data Processing & Calculation**:
   - Cleans and normalizes the extracted data.
   - Computes **Material Loss %** using the formula:
     
     {A} = ({Material Issued on MES} + {Material Issued on FTP})/2 - {Actual from PLC}
     {B} = ({Material Issued on MES} + {Material Issued on FTP})/2
     {Material Loss} = ({A} / {B}) * 100%

4. **Data Storage**: Processed reports are stored in a designated FTP folder.  
5. **Reporting & Alerts**:  
   - Every **60 minutes**, a summary report is emailed to stakeholders.  
   - Every **15 minutes**, an **instant alert** is triggered if material loss exceeds **5%** for any production order.  
6. **System Logs & Error Handling**:
   - Logs are generated for successful and failed executions.
   - If an error occurs, an alert email with error details is sent to IT & Maintenance teams.
