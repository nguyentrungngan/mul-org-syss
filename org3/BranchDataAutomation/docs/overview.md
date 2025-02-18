# Application Overview

## Name  
**BranchDataAutomation**

## Purpose  
BranchDataAutomation is designed to **automate the extraction of data** from SQL Server databases at various branch locations, process the data, and upload it to a central data warehouse. The system ensures secure data transfer over VPN, generating CSV files, and triggering automatic updates for Power BI. Email notifications are sent to the internal team for log updates, errors, or successful data processing.

## Key Features  
- **Data Extraction**: Automatically connects to SQL Server databases at branch locations to extract data at regular intervals.
- **Secure Data Transfer**: Utilizes VPN for secure communication between branch databases and the central server.
- **Data Processing**: Converts extracted data into structured CSV format for easy upload to the central data warehouse.
- **Power BI Integration**: Triggers automatic updates for Power BI dashboards based on the newly uploaded data.
- **Email Notifications**: Sends log notifications to the internal team for system activity, including successful data extraction, processing, and errors encountered during execution.

## Target Users  
- **IT Operations Team**: Manage the backend processes, ensure secure data transfer, and monitor system performance.
- **Data Analysts**: Analyze data processed by the system and create reports using Power BI.
- **Internal Team**: Receive email notifications about system logs, errors, and successful executions.
- **System Admins**: Configure and maintain the VPN, SQL Server connections, and ensure the smooth operation of the automation script.

