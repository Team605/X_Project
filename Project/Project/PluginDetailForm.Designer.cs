namespace Project
{
    partial class PluginDetailForm
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
            this.stateLabel = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.uninstallRadioButton = new System.Windows.Forms.RadioButton();
            this.installRadioButton = new System.Windows.Forms.RadioButton();
            this.stopRadioButton = new System.Windows.Forms.RadioButton();
            this.activeRadioButton = new System.Windows.Forms.RadioButton();
            this.stateDetialLabel = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // stateLabel
            // 
            this.stateLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stateLabel.Location = new System.Drawing.Point(25, 26);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(83, 27);
            this.stateLabel.TabIndex = 0;
            this.stateLabel.Text = "状态";
            this.stateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.uninstallRadioButton);
            this.groupBox.Controls.Add(this.installRadioButton);
            this.groupBox.Controls.Add(this.stopRadioButton);
            this.groupBox.Controls.Add(this.activeRadioButton);
            this.groupBox.Location = new System.Drawing.Point(50, 56);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 114);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            // 
            // uninstallRadioButton
            // 
            this.uninstallRadioButton.AutoSize = true;
            this.uninstallRadioButton.Location = new System.Drawing.Point(7, 90);
            this.uninstallRadioButton.Name = "uninstallRadioButton";
            this.uninstallRadioButton.Size = new System.Drawing.Size(47, 16);
            this.uninstallRadioButton.TabIndex = 3;
            this.uninstallRadioButton.TabStop = true;
            this.uninstallRadioButton.Text = "卸载";
            this.uninstallRadioButton.UseVisualStyleBackColor = true;
            this.uninstallRadioButton.CheckedChanged += new System.EventHandler(this.uninstallRadioButton_CheckedChanged);
            // 
            // installRadioButton
            // 
            this.installRadioButton.AutoSize = true;
            this.installRadioButton.Location = new System.Drawing.Point(7, 67);
            this.installRadioButton.Name = "installRadioButton";
            this.installRadioButton.Size = new System.Drawing.Size(47, 16);
            this.installRadioButton.TabIndex = 2;
            this.installRadioButton.TabStop = true;
            this.installRadioButton.Text = "安装";
            this.installRadioButton.UseVisualStyleBackColor = true;
            this.installRadioButton.CheckedChanged += new System.EventHandler(this.installRadioButton_CheckedChanged);
            // 
            // stopRadioButton
            // 
            this.stopRadioButton.AutoSize = true;
            this.stopRadioButton.Location = new System.Drawing.Point(7, 44);
            this.stopRadioButton.Name = "stopRadioButton";
            this.stopRadioButton.Size = new System.Drawing.Size(47, 16);
            this.stopRadioButton.TabIndex = 1;
            this.stopRadioButton.TabStop = true;
            this.stopRadioButton.Text = "停止";
            this.stopRadioButton.UseVisualStyleBackColor = true;
            this.stopRadioButton.CheckedChanged += new System.EventHandler(this.stopRadioButton_CheckedChanged);
            // 
            // activeRadioButton
            // 
            this.activeRadioButton.AutoSize = true;
            this.activeRadioButton.Location = new System.Drawing.Point(7, 21);
            this.activeRadioButton.Name = "activeRadioButton";
            this.activeRadioButton.Size = new System.Drawing.Size(47, 16);
            this.activeRadioButton.TabIndex = 0;
            this.activeRadioButton.TabStop = true;
            this.activeRadioButton.Text = "激活";
            this.activeRadioButton.UseVisualStyleBackColor = true;
            this.activeRadioButton.CheckedChanged += new System.EventHandler(this.activeRadioButton_CheckedChanged);
            // 
            // stateDetialLabel
            // 
            this.stateDetialLabel.Location = new System.Drawing.Point(114, 26);
            this.stateDetialLabel.Name = "stateDetialLabel";
            this.stateDetialLabel.Size = new System.Drawing.Size(103, 27);
            this.stateDetialLabel.TabIndex = 2;
            this.stateDetialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PluginDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.stateDetialLabel);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.stateLabel);
            this.Name = "PluginDetailForm";
            this.Text = "PluginDetailForm";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton uninstallRadioButton;
        private System.Windows.Forms.RadioButton installRadioButton;
        private System.Windows.Forms.RadioButton stopRadioButton;
        private System.Windows.Forms.RadioButton activeRadioButton;
        private System.Windows.Forms.Label stateDetialLabel;
    }
}