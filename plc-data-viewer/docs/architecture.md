# **Important notes**
- This repository serves as a reference for the development, design, and operation of internal systems while showcasing expertise in IT System Development.
- The data and documentation are **simulated** based on real-world experience,
**does not contain confidential or sensitive information**.
---
# architecture
---
## System Overview

1. plc-data-collector: Fetches data from PLC machines and sends it to storage.
2. plc-data-viewer: Displays collected data in simple interface.

```

	[PLC Machine] → [Data Collection Program] → [Middleware Application] → [Database] → [User Interface]

```

---

## Technologies Used
1. Data Collection Program: Reads data from PLC machines.
2. Middleware Application: Receives and stores data.
3. Database: Ensures structured data storage.
4. User Interface: Provides easy access to real-time information.

---

## Operational Workflow
1. The PLC machine sends data to the system.
2. The middleware processes and stores the data.
3. Employees access the data via a simple user interface.
  


