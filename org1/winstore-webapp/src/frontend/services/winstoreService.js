import axios from 'axios';
import dotenv from 'dotenv';

dotenv.config();

const API_BASE_URL = process.env.REACT_APP_API_URL;
const AUTH_URL = process.env.REACT_APP_AUTH_URL;
const DISPLAY_STORE_URL = process.env.REACT_APP_DISPLAY_STORE_URL;
const DISPLAY_APPROVAL_URL = process.env.REACT_APP_DISPLAY_APPROVAL_URL;
const DISPLAY_UPLOAD_URL = process.env.REACT_APP_DISPLAY_UPLOAD_URL;

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json'
  }
});

// Login function
export const login = async (username, password) => {
  try {
    const response = await api.post(AUTH_URL, { username, password });
    return response.data;
  } catch (error) {
    console.error('Login failed:', error.response?.data || error.message);
    throw error;
  }
};

// Get display stores
export const getDisplayStores = async (token) => {
  try {
    const response = await api.get(DISPLAY_STORE_URL, {
      headers: { Authorization: `Bearer ${token}` }
    });
    return response.data;
  } catch (error) {
    console.error('Fetching display stores failed:', error.response?.data || error.message);
    throw error;
  }
};

// Approve display
export const approveDisplay = async (token, storeId, displayId, approver) => {
  try {
    const response = await api.post(DISPLAY_APPROVAL_URL, {
      store_id: storeId,
      display_id: displayId,
      approval_status: true,
      approver,
      approval_timestamp: new Date().toISOString()
    }, {
      headers: { Authorization: `Bearer ${token}` }
    });
    return response.data;
  } catch (error) {
    console.error('Approval failed:', error.response?.data || error.message);
    throw error;
  }
};

// Upload image
export const uploadImage = async (token, displayId, imageId, ftpPath, userId) => {
  try {
    const response = await api.post(DISPLAY_UPLOAD_URL, {
      display_id: displayId,
      image_id: imageId,
      ftp_path: ftpPath,
      upload_timestamp: new Date().toISOString(),
      user_id: userId,
      approval_status: false
    }, {
      headers: { Authorization: `Bearer ${token}` }
    });
    return response.data;
  } catch (error) {
    console.error('Image upload failed:', error.response?.data || error.message);
    throw error;
  }
};
