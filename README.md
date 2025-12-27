# 🧹 ClearCacheIcons

**ClearCacheIcons** es una aplicación gráfica desarrollada en **C# (.NET / WinForms)** diseñada para **limpiar de forma segura la caché de iconos y miniaturas de Windows** en **Windows 10 y Windows 11 (64 bits)**.

Funciona como una **utilidad portable de mantenimiento del sistema**, enfocada en resolver problemas comunes como iconos corruptos, desactualizados o que no se refrescan correctamente en el Explorador de archivos.

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

## 📦 Uso

1. Ejecuta la aplicación como **Administrador**
2. Presiona el botón para iniciar la limpieza
3. Observa el progreso y detalles en el panel de log
4. El Explorador de archivos se reiniciará automáticamente si es necesario

---

## 📸 Interfaz

La aplicación cuenta con una interfaz gráfica simple, orientada a facilitar su uso a usuarios no técnicos, incluyendo una ventana **“Acerca de”** con recursos visuales integrados.

---

## ⚠️ Nota

Durante el proceso, es normal que el Explorador de archivos se cierre y vuelva a abrir.  
Esto es necesario para liberar los archivos de caché bloqueados por el sistema.

---

## 📄 Licencia

Este proyecto se distribuye como software libre.  
Puedes usarlo, modificarlo y adaptarlo a tus necesidades.

---

## 🤝 Contribuciones

Las contribuciones, sugerencias y mejoras son bienvenidas.  
Si encuentras un problema o tienes una idea, no dudes en abrir un *issue* o *pull request*.

---

## 👨‍💻 Autor

Desarrollado con enfoque en **seguridad, transparencia y estabilidad**, pensado para el mantenimiento práctico del sistema Windows.

*   **Nombre:** Pablo Téllez
*   **Contacto:** pharmakoz@gmail.com



