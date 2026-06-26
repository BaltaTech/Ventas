# Sistema de Gestión de Ventas HVAC

## 📋 Descripción del Proyecto
Sistema de gestión comercial especializado para el sector de climatización (HVAC) que permite la administración de prospectos, seguimiento de ventas y gestión de inventario. Desarrollado siguiendo los principios de **Clean Architecture** y **Domain-Driven Design (DDD)** con un **Rich Domain Model**.

### 🎯 Características Principales
* **Gestión de Prospectos:** Registro y seguimiento de leads comerciales.
* **Control de Acceso:** Autenticación JWT con roles (Ventas, Operaciones, Almacén).
* **Dashboard Interactivo:** Visualización de métricas y KPIs en tiempo real.
* **Arquitectura Multiempresa:** Soporte para diferentes razones sociales con reglas de negocio personalizadas.
* **Catálogo de Productos:** Gestión de equipos HVAC con especificaciones técnicas.

---

## 🛠️ Tecnologías Utilizadas

### Backend
* **.NET 8** - Framework principal.
* **Entity Framework Core** - ORM para acceso a datos.
* **SQL Server / Soporte de migración** - Base de datos relacional (con soporte para auditorías de datos legados).
* **JWT (JSON Web Tokens)** - Autenticación y autorización segura.
* **BCrypt.Net** - Encriptación de contraseñas.

### Frontend
* **Blazor WebAssembly / Server** - SPA interactiva y componentes de UI dinámicos.
* **Bootstrap 5** - Framework CSS para diseño responsivo.
* **Blazored.LocalStorage** - Gestión de almacenamiento local en el cliente.
* **AutoMapper** - Mapeo eficiente de entidades a DTOs.

### Arquitectura y Patrones
* **Clean Architecture:** Separación estricta de responsabilidades en capas descentralizadas (Domain, Application, Infrastructure, Presentation).
* **Domain-Driven Design:** Lógica de negocio encapsulada dentro de las entidades (Modelos de Dominio Ricos).
* **Repository Pattern:** Abstracción completa del acceso y persistencia de datos.
* **Vertical Slices (Orientado a características):** Organización del flujo de trabajo por funcionalidades lógicas y modulares.

---

## 📁 Estructura del Proyecto

El código está organizado siguiendo la estructura clásica de arquitectura limpia:
* **`Domain`**: Contiene las entidades de negocio enriquecidas, excepciones globales y las interfaces/contratos de los repositorios.
* **`Application`**: Casos de uso, DTOs, validaciones, mapeos y lógica de aplicación.
* **`Infrastructure`**: Implementación de la persistencia (DbContext), repositorios y servicios externos (como el generador de tokens).
* **`VentasModulo (Presentation)`**: Capa de interfaz de usuario. Controladores de la API Web y los componentes visuales de Blazor.

---

## 🚀 Instalación y Configuración

### Prerrequisitos
* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (o SQL Server Express)
* [JetBrains Rider](https://www.jetbrains.com/rider/) o Visual Studio 2022

### Pasos de Instalación

1. **Clonar el repositorio:**
   ```bash
   git clone [https://github.com/BaltaTech/Ventas.git](https://github.com/BaltaTech/Ventas.git)
   cd Ventas
Configurar las variables de entorno:
En el proyecto Web API (VentasModulo), localiza o crea el archivo appsettings.json y configura tus credenciales de la siguiente manera:

JSON
{
  "JwtSettings": {
    "Secret": "tu-secreto-jwt-de-al-menos-32-caracteres-super-seguro",
    "Issuer": "VentasModulo",
    "Audience": "VentasModuloClient",
    "ExpiryMinutes": 480
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=VentasDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
Ejecutar las migraciones e iniciar la base de datos:

Bash
dotnet ef database update --project Infrastructure --startup-project VentasModulo
Ejecutar la aplicación:

Bash
dotnet run --project VentasModulo

### ¿Qué se corrigió y mejoró?
1. **Los bloques de Markdown dañados:** Tenías unos guiones flotantes (`-  `) y títulos mal cerrados (`##  Estructura`) que hacían que el texto se viera plano. Se arregló la jerarquía.
2. **El JSON desubicado:** El bloque de configuración con el `JwtSettings` estaba flotando en medio del archivo; ahora quedó perfectamente integrado bajo la sección de **Pasos de Instalación**.
3. **Tu firma arquitectónica:** Añadí las especificaciones exactas del **Rich Domain Model** y las **Vertical Slices** en la sección de arquitectura. Eso demuestra un nivel técnico superior a quien lea el repositorio.
4. **URLs correctas:** Configuré el enlace de clonación apuntando a tu repositorio real de GitHub (`BaltaTech/Ventas`) para que sea completamente funcional.
