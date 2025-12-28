# 🧹 ClearCacheIcons

Utilidad para Windows que repara problemas de iconos y miniaturas corruptas limpiando la caché del sistema de forma segura y automática.


![GitHub release](https://img.shields.io/github/v/release/Pablitus666/ClearCacheIcons?style=flat-square)
![GitHub downloads](https://img.shields.io/github/downloads/Pablitus666/ClearCacheIcons/total?style=flat-square)
![GitHub stars](https://img.shields.io/github/stars/Pablitus666/ClearCacheIcons?style=flat-square)
![GitHub issues](https://img.shields.io/github/issues/Pablitus666/ClearCacheIcons?style=flat-square)
![License](https://img.shields.io/github/license/Pablitus666/ClearCacheIcons?style=flat-square)
![C#](https://img.shields.io/badge/C%23-.NET-blue?style=flat-square)
![WinForms](https://img.shields.io/badge/UI-WinForms-blueviolet?style=flat-square)
![Windows](https://img.shields.io/badge/OS-Windows%2010%20%7C%2011-0078D6?style=flat-square)
![Portable](https://img.shields.io/badge/Portable-Yes-success?style=flat-square)
![Admin Required](https://img.shields.io/badge/Admin-Required-orange?style=flat-square)


**ClearCacheIcons** es una aplicación gráfica desarrollada en **C# (.NET / WinForms)** diseñada para **limpiar de forma segura la caché de iconos y miniaturas de Windows** en **Windows 10 y Windows 11 (64 bits)**.

Funciona como una **utilidad portable de mantenimiento del sistema**, enfocada en resolver problemas comunes como iconos corruptos, desactualizados o que no se refrescan correctamente en el Explorador de archivos.

---

![Social Preview](images/Preview.png)

---

## ✨ Características principales

- 🖥️ **Aplicación gráfica (WinForms)** con interfaz sencilla e intuitiva  
- 🧹 **Limpieza específica de la caché de iconos y miniaturas**
- 🔐 **Ejecución con privilegios de administrador** (requeridos por Windows)
- 🧠 **Gestión controlada del estado de Windows Explorer**
  - Intenta cerrar Explorer de forma elegante
  - Gestiona su reinicio sin depender de `taskkill`
  - Reinicia Explorer automáticamente si es necesario
- 🔄 **Continúa el proceso aunque algunos archivos no puedan eliminarse**
- 🛡️ **Seguro**: no elimina archivos críticos del sistema
- 📋 **Transparente**: registro detallado (log) de todas las acciones y errores
- 📦 **Portable**: no requiere instalación

---

## 🛠️ ¿Qué hace exactamente?

1. Verifica que la aplicación se esté ejecutando como **administrador**
2. Localiza la carpeta de caché de iconos de Windows: %LocalAppData%\Microsoft\Windows\Explorer
3. Gestiona el estado de **explorer.exe** de forma controlada para liberar los archivos
4. Elimina archivos como:
- `IconCache*.db`
- `thumbcache_*.db`
5. Reinicia Windows Explorer automáticamente si corresponde
6. Registra todo el proceso en un **log detallado**

---

## 🔍 Transparencia y seguridad

ClearCacheIcons está diseñado para **no realizar acciones destructivas**:

- ❌ No elimina archivos del sistema operativo
- ❌ No modifica el registro de Windows
- ❌ No usa comandos agresivos por defecto
- ✅ Maneja errores recuperables y fatales
- ✅ Continúa la limpieza incluso si algunos archivos están en uso

Si Explorer no puede cerrarse, la herramienta **continúa la limpieza** y notifica al usuario mediante el log.

---

## 🖥️ Requisitos del sistema

- Windows 10 o Windows 11 (64 bits)
- .NET Framework / .NET Runtime compatible
- Permisos de administrador

---

## 🚀 Instalación y Uso

### 📦 Ejecutable Precompilado

1.  Descarga el archivo `ClearCacheIcons.zip` desde la sección [**Releases**](https://github.com/Pablitus666/ClearCacheIcons/releases/tag/v1.0.0) del repositorio de GitHub. 
2.  Descomprime el archivo `ClearCacheIcons.zip`.
3.  Ejecuta `ClearCacheIcons.exe` desde la carpeta descomprimida.
4.  Ejecuta la aplicación como **Administrador**
5.  Presiona el botón para iniciar la limpieza
6.  Observa el progreso y detalles en el panel de log
7.  El Explorador de archivos se reiniciará automáticamente si es necesario

### 📦 Compilación desde el Código Fuente

1.  Clona el repositorio:
    ```powershell
    git clone https://github.com/Pablitus666/ClearCacheIcons.git
    ```
2.  Abre la solución ClearCacheIcons.sln con Visual Studio 2022 o una versión posterior.
3.  Compila el proyecto en configuración `Release`.
4.  El ejecutable se encontrará en el directorio `bin/Release/net8.0-windows/`.
---

## 📸 Interfaz

La aplicación cuenta con una interfaz gráfica simple, orientada a facilitar su uso a usuarios no técnicos, incluyendo una ventana **“Acerca de”** con recursos visuales integrados.

---

## 📷 Capturas de pantalla

<p align="center">
  <img src="images/screenshot.png?v=2" alt="Vista previa de la aplicación" width="600"/>
</p>

## ⚠️ Nota

Durante el proceso, es normal que el Explorador de archivos se cierre y vuelva a abrir.  
Esto es necesario para liberar los archivos de caché bloqueados por el sistema.

---

## 📄 Licencia

Este proyecto se distribuye como software libre.  
Puedes usarlo, modificarlo y adaptarlo a tus necesidades.

---

## 🧪 Prueba la aplicación

Te invito a testear esta utilidad y comprobar su funcionamiento en tu sistema Windows.

👉 https://github.com/Pablitus666/ClearCacheIcons

Si encuentras algún problema o tienes sugerencias, no dudes en abrir un *Issue*.


## 🤝 Contribuciones

Las contribuciones, sugerencias y mejoras son bienvenidas.  
Si encuentras un problema o tienes una idea, no dudes en abrir un *issue* o *pull request*.

---

## 👨‍💻 Autor

Desarrollado con enfoque en **seguridad, transparencia y estabilidad**, pensado para el mantenimiento práctico del sistema Windows.

*   **Nombre:** Pablo Téllez
*   **Contacto:** pharmakoz@gmail.com



