import schedule
import time
import os
from dotenv import load_dotenv
from modules.scheduled_execution import ScheduledExecution
from modules.data_extraction import DataExtraction
from modules.data_conversion import DataConversion
from modules.data_upload import DataUpload
from modules.powerbi_refresh import PowerBIRefresh
from modules.email_notifications import EmailNotifications
from modules.vpn_connection import VPNConnection

def job():
    try:
        vpn = VPNConnection()
        vpn.connect()
        
        extractor = DataExtraction()
        raw_data = extractor.fetch()
        
        converter = DataConversion()
        structured_data = converter.transform(raw_data)
        
        uploader = DataUpload()
        uploader.transfer(structured_data)
        
        powerbi = PowerBIRefresh()
        powerbi.trigger_refresh()
        
        email = EmailNotifications()
        email.send(success=True)
        
        vpn.disconnect()
    except Exception as e:
        email = EmailNotifications()
        email.send(success=False, error=str(e))

scheduler = ScheduledExecution()
scheduler.run(job)

if __name__ == "__main__":
    while True:
        schedule.run_pending()
        time.sleep(60)