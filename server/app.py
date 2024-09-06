from fastapi import FastAPI, Request
from fastapi.responses import JSONResponse
from api import router
from time import time
from core.exceptions.base import CustomException
from asyncio import create_task


def init_routers(app_: FastAPI) -> None:
    app_.include_router(router, prefix="/api")


def init_listeners(app_: FastAPI) -> None:
    @app_.exception_handler(CustomException)
    async def custom_exception_handler(request: Request, exc: CustomException):
        return JSONResponse(
            status_code=exc.code,
            content={"error_code": exc.error_code, "message": exc.message},
        )


def init_middlewares(app_: FastAPI) -> None:
    @app_.middleware("http")
    async def add_process_time_header(request: Request, call_next):
        start_time = time()
        response = await call_next(request)
        process_time = time() - start_time
        response.headers["X-Process-Time"] = str(process_time)
        return response


#async def init_bg_scheduler():
#    bg_scheduler = BgScheduler()
#    await bg_scheduler.register_tasks()
#    bg_scheduler.run_worker_test()
#    await bg_scheduler.run_worker()

def create_app() -> FastAPI:
    app_ = FastAPI()
    init_routers(app_)
    init_listeners(app_)
    init_middlewares(app_)
    return app_


app = create_app()


async def init_models():
    from app import models  # ignore unused import statement warning
    from core.database.base import Base
    from core.database.session import engine
    async with engine.begin() as conn:
        #await conn.run_sync(Base.metadata.drop_all)     # uncomment it if you want to drop the database. AT YOUR RISK!!!
        await conn.run_sync(Base.metadata.create_all)


@app.on_event("startup")
async def on_startup():
    await init_models()
#    await init_bg_scheduler()
#TODO implement adequate event scheduler     
