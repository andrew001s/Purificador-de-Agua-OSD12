from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
import joblib
import httpx
from datetime import datetime
from sklearn.preprocessing import StandardScaler
import numpy as np
from fastapi.middleware.cors import CORSMiddleware
# Cargar el modelo de aprendizaje automático
sc = StandardScaler()
gb = joblib.load('modelo_gb.pkl')

# Inicializar la aplicación FastAPI
app = FastAPI()
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)
# Definir el modelo de datos para los datos de calidad de agua
class WaterData(BaseModel):
    ciudad: str
    ph: float
    hardness: float
    solids: float
    sulfate: float
    turbidity: float
    Potability: int
    date: str

@app.get("/api")
async def get_data():
    try:
        async with httpx.AsyncClient(verify=False) as client:
            response = await client.get('https://localhost:44322/api/WaterData')
            if response.status_code == 200:
                jsondat = response.json()
                # Convertir valores numéricos de numpy.int64 a tipos de datos nativos de Python
              
                # Agregar el campo Potability al diccionario jsondat
                #jsondat["Potability"] = 0  # Puedes asignar cualquier valor inicial aquí
                # Crear una instancia del modelo de datos WaterData
                
                valores_numericos = [valor for valor in jsondat.values() if isinstance(valor, (int, float))]
                valores_numericos_escalados = sc.fit_transform([valores_numericos])
                resultado = gb.predict(valores_numericos_escalados)
                jsondat["Potability"] = resultado[0]
                for key, value in jsondat.items():
                    if isinstance(value, np.int64):
                        jsondat[key] = int(value)
                water_data_instance = WaterData(**jsondat)
                await enviar_datos_por_post(jsondat)
                response_data = dict(jsondat)
                return response_data
            else:
                return {"message": "a"}
    except Exception as e:
        return {"message": f"An error occurred: {str(e)}"}


# Función para enviar los datos procesados a otra API
async def enviar_datos_por_post(datos: dict):
    try:
        async with httpx.AsyncClient(verify=False) as client:
            # Crear una instancia del modelo de datos WaterData
            water_data_instance = WaterData(**datos)
            # Enviar los datos a la otra API
            response = await client.post('https://localhost:44389/api/WaterControllerr', json=water_data_instance.dict())
            response.raise_for_status()  # Lanzar una excepción para códigos de estado 4xx o 5xx
    except httpx.HTTPError as e:
        # Manejar errores HTTP
        raise HTTPException(status_code=e.response.status_code, detail=str(e))
