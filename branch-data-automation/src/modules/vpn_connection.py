import os

class VPNConnection:
    def connect(self):
        os.system(os.getenv("VPN_CONNECT_COMMAND"))
    
    def disconnect(self):
        os.system(os.getenv("VPN_DISCONNECT_COMMAND"))