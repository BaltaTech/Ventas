# 🏢 Ventas Módulo - CRM HVAC

> **El proyecto que me enseñó que la arquitectura es la fase final, no el punto de partida**

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-WASM-512BD4?logo=blazor)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![Clean Architecture](https://img.shields.io/badge/Clean-Architecture-4CAF50)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
[![Status](https://img.shields.io/badge/status-incomplete-yellow)]()

---

## 📋 Tabla de Contenidos

- [Contexto Real](#-contexto-real)
- [El Problema](#-el-problema-que-resolvía)
- [Decisiones Técnicas](#-decisiones-técnicas-y-por-qué-las-tomé)
- [Lo que Aprendí](#-lo-que-aprendí)
- [Lecciones para el Futuro](#-lecciones-para-el-futuro)
- [Estado del Proyecto](#-estado-del-proyecto)
- [Tecnologías](#-tecnologías)
- [Arquitectura](#-arquitectura)
- [Instalación](#-instalación)
- [¿Vale la pena para una Entrevista?](#-vale-la-pena-para-una-entrevista)
- [Autor](#-autor)
- [Licencia](#-licencia)

---

## 🎯 Contexto Real

Este proyecto nació en un **contexto empresarial real**: una empresa del sector HVAC en México con **problemas de comunicación entre departamentos**.

### El Problema que Resolvía

| Área | Problema |
|------|----------|
| **Recepción** | Registraba leads en Google Sheets |
| **Ventas** | Trabajaba con Excel y correos |
| **Contabilidad** | Usaba Aspel SAE |
| **Almacén** | Tenía su propio sistema (COI, NOI) |

**Resultado:** Información dispersa, leads perdidos, falta de seguimiento, procesos manuales y dependientes de personas específicas.

### El Enfoque

La primera etapa estaba enfocada en el **departamento de Ventas**, unificando la información de leads y prospectos en un solo lugar para:
- ✅ Centralizar la información de clientes potenciales
- ✅ Asignar leads a vendedores de forma automática
- ✅ Dar seguimiento a las oportunidades de venta
- ✅ Medir el rendimiento del equipo comercial

### La Realidad

> **Nunca llegó a producción.** Siendo el único desarrollador, la complejidad del proyecto (Clean Architecture + Blazor WASM + JWT) era demasiado para una empresa que necesitaba soluciones simples, no arquitecturas perfectas.

**El aprendizaje más valioso:** Entender que la tecnología es solo una herramienta, y que la mejor arquitectura no sirve de nada si no resuelve el problema real de la empresa.

---

## 🤔 Decisiones Técnicas (y por qué las tomé)

### ¿Por qué Clean Architecture?

| Decisión | Por qué | Lo que aprendí |
|----------|---------|----------------|
| **Clean Architecture** | Quería aprenderla y pensé que era la mejor práctica universal | ❌ **No era la herramienta adecuada.** El problema era cultural (falta de procesos definidos), no arquitectónico. Clean Architecture no iba a solucionar que cada área usara herramientas distintas |

### ¿Por qué Blazor WASM?

| Decisión | Por qué | Lo que aprendí |
|----------|---------|----------------|
| **Blazor WASM** | Leí el manual y me pareció interesante | ❌ **Overkill para una empresa pequeña.** Para un equipo de 5 personas, Razor Pages o incluso una aplicación de consola hubiera sido más efectiva |

### ¿Por qué JWT?

| Decisión | Por qué | Lo que aprendí |
|----------|---------|----------------|
| **JWT** | La IA lo sugirió para autenticación | ✅ **JWT es para comunicación entre sistemas externos.** Para un CRM interno, Identity es más simple y efectivo |

### Reflexión Crítica

> *"Elegí Clean Architecture por desconocer que no era la herramienta adecuada para el problema de la empresa. No era una cuestión de arquitectura o escalabilidad, sino de cultura empresarial y flujos de trabajo completamente definidos."*

**Hoy sé que:**
- La arquitectura es la **fase final** del problema resuelto, no el punto de partida
- Primero hay que **modelar el dominio** y entender el negocio
- Las herramientas se eligen **después de entender el problema**, no antes
- Un sistema simple que se usa vale más que un sistema complejo que no se termina

### Comparativa de Enfoques

| Aspecto | Este Proyecto | Enfoque Actual |
|----------|---------------|----------------|
| **Punto de partida** | Elegir arquitectura primero | Entender el problema primero |
| **Tecnología** | Clean Architecture + Blazor | Simple + proporcional |
| **Autenticación** | JWT | Identity |
| **Frontend** | Blazor WASM | Razor Pages o simple HTML/CSS/JS |

---

## 🧠 Lo que Aprendí

### Conceptos Fundamentales

| Concepto | Lo que entendí |
|----------|----------------|
| **Separación de Responsabilidades** | Cada módulo desacoplado para mantenibilidad y escalabilidad. Aprendí que la separación no es un lujo, es una necesidad para sistemas que crecen |
| **Dependencias** | La gestión de dependencias entre proyectos es fundamental. Un cambio en una capa no debe romper las demás |
| **JWT** | Seguridad en texto plano para comunicación entre sistemas externos. No es para autenticación interna |
| **Clean Architecture** | El dominio aislado de detalles tecnológicos, resistente al cambio. Depender de abstracciones, no de implementaciones concretas |
| **Modelado de Dominio** | Una clase no es un saco de datos, es una identidad viva. Los procedimientos del negocio deben estar reflejados en el código |
| **Abstracción** | Depender de abstracciones, no de implementaciones concretas. Esto permite cambiar tecnologías sin reescribir todo |
| **Encapsulación** | Proteger el estado interno de los objetos. Las reglas de negocio viven dentro de las entidades |
| **Polimorfismo** | Diferentes implementaciones para diferentes contextos. Cada departamento tiene sus propias reglas |

### Tecnologías que Aprendí

| Tecnología | Nivel | Contexto |
|------------|-------|----------|
| **JWT** | ✅ Comprendí su propósito real | Comunicación entre sistemas externos |
| **Identity** | ✅ Alternativa más simple para apps internas | Autenticación en aplicaciones internas |
| **SignalR** | ✅ Comunicación en tiempo real | Notificaciones, chats |
| **QuestPDF** | ✅ Generación de documentos | Cotizaciones, facturas |
| **DBeaver** | ✅ Visualización de bases de datos | Administración de BD |
| **ASP.NET Core** | ✅ Framework completo | Backend robusto |
| **Razor Pages** | ✅ Alternativa más simple a Blazor | Aplicaciones server-side |
| **Git** | ✅ Control de versiones | Colaboración y seguimiento |
| **GitHub Pages** | ✅ Despliegue | Hosting de aplicaciones estáticas |
| **Apps Script** | ✅ Automatización en Google | Integración con Google Sheets |
| **HTML/CSS/JS** | ✅ Frontend tradicional | Interacción básica |
| **EF Core** | ✅ ORM | Mapeo objeto-relacional |
| **Swagger** | ✅ Documentación de APIs | Configuración de hash y encriptación |

### Lo Más Valioso

> *"Comprendí muchos conceptos de diseño y arquitectura de software: abstracciones, encapsulación, polimorfismo y herencia de manera sólida. Aprendí patrones de diseño que en proyectos posteriores surgieron de los problemas reales del software, no de una complejidad inventada para que se viera bonito."*

### Mi Evolución como Desarrollador

| Antes | Ahora |
|-------|-------|
| Quería aplicar todas las tecnologías que aprendía | Elijo las herramientas según el problema |
| Pensaba que más capas = mejor arquitectura | Sé que la simplicidad es más valiosa |
| Elegía arquitectura primero | Modelo el dominio primero |
| Tecnologías complejas por defecto | Simplicidad primero, complejidad cuando sea necesaria |
| Clean Architecture para todo | Arquitectura proporcional al problema |
| JWT para autenticación interna | Identity para apps internas, JWT para sistemas externos |

---

## 📚 Lecciones para el Futuro

### Mi Proceso Actual




### Lo que cambiaría hoy

| Aspecto | Cambio |
|---------|--------|
| **Arquitectura** | Usaría algo más simple (MVC o Razor Pages) |
| **Frontend** | Razor Pages en lugar de Blazor WASM |
| **Autenticación** | Identity en lugar de JWT |
| **Complejidad** | Menos capas, más simplicidad |
| **Enfoque** | Primero modelar el dominio, luego la tecnología |

---

## 📊 Estado del Proyecto

| Aspecto | Estado |
|---------|--------|
| **Desarrollo** | ⚠️ Incompleto |
| **Configuración** | ✅ Proyecto configurado |
| **Módulo de Recepción** | ✅ Parcialmente implementado |
| **Autenticación** | ✅ Configurada con JWT |
| **Base de Datos** | ✅ Configurada con EF Core |
| **Producción** | ❌ No llegó |
| **Razón del abandono** | Complejidad excesiva para el problema de la empresa |

### ¿Lo Retomaría?

**Sí.** Pero con un enfoque diferente:
- ✅ Modelando el dominio primero (no la arquitectura)
- ✅ Usando Razor Pages en lugar de Blazor WASM
- ✅ Usando Identity en lugar de JWT
- ✅ Arquitectura más simple y proporcional al problema
- ✅ Enfocándome en resolver el problema real, no en usar tecnologías complejas

### Funcionalidades Implementadas

| Módulo | Estado |
|--------|--------|
| **Autenticación JWT** | ✅ Completa |
| **CRUD de Prospectos** | ✅ Completo |
| **Asignación de Vendedores** | ✅ Completo |
| **Dashboard de Ventas** | ✅ Parcial |
| **Módulo de Recepción** | ✅ Parcial |
| **Módulo de Inventario** | ❌ No implementado |
| **Reportes** | ❌ No implementado |
| **SignalR** | ❌ No implementado |

---

## 🛠️ Tecnologías

### Backend

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| **.NET** | 8.0 | Framework principal |
| **ASP.NET Core** | 8.0 | API REST |
| **Entity Framework Core** | 8.0 | ORM |
| **SQL Server** | 2022 | Base de datos |
| **JWT** | - | Autenticación |
| **AutoMapper** | 16.0 | Mapeo DTO-Entidad |
| **BCrypt** | 4.1 | Hashing de contraseñas |

### Frontend

| Tecnología | Versión | Propósito |
|------------|---------|-----------|
| **Blazor WebAssembly** | 8.0 | SPA interactiva |
| **Bootstrap** | 5.0 | UI Framework |
| **Font Awesome** | 6.0 | Iconos |

### Infraestructura

| Tecnología | Propósito |
|------------|-----------|
| **Git** | Control de versiones |
| **GitHub** | Repositorio remoto |
| **Swagger** | Documentación de API |

---

## 🏗️ Arquitectura

### Clean Architecture (El Aprendizaje)
 Presentation (Blazor WASM) │
│ ┌─────────────┐ ┌─────────────┐ ┌─────────────┐ │
│ │ Pages │ │ Services │ │ Layout │ │
│ └─────────────┘ └─────────────┘ └─────────────┘ │
├─────────────────────────────────────────────────────────────┤
│ Application Layer │
│ ┌─────────────┐ ┌─────────────┐ ┌─────────────┐ │
│ │ DTOs │ │ Services │ │ Interfaces │ │
│ └─────────────┘ └─────────────┘ └─────────────┘ │
├─────────────────────────────────────────────────────────────┤
│ Domain Layer │
│ ┌─────────────┐ ┌─────────────┐ ┌─────────────┐ │
│ │ Entities │ │ Enums │ │ Interfaces │ │
│ └─────────────┘ └─────────────┘ └─────────────┘ │
├─────────────────────────────────────────────────────────────┤
│ Infrastructure Layer │
│ ┌─────────────┐ ┌─────────────┐ ┌─────────────┐ │
│ │ Repositories│ │ DbContext │ │ Services │ │
│ └─────────────┘ └─────────────┘ └─────────────┘ │
└─────────────────────────────────────────────────────────────┘


### ¿Qué aprendí de esta arquitectura?

| Aspecto | Aprendizaje |
|---------|-------------|
| **Separación** | Cada capa tiene una responsabilidad clara |
| **Independencia** | El dominio no depende de nada externo |
| **Testeabilidad** | Cada capa se puede probar de forma aislada |
| **Mantenibilidad** | Cambios en una capa no afectan a las demás |
| **Escalabilidad** | Puede soportar millones de usuarios sin comprometer el rendimiento |

### Pero...

> *"Clean Architecture está listo y resiste el cambio de tecnologías, al depender de abstracciones y no de implementaciones concretas. PERO para una empresa pequeña, esta fortaleza es innecesaria."*

---

## 🚀 Instalación

### Prerrequisitos

- ✅ .NET 8 SDK
- ✅ SQL Server (o SQL Express)
- ✅ Visual Studio 2022

### Setup

```bash
# 1. Clonar repositorio
git clone https://github.com/tu-usuario/VentasModulo.git

# 2. Navegar al proyecto
cd VentasModulo

# 3. Restaurar paquetes
dotnet restore

# 4. Configurar base de datos (actualizar connection string)
# Editar appsettings.json

# 5. Crear migraciones
dotnet ef migrations add InitialCreate

# 6. Actualizar base de datos
dotnet ef database update

# 7. Ejecutar el proyecto
dotnet run --project VentasModulo
