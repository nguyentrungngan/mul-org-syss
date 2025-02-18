### API Design for Frontend Integration

#### Authentication & User Management

**1. User Login**
- **Endpoint:** `POST /printtemplate-winapp/login`
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
    "role": "Employee | Manager | Admin"
  }
  ```
- **Note:** Token will be handled by the Windows App using RBAC and stored locally.

**2. Get Current User Details**
- **Endpoint:** `GET /api/auth/me`
- **Headers:** Local token retrieval on Windows App.
- **Response:**
  ```json
  {
    "userID": 1,
    "username": "teo nguyen",
    "role": "Manager",
    "branchID": 5
  }
  ```

#### Request Template Management

**3. Create a New Request Template**
- **Endpoint:** `POST /printtemplate-winapp/templates`
- **Headers:** Local token retrieval on Windows App.
- **Request Body:**
  ```json
  {
    "requestType": "Purchase",
    "creatorID": 1,
    "items": [
      { "description": "Chair", "quantity": 1 }
    ]
  }
  ```
- **Response:**
  ```json
  {
    "templateID": 101,
    "status": "Pending"
  }
  ```

**4. Retrieve Request Templates**
- **Endpoint:** `GET /printtemplate-winapp/templates`
- **Headers:** Local token retrieval on Windows App.
- **Response:**
  ```json
  [
    {
      "templateID": 101,
      "requestType": "Purchase",
      "approvalStatus": "Pending",
      "createdAt": "2021-01-18T00:00:00Z"
    }
  ]
  ```

#### Approval Workflow

**5. Approve/Reject a Request Template**
- **Endpoint:** `PUT /printtemplate-winapp/{templateID}/approve`
- **Headers:** Local token retrieval on Windows App.
- **Request Body:**
  ```json
  {
    "approverID": 2,
    "status": "Approved"
  }
  ```
- **Response:**
  ```json
  {
    "message": "Request approved successfully"
  }
  ```

#### ERP Integration

**6. Query ERP for Valid Purchase Items**
- **Endpoint:** `GET /printtemplate-winapp/erp/items`
- **Headers:** Local token retrieval on Windows App.
- **Response:**
  ```json
  [
    { "partNumber": "ERP1234", "description": "Office Chair" },
    { "partNumber": "ERP5678", "description": "Monitor" }
  ]
  ```

#### Reporting & Audits

**7. Retrieve Audit Logs**
- **Endpoint:** `GET /printtemplate-winapp/audit/logs`
- **Headers:** Local token retrieval on Windows App.
- **Response:**
  ```json
  [
    {
      "logID": 1,
      "action": "Created Request Template",
      "performedBy": "teo nguyen",
      "timestamp": "2025-01-1T11:00:00Z"
    }
  ]
  ```
