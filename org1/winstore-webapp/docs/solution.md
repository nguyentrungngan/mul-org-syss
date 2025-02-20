# Solution

## Technical Stack
- **Frontend:** ReactJS (Next.js)
- **Backend:** Python (Flask/FastAPI)
- **Database:** MySQL (Stores image metadata)
- **Storage:** Internal FTP Server (Stores images)
- **Integration:** API connects with the ERP system

## Data Flow
1. Sales staff log in and select the store to update
2. Upload actual display images
3. Images are stored on the internal FTP server
4. Metadata (sequence, FTP path, upload time, uploader ID, display ID) is stored in MySQL
5. API sends metadata to the ERP system for synchronization
