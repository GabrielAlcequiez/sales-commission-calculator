# Calculadora de Comisiones de Ventas 

## Descripción General
Este sistema es una aplicación web diseñada para que los vendedores calculen sus comisiones mensuales de forma rápida y transparente, basándose en sus ventas totales, los descuentos aplicados y el país de operación.

## Reglas de Negocio
El sistema automatiza el cálculo aplicando la regla correspondiente a cada país

* **Lógica General**: Comisión = (Ventas Totales - Descuentos) / Tasa

* **India**: Tasa del 10%.
* **Estados Unidos (US)**: Tasa del 15%.
* **Reino Unido (UK)**: Tasa del 12%.

## Arquitectura del Sistema
Para garantizar una separación clara de responsabilidades, el sistema utiliza una **Arquitectura de N-Capas** y el **Patrón Repositorio**

1.  **Capa de Presentación**: Interfaz de usuario en **React/TypeScript** y controladores en **ASP.NET Core API**.
2.  **Capa de Lógica de Negocio**: Motor de cálculo en **.NET 10** donde residen las reglas de comisión.
3.  **Capa de Datos**: Persistencia mediante **Entity Framework Core** y **PostgreSQL**, gestionando el histórico de cálculos para asegurar la transparencia.

## Tecnologías Utilizadas
* **Frontend**: React + TypeScript.
* **Backend**: .NET 10 (C#).
* **Base de Datos**: PostgreSQL.
* **ORM**: Entity Framework Core.
