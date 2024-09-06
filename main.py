from uvicorn import run
from core.config.config import config


if __name__ == "__main__":
    run(
        app="server.app:app",
        host=config.HOST,
        port=config.PORT
    )
