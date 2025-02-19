# System Overview

## Name  
**MaterialLossMonitor**

## Purpose  
MaterialLossMonitor is designed to **automate the monitoring and reporting of material loss** during the cutting/stamping process. The system synchronizes data from PLC, MES, and FTP, calculates material loss, stores reports on FTP, and sends alert emails periodically to ensure real-time tracking and corrective actions.

## Key Features  
- **Data Synchronization**: Automatically fetches data every 15 minutes from:
  - **PLC via Modbus TCP** (Real-time measurement data).
  - **MES System** (Planned material issuance and active production orders via SQL Server queries).
  - **FTP Server (MES)** (Structured files containing **Production Order & Actual Material Issued** by machine operators).
- **Material Loss Calculation**:
  - Integrates data from **MES, FTP, and PLC**.
  - Computes material loss using the formula:
    
    {A} = ({Material Issued on MES} + {Material Issued on FTP})/2 - {Actual from PLC}
    {B} = ({Material Issued on MES} + {Material Issued on FTP})/2
    {Material Loss} = ({A} / {B}) * 100%
    
- **Automated Reporting**:
  - Stores reports in an FTP directory for review.
  - **Sends summary emails every 60 minutes** with material loss statistics.
  - **Triggers instant alerts (every 15 minutes) if material loss exceeds 5%** for any material issuance record of a Production Order.

## Target Users  
- **Production Managers**: Monitor material efficiency and reduce losses.
- **Machine Operators**: Track real-time material issuance and adjustments.
- **IT & Maintenance Teams**: Ensure system stability and data integrity.
- **Quality Control**: Evaluate production process efficiency and detect inconsistencies.


