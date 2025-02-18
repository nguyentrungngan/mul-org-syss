# Frontend - Installation & Deployment Guide

## 1. Purpose
The **PrintTemplate Frontend** is a Windows application following the **Model-View-Controller (MVC)** pattern. It interacts with the backend via RESTful APIs for user authentication, template management, and ERP integration.

## 2. Main Features
- **User Authentication**: Login interface and session management.
- **Template Management**: Create, edit, and submit print templates for approval.
- **ERP Data Retrieval**: Fetch item details from the ERP system.
- **Audit Logging**: Track user actions and system logs.
- **API Communication**: Call backend APIs to process data.

## 3. Installation Guide

### Step 1: Clone & Set Up the Project
1. Clone the repository:
   ```sh
   git clone LAN://your-repository-url
   ```
2. Open the Visual Studio Solution (PrintTemplate-winapp.sln).
3. Build the project using Build > Build Solution (Ctrl + Shift + B).

### Step 2: Configure API Endpoints
Modify the backend API base URL in the frontend configuration file (e.g., app.config or settings.json):
{
  "ERPSystem": {
      "BaseUrl": "http://org2-printtemplate-winapp/",
      "Timeout": "30",
      "AUTH_URL":"/login",
      "TEMPLATE_URL":"/templates"
  },
  "AppSettings": {
    "JwtSecret": "your-secret-key",
    "TokenExpiration": "1h"
  }
}

### Step 3: Configure Environment Variables
1. Create a .env file or set environment variables for sensitive data:
```
    SECRET_KEY=your_secret_key
    TOKEN_EXPIRE="your-mintes"
    BASE_URL=https://org2.domain.com/printtemplate-winapp
    AUTH_URL=/login
    TEMPLATE_URL=/templates
```
### Step 5: Deploy to Production (Optional)

1. Publish via Visual Studio: Right-click the project and select Publish.
2. Deploy as an EXE: Package the frontend as a Windows executable for distribution.

### Step 6: Run Application on user machine 
1. Send user guide for users
2. Login with valid credentials to access the dashboard.
3. The application will interact with the backend APIs.
