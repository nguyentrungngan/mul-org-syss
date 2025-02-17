# Database Design 

## Database Overview
The system uses MySQL to store image metadata and ensure seamless synchronization with the ERP system. The database is optimized for fast retrieval and secure storage.

## Tables & Schema

### **1. Users Table**
Stores user authentication and role information.
```sql
CREATE TABLE users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role ENUM('admin', 'sales', 'viewer') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

### **2. Stores Table**
Maintains store details.
```sql
CREATE TABLE stores (
    store_id INT PRIMARY KEY AUTO_INCREMENT,
    store_name VARCHAR(100) NOT NULL,
    location VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

### **3. Displays Table**
Tracks display sessions linked to stores and users.
```sql
CREATE TABLE displays (
    display_id INT PRIMARY KEY AUTO_INCREMENT,
    store_id INT NOT NULL,
    user_id INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);
```

### **4. Images Table**
Stores metadata of uploaded images.
```sql
CREATE TABLE images (
    image_id INT PRIMARY KEY AUTO_INCREMENT,
    display_id INT NOT NULL,
    ftp_path VARCHAR(255) NOT NULL,
    upload_timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (display_id) REFERENCES displays(display_id)
);
```

### **5. Sync Logs Table**
Tracks metadata synchronization with the ERP system.
```sql
CREATE TABLE sync_logs (
    log_id INT PRIMARY KEY AUTO_INCREMENT,
    image_id INT NOT NULL,
    status ENUM('pending', 'successful', 'failed') DEFAULT 'pending',
    synced_at TIMESTAMP NULL,
    FOREIGN KEY (image_id) REFERENCES images(image_id)
);
```

## Indexing & Optimization
- Indexes on `store_id`, `user_id`, `display_id`, and `image_id` for faster queries.
- Foreign keys to enforce referential integrity.

## Backup & Recovery
- **Daily backups** to prevent data loss.
- **Replication setup** for high availability.
- **Point-in-time recovery** enabled for MySQL.

## Security Considerations
- **Role-based access control** on MySQL users.
- **SSL encryption** for database connections.
- **Regular audits** to monitor unauthorized access.

