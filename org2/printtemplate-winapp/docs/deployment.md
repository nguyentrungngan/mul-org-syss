## **Deployment on Windows** 

### **1. Window application & API Deployment**
- **VB.NET WEB API** runs on Windows using IIS.
- **VB.NET window form** is deployed using Node.js.
- **SQL Server** installed locally for metadata storage.

### **2. Static WAN IP Configuration**
- A static WAN IP is configured on the router.
- The internal application is exposed via this WAN IP.
- Domain name mapping (optional) via Dynamic DNS if static IP is unavailable.

### **3. Windows Firewall Configuration**
- Allow inbound rules for:
  - HTTP/HTTPS (80, 443) for frontend access.
  - API service port (3000 for WEB API).
- Restrict access to trusted IPs where necessary.

### **4. Port Forwarding**
- Router configuration to forward external requests:
  - WAN IP:80 → Internal IP:3000 (Frontend)
  - WAN IP:443 → Internal IP:5000 (API Backend)

### **5. Installation Guide**
#### **Install Required Software**
1. **Install Frontend**
   
   Use readme_frontend.md at `/org2/printtemplate-winapp/src/frontend` path

2. **Install Backend**

   Use readme_backend.md at `/org2/printtemplate-winapp/src/backend` path

### **6. Final Testing**
- Test API endpoints via `http://WAN_IP:5000/docs`.

### **7. Security Enhancements**
- Enforce **SSL/TLS** for secure communication.

