# Workflow 

## **User Workflow**
1. **User Authentication**
   - Sales staff log in using credentials.
   - Authentication is handled via API (JWT-based authentication).
   
2. **Store Selection**
   - User selects the target store from a list.
   - Store details are retrieved from the ERP system.
   
3. **Image Upload Process**
   - User uploads display images via the frontend.
   - Images are validated (format, size, resolution).
   - Images are stored in the internal FTP server.
   
4. **Metadata Storage**
   - After a successful upload, metadata is generated.
   - Metadata (sequence, FTP path, timestamp, uploader ID, display ID, store ID) is stored in MySQL.
   
5. **Data Synchronization**
   - API sends metadata to the ERP system for processing.
   - ERP updates store records accordingly.
   
## **System Workflow**
1. **Frontend Operations (ReactJS/Next.js)**
   - Handles user authentication and session management.
   - Provides UI for store selection and image uploads.
   - Sends requests to the backend for processing.
   
2. **Backend Operations (Flask/FastAPI)**
   - Validates and processes user requests.
   - Stores metadata in MySQL.
   - Communicates with the ERP system via API.
   
3. **Storage Workflow**
   - Images are uploaded and stored on an internal FTP server.
   - The FTP path is logged in the database.
   
4. **API Integration**
   - The backend API synchronizes metadata with the ERP system.
   - Ensures data consistency between internal systems.
   
## **Automation & Optimization**
- **Asynchronous Processing**
  - Image uploads and metadata updates are handled asynchronously.
  
- **Error Handling & Logging**
  - All operations are logged for debugging and tracking.
  - Failure notifications are sent to administrators.
  
- **Security Measures**
  - Role-based access control (RBAC) ensures only authorized users can upload images.
  - Data transmission is secured via HTTPS and authentication tokens.

