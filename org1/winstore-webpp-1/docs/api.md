# API Documentation 

## API Overview
The system provides a RESTful API for managing users, stores, displays, images, and synchronization logs. All endpoints require authentication and role-based access control.

## Authentication
- **Endpoint:** `/api/auth/login`
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

## Users API
### Create User
- **Endpoint:** `/api/users`
- **Method:** `POST`
- **Request Body:**
  ```json
  {
    "username": "string",
    "password": "string",
    "role": "admin|sales|viewer"
  }
  ```
- **Response:**
  ```json
  {
    "user_id": 1
  }
  ```

### Get Users
- **Endpoint:** `/api/users`
- **Method:** `GET`
- **Response:**
  ```json
  [
    {
      "user_id": 1,
      "username": "string",
      "role": "admin"
    }
  ]
  ```

## Stores API
### Create Store
- **Endpoint:** `/api/stores`
- **Method:** `POST`
- **Request Body:**
  ```json
  {
    "store_name": "string",
    "location": "string"
  }
  ```

### Get Stores
- **Endpoint:** `/api/stores`
- **Method:** `GET`
- **Response:**
  ```json
  [
    {
      "store_id": 1,
      "store_name": "string",
      "location": "string"
    }
  ]
  ```

## Displays API
### Create Display Session
- **Endpoint:** `/api/displays`
- **Method:** `POST`
- **Request Body:**
  ```json
  {
    "store_id": 1,
    "user_id": 1
  }
  ```

### Get Displays
- **Endpoint:** `/api/displays`
- **Method:** `GET`
- **Response:**
  ```json
  [
    {
      "display_id": 1,
      "store_id": 1,
      "user_id": 1,
      "created_at": "timestamp"
    }
  ]
  ```

## Images API
### Upload Image
- **Endpoint:** `/api/images`
- **Method:** `POST`
- **Request Body:**
  ```json
  {
    "display_id": 1,
    "ftp_path": "string"
  }
  ```
- **Rate Limit:** 10 requests per minute per IP

### Get Images
- **Endpoint:** `/api/images`
- **Method:** `GET`
- **Response:**
  ```json
  [
    {
      "image_id": 1,
      "display_id": 1,
      "ftp_path": "string",
      "upload_timestamp": "timestamp"
    }
  ]
  ```

## Sync Logs API
### Get Sync Logs
- **Endpoint:** `/api/sync-logs`
- **Method:** `GET`
- **Response:**
  ```json
  [
    {
      "log_id": 1,
      "image_id": 1,
      "status": "pending|successful|failed",
      "synced_at": "timestamp"
    }
  ]
  ```

## Security Measures
- **Token-based authentication** for all requests.
- **Role-based access control** to restrict actions.
- **HTTPS encryption** for secure data transmission.
- **Rate limiting** (10 requests per minute per IP) to prevent abuse.
- **Logging & monitoring** for suspicious activities.
- **Two-factor authentication (2FA) for admin access.**

