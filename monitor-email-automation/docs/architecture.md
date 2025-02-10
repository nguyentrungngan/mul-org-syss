# **Important notes**
- This repository serves as a reference for the development, design, and operation of internal systems while showcasing expertise in IT System Development.
- The data and documentation are **simulated** based on real-world experience,
**does not contain confidential or sensitive information**.
---
# Monitor Email Automation
---
## System Architecture
- `plc_email_automation`: Reads and verifies data from PLCs, MES, and local shared files.
- Sends alerts via email if thresholds are exceeded based on configurable rules.

```plaintext
[PLC Data] + [MES Data] + [Manual Input Files]
      | 
      | (Monitored by Rules)
      v
[Alert System] → [Email Notifications to Admins & Managers]

```

## Technologies Used
- **C++**: Collects data from PLCs.
- **Python**: Processes data, applies rules, and handles email automation.
- **SQL Server**: Stores and retrieves monitored data.

## Workflow
1. The system fetches real-time data from PLCs, MES, and shared files.
2. Predefined rules analyze the collected data.
3. If a rule is violated, an email notification is triggered automatically.
4. Logs are recorded for audit purposes.
