# Architecture  

## System Overview  
The system is designed to facilitate the creation, approval, and tracking of request templates for payments, expenses, and purchases across headquarters and branches. It follows a modular architecture for scalability and maintainability within a Windows LAN environment while ensuring seamless integration between branch applications and the centralized ERP system.

## Components  
1. **Frontend (Windows Forms - VB.NET)**  
   - Deployed across all company branches.  
   - Provides a user-friendly interface for employees.  
   - Supports request template creation and submission.  
   - Restricts modifications based on approval status.  

2. **Backend (ASP.NET Web API - VB.NET)**  
   - Handles API requests and business logic.  
   - Assigns unique sequential IDs to templates.  
   - Manages approval workflow and access control.  
   - Processes reporting data for audits.  
   - Facilitates communication with the ERP system via Web API.  

3. **Database (Microsoft SQL Server - Branch Level)**  
   - Stores request template data locally at each branch, including:  
     - Template ID (Unique sequential number)  
     - Request type (Payment, Expense, Purchase)  
     - Creator ID & Timestamp  
     - Approval status & Approver ID  
     - Modification history  
     - Print status  

4. **Authentication**    
   - Supports role-based access control (RBAC).  

5. **Integration (ERP System via Web API Query - Centralized Database)**  
   - **For purchase requests:**  
     - The system **queries the ERP Web API** for **approved part/item lists** (with part numbers and detailed descriptions).  
     - Ensures purchase requests align with pre-approved ERP inventory.  
   - **For other request types:**  
     - Only requires general descriptions without ERP validation.  

## Data Flow  

1. User logs in via Windows Authentication at a branch location.  
2. Creates a new request template.  
3. System assigns a unique sequential ID.  
4. For purchase requests, system queries the **centralized ERP Web API** for valid items.  
5. User modifies and submits for approval.  
6. Manager reviews and approves the request.  
7. Once approved, the template becomes read-only.  
8. If changes are required, approval must be revoked.  
9. Approved templates are available for printing.  
10. Weekly reports are generated for audit tracking.  

## Scalability & Performance Considerations  
- **Distributed deployment**: Frontend applications run at branch level, minimizing central system load.  
- **Optimized Web API queries** to the ERP system to avoid unnecessary data transfers.  
- **Local caching** for frequently queried ERP data to improve performance.  

## Security Measures  
- **Role-based access control (RBAC)** to restrict sensitive actions.  
- **Audit logs & tracking** to monitor template creation and approval history.  
- **Secure API communication** with ERP using authentication tokens and HTTPS.  
