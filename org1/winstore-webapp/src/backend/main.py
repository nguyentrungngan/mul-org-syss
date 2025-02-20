from fastapi import FastAPI, HTTPException, Depends
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel
from typing import List, Optional
import uvicorn
import os
from dotenv import load_dotenv

# Load environment variables
load_dotenv(".env")

# FastAPI app initialization
app = FastAPI()

# Load environment variables
DATABASE_URL = os.getenv("DATABASE_URL")
SECRET_KEY = os.getenv("SECRET_KEY")
HOST = os.getenv("HOST", "127.0.0.1")
PORT = int(os.getenv("PORT", 8000))
FTP_URL = os.getenv("FTP_URL", "your-ftp-url")
FTP_USER = os.getenv("FTP_USER", "your-ftp-user")
FTP_PASS = os.getenv("FTP_PASS", "your-ftp-pass")
API_URL = os.getenv("API_URL", "/org1/winstore-webapp")  # Default nếu thiếu
AUTH_URL = os.getenv("AUTH_URL", "/login")
DISPLAY_STORE_URL = os.getenv("DISPLAY_STORE_URL", "/displaystore")
DISPLAY_UPLOAD_URL = os.getenv("DISPLAY_UPLOAD_URL", "/displayupload")
DISPLAY_APPROVAL_URL = os.getenv("DISPLAY_APPROVAL_URL", "/displayapproval")

# CORS middleware
origins = [
    "http://localhost",
    "http://localhost:8000",
    "http://localhost:3000",
]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# --- Models ---
class LoginRequest(BaseModel):
    username: str
    password: str

class DisplayInfo(BaseModel):
    display_id: int
    display_name: str
    image_id: int
    ftp_path: str
    upload_timestamp: str
    approval_status: bool

class StoreData(BaseModel):
    store_id: int
    store_name: str
    location: str
    displays: List[DisplayInfo]

class UploadRequest(BaseModel):
    display_id: int
    image_id: int
    ftp_path: str
    upload_timestamp: str
    user_id: str
    approval_status: bool = False

class ApprovalRequest(BaseModel):
    store_id: int
    display_id: int
    approval_status: bool
    approver: str
    approval_timestamp: str

# --- API Routes ---
@app.get("/")
def welcome():
    return {"message": "Welcome to the org1/winstore-webapp!", "API_URL": API_URL}

@app.post(f"{API_URL}{AUTH_URL}")
def login(request: LoginRequest):
    if request.username == "admin" and request.password == "password":
        return {"token": "fake-jwt-token"}
    raise HTTPException(status_code=401, detail="Invalid username or password")

@app.get(f"{API_URL}{DISPLAY_STORE_URL}", response_model=List[StoreData])
def get_display_store():
    sample_data = [
        {
            "store_id": 1,
            "store_name": "Store A",
            "location": "City Center",
            "displays": [
                {
                    "display_id": 10,
                    "display_name": "Screen 1",
                    "image_id": 100,
                    "ftp_path": "/images/100.jpg",
                    "upload_timestamp": "2025-01-01T10:00:00Z",
                    "approval_status": True
                }
            ]
        }
    ]
    return sample_data

@app.post(f"{API_URL}{DISPLAY_UPLOAD_URL}")
def upload_display(request: UploadRequest):
    return {
        "message": "Display uploaded successfully",
        "data": request.dict()
    }

@app.post(f"{API_URL}{DISPLAY_APPROVAL_URL}")
def approve_display(request: ApprovalRequest):
    return {
        "message": "Display approval status updated",
        "data": request.dict()
    }

# --- Run Application ---
if __name__ == "__main__":
    uvicorn.run(
        app,
        host=os.getenv("HOST", "127.0.0.1"),
        port=int(os.getenv("PORT", 8000)) 
    )
