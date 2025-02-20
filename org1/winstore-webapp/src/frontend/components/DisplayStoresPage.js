import React, { useState, useEffect } from 'react';
import { getDisplayStores } from './app';

const DisplayStoresPage = ({ token }) => {
  const [stores, setStores] = useState([]);

  useEffect(() => {
    const fetchStores = async () => {
      try {
        const result = await getDisplayStores(token);
        setStores(result);
      } catch (err) {
        console.error('Error fetching stores:', err);
      }
    };

    fetchStores();
  }, [token]);

  return (
    <div>
      <h2>Display Stores</h2>
      <ul>
        {stores.map((store) => (
          <li key={store.id}>{store.name}</li>
        ))}
      </ul>
    </div>
  );
};

export default DisplayStoresPage;