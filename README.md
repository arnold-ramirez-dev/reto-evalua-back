PASOS PARA LEVANTAR APLICACION
==============================

1. Ejecutar script: reto.sql

2. Configurar el appsettings.json con el connectionstring correspondiente:
  "ConnectionStrings": {
    "DefaultConnection": "Server=; Database=; User Id=; Password=;trustServerCertificate=true"
  }

3. Levantar solucion de .Net

4. Testear endpoints en swagger (si se escoge http: http://localhost:5030/swagger/index.html)
