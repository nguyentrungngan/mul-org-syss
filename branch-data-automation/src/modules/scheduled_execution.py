import schedule
import time

class ScheduledExecution:
    def run(self, job):
        schedule.every(15).minutes.do(job)