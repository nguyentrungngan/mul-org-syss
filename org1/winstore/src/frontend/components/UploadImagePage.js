import React, { useState } from 'react';
import { uploadImage } from './app';

const UploadImagePage = ({ token, displayId }) => {
  const [image, setImage] = useState(null);
  const [ftpPath, setFtpPath] = useState('');

  const handleImageChange = (e) => {
    setImage(e.target.files[0]);
  };

  const handleUpload = async () => {
    if (image && ftpPath) {
      try {
        const result = await uploadImage(token, displayId, image.id, ftpPath, 'user123');
        console.log('Image uploaded successfully:', result);
        //Do something


        
        ////////////////////
      } catch (err) {
        console.error('Error uploading image:', err);
      }
    }
  };

  return (
    <div>
      <h2>Upload Image</h2>
      <input type="file" onChange={handleImageChange} />
      <input
        type="text"
        placeholder="FTP Path"
        value={ftpPath}
        onChange={(e) => setFtpPath(e.target.value)}
      />
      <button onClick={handleUpload}>Upload</button>
    </div>
  );
};

export default UploadImagePage;
