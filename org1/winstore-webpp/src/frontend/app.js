import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginPage from './components/LoginPage';
import DisplayStoresPage from './components/DisplayStoresPage';
import DisplayApprovalPage from './components/DisplayApprovalPage';
import UploadImagePage from './components/UploadImagePage';
import { login, getDisplayStores, approveDiplay, uploadImage } from './services/apiService';
import WinStoreService from './services/winstoreService';

function App() {
  const [token, setToken] = useState(null);
  
  const handleLogin = async (username, password) => {
    try {
      const data = await login(username, password);
      setToken(data.token);
    } catch (error) {
      console.error("Login failed:", error);
    }
  };

  return (
    <Router>
      <Routes>
        <Route path={WinStoreService.AUTH_URL} element={<LoginPage onLogin={handleLogin} />} />
        <Route path={WinStoreService.DISPLAY_STORE_URL} element={<DisplayStoresPage token={token} />} />
        <Route path={WinStoreService.DISPLAY_APPROVAL_URL} element={<DisplayApprovalPage token={token} />} />
        <Route path={WinStoreService.DISPLAY_UPLOAD_URL} element={<UploadImagePage token={token} />} />
      </Routes>
    </Router>
  );
}

export default App;
