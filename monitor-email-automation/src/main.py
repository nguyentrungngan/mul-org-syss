import json
import smtplib
import psycopg2
from email.mime.text import MIMEText

#load config file
with open("config.json", "r") as f:
    config = json.load(f)

DB_CONFIG = config["database"]
EMAIL_CONFIG = config["email"]
RULES = config["rules"]
SHARING_DATA_PATH = config["sharing_data"]["path"]
MES_PATH = config["sharing_data"]["mes_path"]

# connect database
def get_db_connection():
    return psycopg2.connect(
        dbname=DB_CONFIG["dbname"],
        user=DB_CONFIG["user"],
        password=DB_CONFIG["password"],
        host=DB_CONFIG["host"],
        port=DB_CONFIG["port"]
    )

# query from sources
def fetch_data(source):
    conn = get_db_connection()
    cursor = conn.cursor()
    
    if source == "plc":
        query = "SELECT tag_name, value FROM plc_data WHERE timestamp >= NOW() - INTERVAL '1 hour';"
    elif source == "mes":
        query = "SELECT parameter_name, value FROM mes_data WHERE timestamp >= NOW() - INTERVAL '1 hour';"
    elif source == "manual":
        query = "SELECT field_name, value FROM manual_data WHERE timestamp >= NOW() - INTERVAL '1 hour';"
    else:
        return []

    cursor.execute(query)
    result = cursor.fetchall()
    
    cursor.close()
    conn.close()
    return result

# check rules
def check_rules():
    alerts = []
    for source in ["plc", "mes", "manual"]:
        data = fetch_data(source)
        for tag, value in data:
            if tag in RULES and value > RULES[tag]["threshold"]:
                alerts.append({
                    "rule": tag,
                    "source": source,
                    "value": value,
                    "threshold": RULES[tag]["threshold"]
                })
    return alerts

# send alers via email
def send_alert_email(alerts):
    if not alerts:
        return
    
    subject = "⚠️ PLC Automation Alert: Threshold Exceeded"
    body = "\n".join([f"[{a['source'].upper()}] {a['rule']}: {a['value']} > {a['threshold']}" for a in alerts])
    msg = MIMEText(body)
    msg["Subject"] = subject
    msg["From"] = EMAIL_CONFIG["sender"]
    msg["To"] = ", ".join(EMAIL_CONFIG["recipients"])

    with smtplib.SMTP(EMAIL_CONFIG["smtp_server"], EMAIL_CONFIG["smtp_port"]) as server:
        server.starttls()
        server.login(EMAIL_CONFIG["sender"], EMAIL_CONFIG["password"])
        server.sendmail(EMAIL_CONFIG["sender"], EMAIL_CONFIG["recipients"], msg.as_string())

# stores into database
def log_alerts(alerts):
    conn = get_db_connection()
    cursor = conn.cursor()
    
    for alert in alerts:
        cursor.execute(
            "INSERT INTO alert_logs (rule_name, source, value, threshold, status) VALUES (%s, %s, %s, %s, %s)",
            (alert["rule"], alert["source"], alert["value"], alert["threshold"], "triggered")
        )
    
    conn.commit()
    cursor.close()
    conn.close()

# run to check
def main():
    alerts = check_rules()
    if alerts:
        send_alert_email(alerts)
        log_alerts(alerts)

if __name__ == "__main__":
    main()
