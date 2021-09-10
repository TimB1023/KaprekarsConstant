
namespace KaprekarsWinForm
{
    partial class KaprekarsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chooseFolderButton = new System.Windows.Forms.Button();
            this.calcOutputTextBox = new System.Windows.Forms.TextBox();
            this.startCalcButton = new System.Windows.Forms.Button();
            this.currentValueLabel = new System.Windows.Forms.Label();
            this.currentFolderLabel = new System.Windows.Forms.Label();
            this.currentFolderTitleLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileInStandardAppButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileInExplorerButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseFolderButton
            // 
            this.chooseFolderButton.Location = new System.Drawing.Point(53, 12);
            this.chooseFolderButton.Name = "chooseFolderButton";
            this.chooseFolderButton.Size = new System.Drawing.Size(299, 30);
            this.chooseFolderButton.TabIndex = 0;
            this.chooseFolderButton.Text = "Click here to change output folder";
            this.chooseFolderButton.UseVisualStyleBackColor = true;
            this.chooseFolderButton.Click += new System.EventHandler(this.chooseFolderButton_Click);
            // 
            // calcOutputTextBox
            // 
            this.calcOutputTextBox.AcceptsReturn = true;
            this.calcOutputTextBox.Location = new System.Drawing.Point(461, 117);
            this.calcOutputTextBox.MaxLength = 327670;
            this.calcOutputTextBox.Multiline = true;
            this.calcOutputTextBox.Name = "calcOutputTextBox";
            this.calcOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.calcOutputTextBox.Size = new System.Drawing.Size(299, 275);
            this.calcOutputTextBox.TabIndex = 20;
            // 
            // startCalcButton
            // 
            this.startCalcButton.Location = new System.Drawing.Point(461, 12);
            this.startCalcButton.Name = "startCalcButton";
            this.startCalcButton.Size = new System.Drawing.Size(299, 30);
            this.startCalcButton.TabIndex = 2;
            this.startCalcButton.Text = "Click here to start the calculation";
            this.startCalcButton.UseVisualStyleBackColor = true;
            this.startCalcButton.Click += new System.EventHandler(this.startCalcButton_Click);
            // 
            // currentValueLabel
            // 
            this.currentValueLabel.AutoSize = true;
            this.currentValueLabel.BackColor = System.Drawing.SystemColors.Window;
            this.currentValueLabel.Location = new System.Drawing.Point(461, 72);
            this.currentValueLabel.MaximumSize = new System.Drawing.Size(299, 30);
            this.currentValueLabel.MinimumSize = new System.Drawing.Size(299, 30);
            this.currentValueLabel.Name = "currentValueLabel";
            this.currentValueLabel.Size = new System.Drawing.Size(299, 30);
            this.currentValueLabel.TabIndex = 3;
            this.currentValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentFolderLabel
            // 
            this.currentFolderLabel.AutoSize = true;
            this.currentFolderLabel.BackColor = System.Drawing.SystemColors.Window;
            this.currentFolderLabel.Location = new System.Drawing.Point(53, 72);
            this.currentFolderLabel.MaximumSize = new System.Drawing.Size(299, 30);
            this.currentFolderLabel.MinimumSize = new System.Drawing.Size(299, 30);
            this.currentFolderLabel.Name = "currentFolderLabel";
            this.currentFolderLabel.Size = new System.Drawing.Size(299, 30);
            this.currentFolderLabel.TabIndex = 3;
            this.currentFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentFolderTitleLabel
            // 
            this.currentFolderTitleLabel.AutoSize = true;
            this.currentFolderTitleLabel.Location = new System.Drawing.Point(53, 54);
            this.currentFolderTitleLabel.Name = "currentFolderTitleLabel";
            this.currentFolderTitleLabel.Size = new System.Drawing.Size(83, 15);
            this.currentFolderTitleLabel.TabIndex = 4;
            this.currentFolderTitleLabel.Text = "Current Folder";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "You can open your file here";
            // 
            // openFileInStandardAppButton
            // 
            this.openFileInStandardAppButton.Location = new System.Drawing.Point(53, 131);
            this.openFileInStandardAppButton.Name = "openFileInStandardAppButton";
            this.openFileInStandardAppButton.Size = new System.Drawing.Size(299, 30);
            this.openFileInStandardAppButton.TabIndex = 2;
            this.openFileInStandardAppButton.Text = "Click here to open file in standard csv application";
            this.openFileInStandardAppButton.UseVisualStyleBackColor = true;
            this.openFileInStandardAppButton.Click += new System.EventHandler(this.openFileInStandardAppButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current value being calculated";
            // 
            // openFileInExplorerButton
            // 
            this.openFileInExplorerButton.Location = new System.Drawing.Point(53, 187);
            this.openFileInExplorerButton.Name = "openFileInExplorerButton";
            this.openFileInExplorerButton.Size = new System.Drawing.Size(299, 30);
            this.openFileInExplorerButton.TabIndex = 2;
            this.openFileInExplorerButton.Text = "Click here to see file in Explorer";
            this.openFileInExplorerButton.UseVisualStyleBackColor = true;
            this.openFileInExplorerButton.Click += new System.EventHandler(this.openFileInExplorerButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(128, 362);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // KaprekarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentFolderTitleLabel);
            this.Controls.Add(this.currentFolderLabel);
            this.Controls.Add(this.currentValueLabel);
            this.Controls.Add(this.openFileInExplorerButton);
            this.Controls.Add(this.openFileInStandardAppButton);
            this.Controls.Add(this.startCalcButton);
            this.Controls.Add(this.calcOutputTextBox);
            this.Controls.Add(this.chooseFolderButton);
            this.Name = "KaprekarsForm";
            this.Text = "Calculate iterations to reach Kaprekar\'s constant from 1000 to 999";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button chooseFolderButton;
        private System.Windows.Forms.TextBox calcOutputTextBox;
        private System.Windows.Forms.Button startCalcButton;
        private System.Windows.Forms.Label currentValueLabel;
        private System.Windows.Forms.Label currentFolderLabel;
        private System.Windows.Forms.Label currentFolderTitleLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openFileInStandardAppButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openFileInExplorerButton;
        private System.Windows.Forms.Button closeButton;
    }
}

