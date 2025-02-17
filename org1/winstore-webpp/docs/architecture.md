# Architecture

## System Overview
The system is designed to facilitate the uploading, storage, and synchronization of display images from sales staff to the ERP system. It follows a microservices-based architecture for scalability and maintainability.

## Components
1. **Frontend (ReactJS - Next.js)**
   - Provides a user-friendly interface for sales staff.
   - Handles authentication and store selection.
   - Facilitates image uploads.

2. **Backend (Python - Flask/FastAPI)**
   - Manages API requests and responses.
   - Processes image metadata and stores it in the database.
   - Handles communication with the ERP system.

3. **Database (MySQL)**
   - Stores image metadata, including:
     - Image sequence
     - FTP storage path
     - Upload timestamp
     - Uploader ID
     - Display ID
     - Store ID

4. **Storage (Internal FTP Server)**
   - Stores uploaded images securely.
   - Provides file paths for metadata storage.
   
5. **Integration (ERP System via API)**
   - Synchronizes metadata with the ERP system.
   - Ensures accurate tracking and reporting of display images.

## Data Flow
1. Sales staff logs in and selects the store.
2. Uploads actual display images.
3. Images are stored on the internal FTP server.
4. Metadata is recorded in MySQL.
5. API synchronizes metadata with the ERP system.

## Scalability & Performance Considerations
- **Microservices-based architecture** for modular scalability.

## Security Measures
- **Role-based access control** to restrict sensitive actions.
- **HTTPS & Secure API authentication** to protect data transmission.
- **Logging & monitoring** for tracking uploads and system performance.

