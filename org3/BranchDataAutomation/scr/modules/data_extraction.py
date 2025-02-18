import pyodbc
import os

class DataExtraction:
    def fetch(self):
        conn = pyodbc.connect(
            f"DRIVER={{SQL Server}};SERVER={os.getenv('DB_SERVER')};DATABASE={os.getenv('DB_NAME')};UID={os.getenv('DB_USER')};PWD={os.getenv('DB_PASSWORD')}"
        )
        cursor = conn.cursor()
        cursor.execute("SELECT * FROM your_table")
        data = cursor.fetchall()
        conn.close()
        return data