# **Important notes**
- This repository serves as a reference for the development, design, and operation of internal systems while showcasing expertise in IT System Development.
- The data and documentation are **simulated** based on real-world experience,
**does not contain confidential or sensitive information**.
---
# Branch Data Automation

## Situation
Automatically collects data from branches, securely transfers it to the central system, updates Power BI reports, and sends email notifications. The system helps IT manage operations, simplifies data analysis, and ensures smooth performance.
---

## Action

### **Scheduled Execution**: Python script runs every 15 minutes via Task Scheduler.
### **Data Extraction**: Connects to SQL Server (SQLAlchemy/pyodbc) to fetch data.
### **Data Conversion**: Processes and formats data into CSV.
### **Data Upload**: Transfers CSV to the central warehouse via SFTP.
### **Power BI Refresh**: Triggers Power BI API to update reports.
### **Email Notifications**: Sends success/error emails with details.

---

##  Result - Outcomes

### **Reliable Automation**: Ensures timely and consistent data extraction and processing.
### **Secure Data Transfer**: Maintains data integrity and security via VPN and SFTP.
### **Real-time Insights**: Keeps Power BI reports updated for accurate decision-making.
### **Operational Efficiency**: Reduces manual workload for IT and data teams.
Proactive Monitoring: Email alerts provide quick issue detection and resolution.