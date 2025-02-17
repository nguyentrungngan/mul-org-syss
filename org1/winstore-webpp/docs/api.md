# API Documentation 

## API Overview
The system provides a RESTful API for managing and approving the data of display store. All endpoints require authentication and role-based access control.

## Authentication
- **Endpoint:** `/org1/winstore-webapp/login`
- **Method:** `POST`
- **Request Body:**
  ```json
  {
    "username": "string",
    "password": "string"
  }
  ```
- **Response:**
  ```json
  {
    "token": "string"
  }
  ```
### Get display store
- **Endpoint:** `/org1/winstore-webapp/displaystore`
- **Method:** `GET`
- **Response:**
  ```json
  [
    {
      "store_id": 1,
      "store_name": "string",
      "location": "string",
      "displays":[
        {
          "display_id":10,
          "display_name":"string",
          "image_id":100,
          "ftp_path":"string",
          "upload_timestamp":"timestamp",
          "approve_status":true
        },
        {
          "display_id":10,
          "display_name":"string",
          "image_id":101,
          "ftp_path":"string",
          "upload_timestamp":"timestamp",
          "approval_status":false
        },
      ]
    }
  ]
  ```
### Create Display approval
- **Endpoint:** `/org1/winstore-webapp/displayapproval`
- **Method:** `POST`
- **Request Body:**
  ```json
    {
      "store_id": 1,
      "display_id":10,
      "approval_status":true,
      "approver":"string",
      "approval_timestamp":"timestamp"
    }
  ```
### Upload Image
- **Endpoint:** `/org1/winstore-webapp/displayupload`
- **Method:** `POST`
- **Request Body:**
  ```json
  {
    "display_id": 1,
    "image_id":102,
    "ftp_path": "string",
    "upload_timestamp": "timestamp",
    "user_id":"string",
    "approval_status":false
  }
  ```
- **Rate Limit:** 10 requests per minute per IP

## Security Measures
- **Token-based authentication** for all requests.
- **Role-based access control** to restrict actions.
- **HTTPS encryption** for secure data transmission.
- **Rate limiting** (10 requests per minute per IP) to prevent abuse.

