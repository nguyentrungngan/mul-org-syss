class DataConversion:
    def transform(self, data):
        processed = [dict(zip([column[0] for column in data.description], row)) for row in data]
        return processed