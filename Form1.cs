using System.Drawing;
using System.Threading.Tasks; // Necesario para Task.Run
using System.Globalization;
using System.IO; // Necesario para Path.Combine
using ClearCacheIcons.Helpers;

namespace ClearCacheIcons;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Logger.Initialize(richTextBoxLog); // Inicializar el Logger

        // Establecer el idioma por defecto y aplicar localización
        LocalizationManager.CurrentLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName; // Detectar idioma del sistema
        LocalizationManager.ApplyLocalization(this); // Aplicar localización al formulario y sus controles

        this.Load += Form1_Load; // Suscribir el evento Load
        this.BackColor = System.Drawing.ColorTranslator.FromHtml("#023047"); // Color de fondo del formulario
    }

    private void Form1_Load(object? sender, EventArgs e) // Cambiar object a object?
    {
        // Cargar la imagen del título como recurso incrustado
        try
        {
            Image? titleImage = ImageUtils.CargarImagenDesdeRecurso("titulo.png");
            if (titleImage != null)
            {
                this.pictureBoxTitle.Image = titleImage;
            }
            else
            {
                Logger.Log($"Error: Embedded title image 'titulo.png' not found.", true);
            }
        }
        catch (Exception ex)
        {
            Logger.Log(LocalizationManager.GetString("Log_ErrorLoadingTitleImage") + ex.Message, true);
        }

        // Cargar el icono del formulario como recurso incrustado
        try
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string iconResourceName = "ClearCacheIcons.images.icon.ico";
            using (Stream? iconStream = assembly.GetManifestResourceStream(iconResourceName))
            {
                if (iconStream != null)
                {
                    this.Icon = new Icon(iconStream);
                }
                else
                {
                    Logger.Log($"Error: Embedded icon resource '{iconResourceName}' not found for main form.", true);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log(LocalizationManager.GetString("Log_ErrorLoadingIcon") + ex.Message, true);
        }

        // Cargar la imagen para los botones como recurso incrustado
        try
        {
            Image? buttonImage = ImageUtils.CargarImagenDesdeRecurso("boton.png");
            if (buttonImage != null)
            {
                buttonClear.BackgroundImage = buttonImage;
                buttonInfo.BackgroundImage = buttonImage;
                buttonExit.BackgroundImage = buttonImage; // Asignar imagen al nuevo botón

                buttonClear.BackgroundImageLayout = ImageLayout.Stretch; // Ajustar imagen al tamaño del botón
                buttonInfo.BackgroundImageLayout = ImageLayout.Stretch; // Ajustar imagen al tamaño del botón
                buttonExit.BackgroundImageLayout = ImageLayout.Stretch; // Ajustar imagen al tamaño del botón

                // Configurar el texto y la imagen para que se centren
                buttonClear.ImageAlign = ContentAlignment.MiddleCenter;
                buttonClear.TextAlign = ContentAlignment.MiddleCenter;
                buttonInfo.ImageAlign = ContentAlignment.MiddleCenter;
                buttonInfo.TextAlign = ContentAlignment.MiddleCenter;
                buttonExit.ImageAlign = ContentAlignment.MiddleCenter; // Configurar nuevo botón
                buttonExit.TextAlign = ContentAlignment.MiddleCenter; // Configurar nuevo botón

                // Deshabilitar TabStop para eliminar el recuadro de foco
                buttonClear.TabStop = false;
                buttonInfo.TabStop = false;
                buttonExit.TabStop = false;

                // Estilo de los botones
                buttonClear.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
                buttonInfo.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
                buttonExit.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);
            }
            else
            {
                Logger.Log($"Error: Embedded button image 'boton.png' not found.", true);
            }
        }
        catch (Exception ex)
        {
            Logger.Log(LocalizationManager.GetString("Log_ErrorLoadingButtonImage") + ex.Message, true);
        }

        // Estilo del RichTextBox
        richTextBoxLog.BackColor = System.Drawing.ColorTranslator.FromHtml("#0B2027"); // Fondo oscuro
        richTextBoxLog.ForeColor = Color.White; // Texto blanco
        richTextBoxLog.Font = new Font("Comic Sans MS", 10, FontStyle.Regular); // Aumentar tamaño de fuente
        richTextBoxLog.HideSelection = true; // Ocultar la selección cuando el control pierde el foco
        richTextBoxLog.GotFocus += (sender, e) => this.ActiveControl = null; // Quitar el foco inmediatamente

        // Suscribir los eventos Click siempre, independientemente de la carga de la imagen
        buttonClear.Click += buttonClear_Click;
        buttonInfo.Click += buttonInfo_Click;
        buttonExit.Click += buttonExit_Click; // Suscribir evento del nuevo botón

        // Suscribir eventos de hover para los botones
        buttonClear.MouseEnter += Button_MouseEnter;
        buttonClear.MouseLeave += Button_MouseLeave;
        buttonInfo.MouseEnter += Button_MouseEnter;
        buttonInfo.MouseLeave += Button_MouseLeave;
        buttonExit.MouseEnter += Button_MouseEnter;
        buttonExit.MouseLeave += Button_MouseLeave;
    }

    private async void buttonClear_Click(object? sender, EventArgs e) // Cambiar object a object?
    {
        buttonClear.Enabled = false; // Deshabilitar botón durante la limpieza
        buttonInfo.Enabled = false;
        buttonExit.Enabled = false; // Deshabilitar nuevo botón
        Logger.Log(LocalizationManager.GetString("Log_StartingCleanup"), false);
        
        await Task.Run(() => IconCacheCleaner.ClearIconCache());
        
        buttonClear.Enabled = true; // Habilitar botón después de la limpieza
        buttonInfo.Enabled = true;
        buttonExit.Enabled = true; // Habilitar nuevo botón

        // Mostrar el mensaje de limpieza completada en el hilo de la UI
        using (var form = new CustomMessageBoxForm(LocalizationManager.GetString("Log_CleanupCompleteMessage"), LocalizationManager.GetString("AboutBox_Title")))
        {
            form.ShowDialog();
        }
    }

    private void buttonInfo_Click(object? sender, EventArgs e) // Cambiar object a object?
    {
        AboutBoxForm aboutBox = new AboutBoxForm();
        aboutBox.ShowDialog();
    }

    private void buttonExit_Click(object? sender, EventArgs e) // Nuevo método para el botón de salir
    {
        Logger.Log(LocalizationManager.GetString("Log_ExitingApplication"), false);
        Application.Exit();
    }

    private void Button_MouseEnter(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFD700"); // Gold color
        }
    }

    private void Button_MouseLeave(object? sender, EventArgs e)
    {
        // No need to set ForeColor to white here, as NoFocusButton's OnPaint handles it.
        // The ForeColor will revert to white when the mouse leaves and the button is not hovered.
    }
}
