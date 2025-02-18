import smtplib
from email.mime.text import MIMEText
import os

class EmailNotifications:
    def send(self, success, error=None):
        msg = MIMEText("Process completed successfully" if success else f"Process failed: {error}")
        msg["Subject"] = "Process Status"
        msg["From"] = os.getenv("EMAIL_SENDER")
        msg["To"] = os.getenv("EMAIL_RECIPIENT")
        
        server = smtplib.SMTP(os.getenv("SMTP_SERVER"), int(os.getenv("SMTP_PORT")))
        server.starttls()
        server.login(os.getenv("EMAIL_SENDER"), os.getenv("EMAIL_PASSWORD"))
        server.sendmail(os.getenv("EMAIL_SENDER"), os.getenv("EMAIL_RECIPIENT"), msg.as_string())
        server.quit()