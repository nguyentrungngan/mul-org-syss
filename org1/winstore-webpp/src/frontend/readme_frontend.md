# Frontend Application

## Purpose

This frontend application is designed to provide a user interface for the store and product management system. The application includes key functionalities such as login, managing display stores, approving requests, and uploading images.

It is built using React for the UI, Axios for API communication, and React Router for managing navigation between different pages.

## Key Features

- **Login**: Allows users to authenticate and access the system.
- **Display Stores Management**: Enables users to view and manage store displays.
- **Approval System**: Approves or rejects store display requests.
- **Image Upload**: Allows users to upload images to the system.

## Setup and Deployment

### Setup

1. **Install dependencies**:

   Download and Install Node.js: https://nodejs.org/en/download/

2. **Configure Environment Variables**:

   ```.env file
   REACT_APP_API_BASE_URL=<your-api-url>
   REACT_APP_SECRET_KEY=<your-secret-key>
   REACT_APP_AUTH_URL=<your-auth-url>
   REACT_APP_DISPLAY_STORE_URL=<your-display-store-url>
   REACT_APP_DISPLAY_APPROVAL_URL=<your-display-approval-url>
   REACT_APP_DISPLAY_UPLOAD_URL=<your-display-upload-url>

```
3. **Start Frontend**:
   ```
   npm run build
   npm start
   ```
The application will run on http://localhost:3000


