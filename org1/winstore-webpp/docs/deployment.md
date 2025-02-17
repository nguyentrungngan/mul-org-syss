## **Deployment on Windows** 

### **1. Web Server & API Deployment**
- **FastAPI backend** runs on Windows using Uvicorn.
- **Next.js frontend** is deployed using Node.js.
- **MySQL Server** installed locally for metadata storage.
- **FTP Server** (FileZilla Server) configured for image storage.

### **2. Static WAN IP Configuration**
- A static WAN IP is configured on the router.
- The internal application is exposed via this WAN IP.
- Domain name mapping (optional) via Dynamic DNS if static IP is unavailable.

### **3. Windows Firewall Configuration**
- Allow inbound rules for:
  - HTTP/HTTPS (80, 443) for frontend access.
  - API service port (e.g., 8000 for FastAPI).
  - MySQL (3306) if remote database access is needed.
  - FTP server ports (e.g., 21, passive ports 50000-51000).
- Restrict access to trusted IPs where necessary.

### **4. Port Forwarding**
- Router configuration to forward external requests:
  - WAN IP:80 → Internal IP:3000 (Frontend)
  - WAN IP:443 → Internal IP:3000 (Frontend with HTTPS)
  - WAN IP:8000 → Internal IP:8000 (API)
  - WAN IP:21 → Internal IP:21 (FTP Server)
  - WAN IP:50000-51000 → Internal IP:50000-51000 (FTP passive mode)

### **5. Installation Guide**
#### **Install Required Software**
1. **Install Frontend**
   
   Use readme_frontend.md at `/org1/winstore-webapp/src/frontend` path

2. **Install Backend**

   Use readme_frontend.md at `/org1/winstore-webapp/src/backend` path
   
3. **Install MySQL Server & Create Database**
   ```sql
   CREATE DATABASE image_metadata;
   CREATE USER 'appuser'@'%' IDENTIFIED BY 'password';
   GRANT ALL PRIVILEGES ON image_metadata.* TO 'appuser'@'%';
   FLUSH PRIVILEGES;
   ```

4. **Configure FTP Server (FileZilla Server)**
   - Install **FileZilla Server**.
   - Create a user and assign a home directory for image storage.
   - Enable passive mode with ports 50000-51000.
   - Configure firewall rules for FTP access.

### **6. Final Testing**
- Test access to the frontend via `http://WAN_IP`.
- Test API endpoints via `http://WAN_IP:8000/docs`.
- Verify image uploads to the FTP server.
- Ensure data synchronization with the ERP system.

### **7. Security Enhancements**
- Enforce **SSL/TLS** for secure communication.
- Use **strong passwords** and limit access to MySQL.

