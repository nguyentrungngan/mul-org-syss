import schedule
import time
from modules.data_synchronization import synchronize_data

def job():
    synchronize_data()

def schedule_execution():
    schedule.every(15).minutes.do(job)
    while True:
        schedule.run_pending()
        time.sleep(1)
