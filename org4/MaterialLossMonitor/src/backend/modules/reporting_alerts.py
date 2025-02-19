import smtplib
from email.mime.text import MIMEText
from modules.config import EMAIL_SMTP, EMAIL_USER, EMAIL_PASS

def send_email(subject, body, recipients):
    msg = MIMEText(body)
    msg['Subject'] = subject
    msg['From'] = EMAIL_USER
    msg['To'] = ", ".join(recipients)
    
    with smtplib.SMTP(EMAIL_SMTP) as server:
        server.login(EMAIL_USER, EMAIL_PASS)
        server.sendmail(msg['From'], recipients, msg.as_string())

def alert_on_material_loss(material_loss):
    if material_loss > 5:
        send_email("Instant Alert: Material Loss Exceeded", f"Material loss is {material_loss}%, which exceeds the threshold.", ['it_team@example.com'])

def generate_report(material_loss):
    return f"Material loss report: {material_loss}"
