import requests
import os

class PowerBIRefresh:
    def trigger_refresh(self):
        url = f"https://api.powerbi.com/v1.0/myorg/groups/{os.getenv('POWERBI_GROUP')}/datasets/{os.getenv('POWERBI_DATASET')}/refreshes"
        headers = {"Authorization": f"Bearer {os.getenv('POWERBI_ACCESS_TOKEN')}"}
        response = requests.post(url, headers=headers)
        return response.json()