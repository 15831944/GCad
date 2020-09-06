namespace GCad
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.MachineTypeComboBox = new System.Windows.Forms.ComboBox();
            this.MachineTypeLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToleranceTextBox = new System.Windows.Forms.TextBox();
            this.ToleranceLabel = new System.Windows.Forms.Label();
            this.DecimalsLabel = new System.Windows.Forms.Label();
            this.DecimalsTextBox = new System.Windows.Forms.TextBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.AdditionalArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MachineHelpButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MachineTypeComboBox
            // 
            this.MachineTypeComboBox.FormattingEnabled = true;
            this.MachineTypeComboBox.Location = new System.Drawing.Point(6, 34);
            this.MachineTypeComboBox.Name = "MachineTypeComboBox";
            this.MachineTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.MachineTypeComboBox.TabIndex = 0;
            this.MachineTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.MachineTypeComboBox_SelectedIndexChanged);
            // 
            // MachineTypeLabel
            // 
            this.MachineTypeLabel.AutoSize = true;
            this.MachineTypeLabel.Location = new System.Drawing.Point(6, 16);
            this.MachineTypeLabel.Name = "MachineTypeLabel";
            this.MachineTypeLabel.Size = new System.Drawing.Size(78, 13);
            this.MachineTypeLabel.TabIndex = 99991;
            this.MachineTypeLabel.Text = "Machine Type:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(486, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ToleranceTextBox
            // 
            this.ToleranceTextBox.Location = new System.Drawing.Point(163, 34);
            this.ToleranceTextBox.Name = "ToleranceTextBox";
            this.ToleranceTextBox.Size = new System.Drawing.Size(100, 20);
            this.ToleranceTextBox.TabIndex = 3;
            this.ToleranceTextBox.Text = "0.1";
            this.ToleranceTextBox.TextChanged += new System.EventHandler(this.ToleranceTextBox_TextChanged);
            // 
            // ToleranceLabel
            // 
            this.ToleranceLabel.AutoSize = true;
            this.ToleranceLabel.Location = new System.Drawing.Point(160, 16);
            this.ToleranceLabel.Name = "ToleranceLabel";
            this.ToleranceLabel.Size = new System.Drawing.Size(58, 13);
            this.ToleranceLabel.TabIndex = 49999;
            this.ToleranceLabel.Text = "Tolerance:";
            // 
            // DecimalsLabel
            // 
            this.DecimalsLabel.AutoSize = true;
            this.DecimalsLabel.Location = new System.Drawing.Point(160, 57);
            this.DecimalsLabel.Name = "DecimalsLabel";
            this.DecimalsLabel.Size = new System.Drawing.Size(53, 13);
            this.DecimalsLabel.TabIndex = 9999;
            this.DecimalsLabel.Text = "Decimals:";
            // 
            // DecimalsTextBox
            // 
            this.DecimalsTextBox.Location = new System.Drawing.Point(163, 74);
            this.DecimalsTextBox.Name = "DecimalsTextBox";
            this.DecimalsTextBox.Size = new System.Drawing.Size(100, 20);
            this.DecimalsTextBox.TabIndex = 4;
            this.DecimalsTextBox.TextChanged += new System.EventHandler(this.DecimalsTextBox_TextChanged);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(12, 311);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 5;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // AdditionalArgumentsTextBox
            // 
            this.AdditionalArgumentsTextBox.Location = new System.Drawing.Point(93, 313);
            this.AdditionalArgumentsTextBox.Name = "AdditionalArgumentsTextBox";
            this.AdditionalArgumentsTextBox.Size = new System.Drawing.Size(381, 20);
            this.AdditionalArgumentsTextBox.TabIndex = 6;
            this.AdditionalArgumentsTextBox.TextChanged += new System.EventHandler(this.AdditionalArgumentsTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 9999;
            this.label1.Text = "Additional arguments:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MachineTypeLabel);
            this.groupBox1.Controls.Add(this.MachineHelpButton);
            this.groupBox1.Controls.Add(this.MachineTypeComboBox);
            this.groupBox1.Controls.Add(this.ToleranceLabel);
            this.groupBox1.Controls.Add(this.DecimalsLabel);
            this.groupBox1.Controls.Add(this.DecimalsTextBox);
            this.groupBox1.Controls.Add(this.ToleranceTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 147);
            this.groupBox1.TabIndex = 10999;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base Values";
            // 
            // MachineHelpButton
            // 
            this.MachineHelpButton.BackColor = System.Drawing.Color.Transparent;
            this.MachineHelpButton.BackgroundImage = global::GCad.Properties.Resources.help_icon;
            this.MachineHelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MachineHelpButton.FlatAppearance.BorderSize = 0;
            this.MachineHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MachineHelpButton.Location = new System.Drawing.Point(133, 32);
            this.MachineHelpButton.Name = "MachineHelpButton";
            this.MachineHelpButton.Size = new System.Drawing.Size(21, 21);
            this.MachineHelpButton.TabIndex = 1;
            this.MachineHelpButton.UseVisualStyleBackColor = false;
            this.MachineHelpButton.Click += new System.EventHandler(this.MachineHelpButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 345);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdditionalArgumentsTextBox);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox MachineTypeComboBox;
        private System.Windows.Forms.Label MachineTypeLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox ToleranceTextBox;
        private System.Windows.Forms.Label ToleranceLabel;
        private System.Windows.Forms.Label DecimalsLabel;
        private System.Windows.Forms.TextBox DecimalsTextBox;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.TextBox AdditionalArgumentsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MachineHelpButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}