
from dotenv import load_dotenv
import os

# Load environment variables from the .env file
load_dotenv()

# Database Configuration
DB_SERVER = os.getenv("DB_SERVER")
DB_NAME = os.getenv("DB_NAME")
DB_USER = os.getenv("DB_USER")
DB_PASSWORD = os.getenv("DB_PASSWORD")

# SFTP Server Configuration
SFTP_SERVER = os.getenv("SFTP_SERVER")
SFTP_USER = os.getenv("SFTP_USER")
SFTP_PASSWORD = os.getenv("SFTP_PASSWORD")
SFTP_REMOTE_PATH = os.getenv("SFTP_REMOTE_PATH")

# Power BI Configuration
POWERBI_GROUP = os.getenv("POWERBI_GROUP")
POWERBI_DATASET = os.getenv("POWERBI_DATASET")
POWERBI_ACCESS_TOKEN = os.getenv("POWERBI_ACCESS_TOKEN")

# Email Configuration
SMTP_SERVER = os.getenv("SMTP_SERVER")
SMTP_PORT = os.getenv("SMTP_PORT")
EMAIL_SENDER = os.getenv("EMAIL_SENDER")
EMAIL_PASSWORD = os.getenv("EMAIL_PASSWORD")
EMAIL_RECIPIENT = os.getenv("EMAIL_RECIPIENT")

# VPN Configuration
VPN_CONNECT_COMMAND = os.getenv("VPN_CONNECT_COMMAND")
VPN_DISCONNECT_COMMAND = os.getenv("VPN_DISCONNECT_COMMAND")
