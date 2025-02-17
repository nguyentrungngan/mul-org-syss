from pydantic import BaseSettings

class Settings(BaseSettings):
    DATABASE_URL: str
    SECRET_KEY: str

    class Config:
        env_file = ".env"

settings = Settings()
class Config:
    SQLALCHEMY_DATABASE_URI = 'mysql://username:password@localhost/your_database'
    SQLALCHEMY_TRACK_MODIFICATIONS = False
    JWT_SECRET_KEY = 'your_secret_key'
    DEBUG = True
    HOST = "0.0.0.0"
    PORT = 5000

