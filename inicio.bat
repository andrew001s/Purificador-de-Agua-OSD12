
docker.exe docker-compose up -d
python.exe -m pip install fastapi uvicorn httpx scikit-learn
python.exe -m uvicorn main:app --reload
