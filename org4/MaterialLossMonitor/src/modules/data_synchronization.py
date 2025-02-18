from modules.data_processing import process_data
from modules.config import PLCS, MES_SERVER, MES_DB, MES_USER, MES_PASS, FTP_SERVER, FTP_USER, FTP_PASS
from pymodbus.client.sync import ModbusTcpClient
import pyodbc
from ftplib import FTP

def fetch_plc_data():
    data=[]
    for plc_ip in PLC_IPS:
        client = ModbusTcpClient(plc_ip)
        client.connect()
        result = client.read_holding_registers(0, 10)
        client.close()
        data.append(result.registers)
    return data

def fetch_mes_data():
    conn = pyodbc.connect(f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={MES_SERVER};DATABASE={MES_DB};UID={MES_USER};PWD={MES_PASS}')
    cursor = conn.cursor()
    cursor.execute("SELECT * FROM production_order WHERE order_id = ?;", (order_id,))
    result = cursor.fetchall()
    conn.close()
    return result

def fetch_ftp_data():
    ftp = FTP(FTP_SERVER)
    ftp.login(FTP_USER, FTP_PASS)
    ftp.cwd('/data')
    filenames = ftp.nlst()
    data = []
    for filename in filenames:
        with open(filename, 'wb') as file:
            ftp.retrbinary(f'RETR {filename}', file.write)
        data.append(filename)
    ftp.quit()
    return data

def synchronize_data():
    plc_data = fetch_plc_data()
    mes_data = fetch_mes_data()
    ftp_data = fetch_ftp_data()
    process_data(plc_data, mes_data, ftp_data)
