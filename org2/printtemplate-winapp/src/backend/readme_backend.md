# Backend - Installation & Deployment Guide

## 1. Purpose
The backend of **PrintTemplate-winapp** provides APIs for managing user authentication, template data, approval workflows, and ERP system integration. It is designed to work with a Windows application that communicates through RESTful APIs.

## 2. Main Features
- **User Authentication**: Login API for managing user authentication.
- **Template Management**: APIs for creating, retrieving, and approving request templates.
- **ERP Integration**: APIs for querying items from the ERP system.
- **Audit Logs**: Tracks user actions and logs for security and troubleshooting.
- **Frontend Integration**: RESTful APIs accessible for frontend applications like React or Angular.

## 3. Installation Guide
### Step 1: Set Up the Project
1. Clone the repository:
  ```sh
      clone LAN://your-repository-url
  ```
2. Open the solution in Visual Studio (PrintTemplate-winapp.sln).

3. Build the project using the Build option in Visual Studio.

### Step 2: Configure Database
1. Set up the database in SQL Server.
2. Configure connection string in appsettings.json:

```
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=PrintTemplateDB;User Id=sa;Password=yourpassword-token;"
    },
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

```
### Step 3: Configure Environment Variables
1. Create a .env file or set environment variables for sensitive data:
```
    DATABASE_URL="Server=localhost;Database=PrintTemplateDB;User Id=sa;Password=yourpassword-token;"
    SECRET_KEY=your_secret_key
    TOKEN_EXPIRE="your-mintes"
    HOST=127.0.0.1
    PORT=5000
    BASE_URL=https://org2.domain.com/printtemplate-winapp
    AUTH_URL=/login
    TEMPLATE_URL=/templates
```
### Step 4: Run the Backend Server
1. Run the Application: Press F5 in Visual Studio to run the backend locally. This will launch the backend server using the IIS Express.

2. The backend will be accessible at http://localhost:5000.

### Step 5: Test API
You can use tools like Postman or cURL to test the API endpoints:

- Login API: POST {BASE_URL}/login
- Create Template API: POST {BASE_URL}/templates
- Get Template API: GET {BASE_URL}/templates/{id}

### Step 6: Deploy to Production (Optional)
To deploy the backend to a production server, you can publish the project from Visual Studio:
1. Publish via Visual Studio:
- Right-click the project in Visual Studio and select Publish.
- Choose the target environment (IIS, Azure, etc.) and follow the prompts to publish.

2. Configure IIS (if using IIS):
- Install IIS on the server and configure it to point to your published files.
- Ensure your server has the necessary environment variables set up.


