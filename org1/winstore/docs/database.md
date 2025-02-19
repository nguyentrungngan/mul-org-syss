# MySQL Database Structure

## Create Database and Tables

```sql
-- Create the database if not exists
CREATE DATABASE IF NOT EXISTS winstore;

-- Switch to the database
USE winstore;

-- Create Users table (Authentication)
CREATE TABLE IF NOT EXISTS users (
    user_id VARCHAR(255) PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    role ENUM('admin', 'user') NOT NULL,
    token VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create Stores table
CREATE TABLE IF NOT EXISTS store (
    store_id INT PRIMARY KEY AUTO_INCREMENT,
    store_name VARCHAR(255) NOT NULL,
    location VARCHAR(255) NOT NULL
);

-- Create Displays table
CREATE TABLE IF NOT EXISTS display (
    display_id INT PRIMARY KEY AUTO_INCREMENT,
    store_id INT,
    display_name VARCHAR(255) NOT NULL,
    image_id INT,
    ftp_path VARCHAR(255),
    upload_timestamp TIMESTAMP,
    approve_status BOOLEAN,
    FOREIGN KEY (store_id) REFERENCES store(store_id)
);

-- Create Images table
CREATE TABLE IF NOT EXISTS image (
    image_id INT PRIMARY KEY AUTO_INCREMENT,
    image_path VARCHAR(255) NOT NULL,
    upload_timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    uploaded_by VARCHAR(255) NOT NULL
);

-- Create Display Approvals table
CREATE TABLE IF NOT EXISTS display_approval (
    approval_id INT PRIMARY KEY AUTO_INCREMENT,
    store_id INT,
    display_id INT,
    approval_status BOOLEAN,
    approver VARCHAR(255),
    approval_timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (store_id) REFERENCES store(store_id),
    FOREIGN KEY (display_id) REFERENCES display(display_id)
);

-- Create Display Uploads table
CREATE TABLE IF NOT EXISTS display_upload (
    upload_id INT PRIMARY KEY AUTO_INCREMENT,
    display_id INT,
    image_id INT,
    ftp_path VARCHAR(255),
    upload_timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    user_id VARCHAR(255),
    approval_status BOOLEAN,
    FOREIGN KEY (display_id) REFERENCES display(display_id),
    FOREIGN KEY (image_id) REFERENCES image(image_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);
