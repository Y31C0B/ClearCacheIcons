// I:\Clear-Cache-Icons\ClearCacheIcons\LocalizationManager.cs
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace ClearCacheIcons
{
    public static class LocalizationManager
    {
        private static Dictionary<string, string> _localizedStrings = new Dictionary<string, string>(); // Inicializar
        private static string _currentLanguage = "es"; // Default language

        public static string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    LoadLanguage(_currentLanguage);
                }
            }
        }

        static LocalizationManager()
        {
            LoadLanguage(_currentLanguage);
        }

        private static void LoadLanguage(string languageCode)
        {
            _localizedStrings = new Dictionary<string, string>();
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = $"ClearCacheIcons.lang.{languageCode}.json";

            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    Logger.Log($"Error: Embedded language resource '{resourceName}' not found. Using default texts.", true);
                    return;
                }

                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string jsonString = reader.ReadToEnd();
                        var jsonDocument = JsonDocument.Parse(jsonString);
                        foreach (JsonProperty property in jsonDocument.RootElement.EnumerateObject())
                        {
                            _localizedStrings[property.Name] = property.Value.GetString() ?? property.Name;
                        }
                        // Logger.Log($"Idioma '{languageCode}' cargado correctamente desde recursos incrustados.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Error al cargar el recurso de idioma incrustado '{resourceName}': {ex.Message}", true);
                }
            }
        }

        public static string GetString(string key)
        {
            if (_localizedStrings.TryGetValue(key, out string? value)) // Hacer value anulable
            {
                return value ?? key; // Si es nulo, devolver la clave
            }
            // Fallback to key if not found
            return key;
        }

        public static void ApplyLocalization(Control control)
        {
            if (control == null) return;

            // Apply to the control itself
            string? tag = control.Tag as string; // Usar string? para el tag
            if (!string.IsNullOrEmpty(tag)) // Comprobar si el tag no es nulo o vacío
            {
                string localizedText = GetString(tag); // Pasar el tag no nulo
                if (!string.IsNullOrEmpty(localizedText))
                {
                    control.Text = localizedText;
                }
            }

            // Apply to child controls
            foreach (Control childControl in control.Controls)
            {
                ApplyLocalization(childControl);
            }
        }
    }
}
