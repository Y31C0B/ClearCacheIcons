using System;
using System.Drawing;
using System.Windows.Forms;
using ClearCacheIcons.Helpers;

namespace ClearCacheIcons
{
    public partial class CustomMessageBoxForm : Form
    {
        public CustomMessageBoxForm(string message, string title)
        {
            InitializeComponent();
            this.Text = title;
            this.labelMessage.Text = message;

            // Apply localization to the close button
            LocalizationManager.ApplyLocalization(this);

            // Apply custom styles
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.labelMessage.ForeColor = Color.White;
            this.buttonClose.ForeColor = Color.White;
            this.buttonClose.Font = new Font("Comic Sans MS", 10, FontStyle.Bold);

            // Load and apply button background image from embedded resources
            try
            {
                Image? buttonImage = ImageUtils.CargarImagenDesdeRecurso("boton.png");
                if (buttonImage != null)
                {
                    this.buttonClose.BackgroundImage = buttonImage;
                    this.buttonClose.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    Logger.Log($"Error: Embedded button image 'boton.png' not found for CustomMessageBoxForm.", true);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error loading button image for custom message box: " + ex.Message, true);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
