# **Important notes**
- This repository serves as a reference for the development, design, and operation of internal systems while showcasing expertise in IT System Development.
- The data and documentation are **simulated** based on real-world experience, **does not contain confidential or sensitive information**.

---

# architecture

---

## System Overview

1. Database Layer (SQL Server - Stored Procedures): Executes complex report queries and ensures structured data management.
2. Application Layer (Windows Form C# - Report Generator): Provides an intuitive UI for generating and exporting reports.
3. Integration Layer (ERP Configuration & Data Sync): Manages ERP connectivity and automates data synchronization.

```

[ERP System] → [Data Synchronization] → [SQL Server] → [Report Generator] → [User Interface]

```

---

## Technologies Used
1. SQL Server: Handles stored procedures and data filtering.
2. Windows Form C#: Provides a graphical interface for users.
3. ERP System: Ensures seamless integration and data retrieval.
4. PDF/Excel Export: Supports multiple reporting formats.

---

## Operational Workflow
1. The ERP system syncs data with the reporting system.
2. The report generator fetches and processes data.
3. Users generate reports through an interactive interface.
4. Reports are exported in PDF/Excel format for further analysis.

