## 🖥️ Release v1.0 – ClearCacheIcons

### 🧹 Limpieza segura de caché de iconos para Windows

Esta versión inicial de ClearCacheIcons introduce una herramienta gráfica y portable para limpiar la caché de iconos y miniaturas de Windows en Windows 10 y Windows 11 (64 bits).

La aplicación está pensada para usuarios finales y avanzados, con énfasis en seguridad, transparencia y estabilidad durante todo el proceso.

### ✨ Características destacadas

## 🖥️ Aplicación gráfica WinForms

Limpieza específica de:

    IconCache*.db

    thumbcache_*.db

Ejecución con privilegios de administrador

Gestión controlada de Windows Explorer

    Intenta cerrar Explorer de forma elegante

    Gestiona su reinicio sin depender de taskkill

    Reinicia Explorer automáticamente si es necesario

    Continúa la limpieza incluso si Explorer no puede cerrarse

Registro detallado (log) de todas las acciones y errores

Portable: no requiere instalación

Seguro: no elimina archivos críticos del sistema

### ✨ 🔍 Comportamiento de Windows Explorer

Durante la limpieza, la aplicación intenta liberar los archivos de caché gestionando el estado de explorer.exe.
En algunos casos, Explorer puede cerrarse y volver a abrirse automáticamente, lo cual es normal y esperado.

Si Explorer no puede cerrarse, la herramienta continúa la limpieza sin interrumpir el sistema, registrando el evento en el log.

### 🛡️ Seguridad y transparencia

    No modifica el registro de Windows

    No elimina archivos del sistema operativo

    No utiliza comandos externos agresivos

    Manejo explícito de errores recuperables y fatales

    Todas las acciones quedan reflejadas en el log

### 📦 Uso recomendado

Ejecutar siempre como Administrador para asegurar la eliminación correcta de los archivos de caché.

### 📌 Notas

Este release representa una versión estable inicial, orientada al mantenimiento del sistema y la resolución de problemas visuales relacionados con iconos y miniaturas.

> ✅ **Nota sobre las advertencias:** Es posible que Windows o su antivirus muestren una advertencia de seguridad al intentar ejecutar la aplicación. Si ve un mensaje como "Windows protegió su PC", puede hacer clic en "Más información" y luego en "Ejecutar de todas formas" con total tranquilidad, sabiendo que la aplicación es segura y ha sido verificada.

---