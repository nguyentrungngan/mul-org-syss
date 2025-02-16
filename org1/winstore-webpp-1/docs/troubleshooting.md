# Troubleshooting Guide 

## Common Issues & Solutions

### 1. Authentication Failure
**Issue:** Login request returns `401 Unauthorized`.
**Possible Causes:**
- Incorrect username or password.
- Expired or invalid authentication token.

**Solution:**
- Verify username and password.
- Ensure the token is included in the `Authorization` header.
- If expired, request a new token using `/api/auth/login`.

---

### 2. User Creation Fails
**Issue:** `POST /api/users` returns `400 Bad Request`.
**Possible Causes:**
- Username already exists.
- Invalid role value provided.

**Solution:**
- Ensure the username is unique.
- Use a valid role (`admin`, `sales`, `viewer`).

---

### 3. Store Creation Issues
**Issue:** `POST /api/stores` returns `400 Bad Request`.
**Possible Causes:**
- Missing required fields (`store_name`, `location`).

**Solution:**
- Provide all required fields in the request body.

---

### 4. Display Session Not Found
**Issue:** `GET /api/displays/{id}` returns `404 Not Found`.
**Possible Causes:**
- Display session does not exist.

**Solution:**
- Verify the `display_id` is correct and exists in the database.

---

### 5. Image Upload Fails
**Issue:** `POST /api/images` returns `400 Bad Request`.
**Possible Causes:**
- Invalid `display_id` provided.
- FTP server connection issue.

**Solution:**
- Ensure the `display_id` exists in the `displays` table.
- Verify the FTP server is accessible and correctly configured.

---

### 6. Sync Logs Not Updating
**Issue:** `GET /api/sync-logs` does not return updated sync status.
**Possible Causes:**
- Sync job failed or has not been triggered.

**Solution:**
- Check sync job logs for errors.
- Manually trigger a sync if needed.

---

## Debugging Tips
- **Check API Logs:** Ensure API services are running and logs do not show errors.
- **Validate Database Entries:** Use SQL queries to confirm expected records exist.
- **Verify Network Connectivity:** Ensure the database and FTP server are reachable.

## Contact Support
If issues persist, gather logs and contact the support team with:
- Request payload and response.
- Relevant log entries.
- Steps to reproduce the issue.

