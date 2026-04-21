# Calculadora de Comisiones de Ventas 

## Descripción General
Este sistema es una aplicación web diseñada para que los vendedores calculen sus comisiones mensuales de forma rápida y transparente, basándose en sus ventas totales, los descuentos aplicados y el país de operación.

## Reglas de Negocio
El sistema automatiza el cálculo aplicando la regla correspondiente a cada país:

* **Lógica General**: `Comisión = (Ventas Totales - Descuentos) * Tasa`
* **India**: Tasa del 10%.
* **Estados Unidos**: Tasa del 15%.
* **Reino Unido**: Tasa del 12%.

## Arquitectura del Sistema
Para garantizar una separación clara de responsabilidades, el sistema utiliza una **Arquitectura de N-Capas** y el **Patrón Repositorio**:

1.  **Capa de Presentación**: Interfaz de usuario en **React/TypeScript** y controladores REST en **ASP.NET Core API**.
2.  **Capa de Lógica de Negocio**: Motor de cálculo en **.NET 10** donde residen las validaciones y cálculos de comisión.
3.  **Capa de Datos**: Persistencia en base de datos gestionada mediante **Entity Framework Core** para el manejo del histórico.

## Tecnologías Utilizadas
* **Frontend**: React + TypeScript + Vite + CSS Nativo
* **Backend**: .NET 10 (C#).
* **Base de Datos**: PostgreSQL.
* **ORM**: Entity Framework Core.

---

## Guía de Instalación y Ejecución Local

### 1. Requisitos Previos
Asegúrate de tener instalado en tu máquina:
- Git
- .NET 10 SDK
- Node.js (v18+)
- PostgreSQL (corriendo localmente)

### 2. Obtener el Código Fuente
Abre tu consola de comandos (Terminal/PowerShell):
```bash
git clone <URL_DEL_REPOSITORIO_AQUI>
cd sales-commission-calculator
```

### 3. Configurar Conexión a Base de Datos
El backend requiere una cadena de conexión para PostgreSQL. 
Abre el archivo `Presentation\Commissions.Api\appsettings.json` y configura tu cadena de conexión dentro de la sección `"ConnectionStrings"`, reemplazando el usuario y contraseña por los de tu servidor local:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=CommissionsDb;Username=postgres;Password=password"
  }
}
```

### 4. Crear Base de Datos y Ejecutar Migraciones
El repositorio contiene Entity Framework para inicializar los esquemas e insertar los países (Semilla/Seed).

```bash
# Cambiar al directorio del proyecto de Base de Datos
cd Data\Commissions.Data

# Correr las migraciones hacia la base de Postgres usando el ensamblado de la API
dotnet ef database update --startup-project ..\..\Presentation\Commissions.Api\Commissions.Api.csproj
```

### 5. Iniciar la API Backend
Volver a raíz del proyecto para poder encender e inicializar la API.

```bash
cd ..\..
dotnet run --project Presentation\Commissions.Api\Commissions.Api.csproj
```
*La API comenzará a correr. Normalmente escuchará en el puerto `5210` (revisar consola porque podría variar.).*

### 6. Instalar dependencias e iniciar el Frontend
Con la API corriendo en la otra consola, abre **una nueva pestaña/ventana de tu Terminal** para prender el front-end/sistema web.

```bash
cd Commissions.Web

# Instalar todas las dependencias de JS/TS
npm install

# Iniciar servidor de desarrollo de React + Vite
npm run dev
```

El Frontend ahora estará corriendo en `http://localhost:5173/`. 
