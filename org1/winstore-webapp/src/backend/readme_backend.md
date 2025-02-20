# Backend - Installation & Deployment Guide

## 1. Purpose
The backend provides APIs for processing data within the system, including functionalities such as login, image data approval, and RESTful API for the frontend.

## 2. Main Features
- Handle login and user authentication (Login API).
- Manage image data (Display Store, Display Upload, Display Approval APIs).
- Synchronize logs (Sync Logs API).
- Provide RESTful API for the frontend (React, Vue, etc.).

## 3. Installation Guide
### Step 1: Create & Activate Virtual Environment

On Windows (CMD/Git Bash)
Download and Install Python: https://www.python.org/downloads/ then
```sh
	python -m venv venv
	venv\Scripts\activate

```
### Step 2: Install Required Packages
```sh
	pip install -r requirements.txt
```
### Step 3: Configure Environment Variables
Create an int.env file and set the required values:
```.env file

	DATABASE_URL=mysql+pymysql://user:password@localhost/your_database
	SECRET_KEY=mysecretkey
	HOST=127.0.0.1
	PORT=8000
```
### Step 4: Run Backend Server
```sh
	uvicorn main:app --host 0.0.0.0 --port 8000 --reload
```
### Step 5: Test API
Open your browser and access:
- API Docs: http://127.0.0.1:8000/docs
- Redoc API: http://127.0.0.1:8000/redoc
### Step 6: Deactivate Virtual Environment (If Needed)
```sh
	deactivate
```