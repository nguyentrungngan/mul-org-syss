import logging

logging.basicConfig(filename='system.log', level=logging.INFO)

def log_error(error_message):
    logging.error(error_message)
    send_email("System Error", f"Error details: {error_message}", ['it_team@example.com'])

def log_success(message):
    logging.info(message)
