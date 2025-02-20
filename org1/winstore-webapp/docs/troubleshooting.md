# Troubleshooting Guide

## Authentication Issues
### Issue: Invalid Credentials
**Symptoms:**
- Login request returns HTTP 401 Unauthorized.
- Response message: "Invalid username or password."

**Solutions:**
1. Verify that the username and password are correct.
2. Ensure that the credentials are being sent in the correct JSON format.
3. Check if the user account is locked or inactive.

### Issue: Token Expired
**Symptoms:**
- API returns HTTP 403 Forbidden after successful login.
- Response message: "Token expired. Please re-authenticate."

**Solutions:**
1. Obtain a new token by logging in again.
2. Ensure the token is included in the Authorization header for each request.

## Display Store Issues
### Issue: No Data Returned
**Symptoms:**
- The `/displaystore` endpoint returns an empty array.

**Solutions:**
1. Ensure that display store data exists in the database.
2. Check user role permissions to confirm access to the data.
3. Verify API authentication is correctly configured.

## Display Approval Issues
### Issue: Approval Not Updating
**Symptoms:**
- Sending a POST request to `/displayapproval` does not change approval status.

**Solutions:**
1. Verify the `store_id` and `display_id` are correct.
2. Ensure the approver has the necessary permissions.
3. Confirm that the request body follows the required JSON format.

## Image Upload Issues
### Issue: Image Upload Fails
**Symptoms:**
- The `/displayupload` endpoint returns an error.
- Response message: "Upload failed."

**Solutions:**
1. Ensure `display_id` exists and is valid.
2. Check that `ftp_path` is correctly formatted and accessible.
3. Verify the file size and format meet the requirements.
4. Ensure the API rate limit (10 requests per minute per IP) is not exceeded.

## General API Issues
### Issue: Rate Limit Exceeded
**Symptoms:**
- API returns HTTP 429 Too Many Requests.

**Solutions:**
1. Reduce the frequency of requests.
2. Implement exponential backoff for retry logic.
3. Contact support if higher request limits are required.

## Security Issues
### Issue: Unauthorized Access
**Symptoms:**
- API returns HTTP 403 Forbidden.

**Solutions:**
1. Ensure the correct authentication token is provided.
2. Verify that the user has the necessary role permissions.
3. Check for potential token expiration and renew if necessary.
