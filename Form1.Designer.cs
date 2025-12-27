namespace ClearCacheIcons
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private NoFocusButton buttonClear;
        private NoFocusButton buttonInfo;
        private NoFocusButton buttonExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClear = new ClearCacheIcons.NoFocusButton();
            this.buttonInfo = new ClearCacheIcons.NoFocusButton();
            this.buttonExit = new ClearCacheIcons.NoFocusButton();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.richTextBoxLog, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelButtons, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10); // Added top and bottom padding
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F)); // Percentage height for title
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F)); // Percentage height for log
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F)); // Percentage height for buttons
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(660, 600); // Re-added original size
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTitle.Location = new System.Drawing.Point(13, 3);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(634, 74);
            this.pictureBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTitle.TabIndex = 2;
            this.pictureBoxTitle.TabStop = false;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(13, 83);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLog.TabStop = false;
            this.richTextBoxLog.Size = new System.Drawing.Size(634, 434); // Adjusted height
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.ColumnCount = 3;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelButtons.Controls.Add(this.buttonClear, 0, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.buttonInfo, 1, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.buttonExit, 2, 0);
            this.tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(13, 523);
            this.tableLayoutPanelButtons.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5); // Added padding to buttons table
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(634, 74); // Adjusted height
            this.tableLayoutPanelButtons.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatAppearance.MouseDownBackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonClear.FlatAppearance.MouseOverBackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(3, 3); // Location will be managed by Dock.Fill and padding
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Tag = "buttonClear_Text";
            this.buttonClear.Text = "Limpiar Cache";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonInfo
            // 
            this.buttonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInfo.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatAppearance.MouseDownBackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonInfo.FlatAppearance.MouseOverBackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Location = new System.Drawing.Point(214, 3); // Location will be managed by Dock.Fill and padding
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.TabIndex = 1;
            this.buttonInfo.Tag = "buttonInfo_Text";
            this.buttonInfo.Text = "Información";
            this.buttonInfo.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.ColorTranslator.FromHtml("#023047");
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(425, 3); // Location will be managed by Dock.Fill and padding
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Tag = "buttonExit_Text";
            this.buttonExit.Text = "Salir";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(660, 600); // Re-added original size
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Form1_Text";
            // This.Text is now handled by LocalizationManager.ApplyLocalization(this);
            this.tableLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}