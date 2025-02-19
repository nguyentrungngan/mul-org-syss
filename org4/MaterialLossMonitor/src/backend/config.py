from dotenv import load_dotenv
import os

load_dotenv()

MES_SERVER = os.getenv("MES_SERVER")
MES_DB = os.getenv("MES_DB")
MES_USER = os.getenv("MES_USER")
MES_PASS = os.getenv("MES_PASS")
FTP_SERVER = os.getenv("FTP_SERVER")
FTP_USER = os.getenv("FTP_USER")
FTP_PASS = os.getenv("FTP_PASS")
EMAIL_SMTP = os.getenv("EMAIL_SMTP")
EMAIL_USER = os.getenv("EMAIL_USER")
EMAIL_PASS = os.getenv("EMAIL_PASS")

PLCS = {
    'PLC_1': {'ip': '192.168.0.100', 'port': 502},
    'PLC_2': {'ip': '192.168.0.101', 'port': 502},
    'PLC_3': {'ip': '192.168.0.102', 'port': 502},
    # ...
}
