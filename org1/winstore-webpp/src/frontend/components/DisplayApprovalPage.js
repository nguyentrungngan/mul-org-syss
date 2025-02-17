import React, { useState } from 'react';
import { approveDisplay } from './app';

const DisplayApprovalPage = ({ token, storeId, displayId, approver }) => {
  const [approvalStatus, setApprovalStatus] = useState(false);
  const [error, setError] = useState('');

  const handleApproval = async () => {
    try {
      const result = await approveDisplay(token, storeId, displayId, approver);
      console.log('Approval successful:', result);
      setApprovalStatus(true);
      //Do something


        
      ////////////////////
    } catch (err) {
      setError('Approval failed!');
      console.error('Error approving display:', err);
    }
  };

  return (
    <div>
      <h2>Approve Display</h2>
      <p>Store ID: {storeId}</p>
      <p>Display ID: {displayId}</p>
      <p>Approver: {approver}</p>
      <p>Status: {approvalStatus ? 'Approved' : 'Not Approved'}</p>
      <button onClick={handleApproval} disabled={approvalStatus}>
        {approvalStatus ? 'Approved' : 'Approve Display'}
      </button>
      {error && <p>{error}</p>}
    </div>
  );
};

export default DisplayApprovalPage;
