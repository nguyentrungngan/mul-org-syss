from ftplib import FTP
from modules.config import FTP_SERVER, FTP_USER, FTP_PASS

def save_report_to_ftp(report):
    ftp = FTP(FTP_SERVER)
    ftp.login(FTP_USER, FTP_PASS)
    ftp.cwd('/reports')
    with open('report.txt', 'wb') as f:
        f.write(report.encode())
    ftp.quit()
