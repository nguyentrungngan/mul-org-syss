import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { login } from './app';
import WinStoreService from './services/winstoreService';


const LoginPage = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const result = await login(username, password);
      console.log('Login successful:', result);
      // Direct to DisplayStoresPage
      navigate({WinStoreService.DISPLAY_STORE_URL});
    } catch (err) {
      setError('Login failed!');
    }
  };

  return (
    <div>
      <h2>Login</h2>
      <input
        type="text"
        placeholder="Username"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />
      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button onClick={handleLogin}>Login</button>
      {error && <p>{error}</p>}
    </div>
  );
};

export default LoginPage;
