import paramiko
import os

class DataUpload:
    def transfer(self, data):
        with open("data.csv", "w") as f:
            f.write("\n".join([str(row) for row in data]))
        
        client = paramiko.SSHClient()
        client.set_missing_host_key_policy(paramiko.AutoAddPolicy())
        client.connect(os.getenv("SFTP_SERVER"), username=os.getenv("SFTP_USER"), password=os.getenv("SFTP_PASSWORD"))
        sftp = client.open_sftp()
        sftp.put("data.csv", os.getenv("SFTP_REMOTE_PATH"))
        sftp.close()
        client.close()