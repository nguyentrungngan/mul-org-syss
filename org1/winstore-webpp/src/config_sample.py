class Config:
    SQLALCHEMY_DATABASE_URI = 'mysql://username:password@localhost/your_database'
    SQLALCHEMY_TRACK_MODIFICATIONS = False
    JWT_SECRET_KEY = 'your_secret_key'
