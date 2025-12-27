namespace ClearCacheIcons
{
    partial class CustomMessageBoxForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelMessage;
        private ClearCacheIcons.NoFocusButton buttonClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonClose = new ClearCacheIcons.NoFocusButton();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(10, 10);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 60); // Padding to not overlap with button
            this.labelMessage.Size = new System.Drawing.Size(414, 141);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Message Text";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(142, 98);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(150, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "OK"; // Default text, will be localized
            this.buttonClose.Tag = "CustomMessageBox_OKButton"; // Tag for localization
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // CustomMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBoxForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.ResumeLayout(false);

        }
    }
}
