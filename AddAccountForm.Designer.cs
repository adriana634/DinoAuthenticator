namespace DinoAuthenticator
{
    partial class AddAccountForm
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
            this.accountNameInput = new System.Windows.Forms.TextBox();
            this.secretKeyInput = new System.Windows.Forms.TextBox();
            this.accountNameLabel = new System.Windows.Forms.Label();
            this.privateKeyLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accountNameInput
            // 
            this.accountNameInput.Location = new System.Drawing.Point(112, 13);
            this.accountNameInput.Name = "accountNameInput";
            this.accountNameInput.Size = new System.Drawing.Size(263, 23);
            this.accountNameInput.TabIndex = 0;
            // 
            // privateKeyInput
            // 
            this.secretKeyInput.Location = new System.Drawing.Point(112, 42);
            this.secretKeyInput.Name = "privateKeyInput";
            this.secretKeyInput.Size = new System.Drawing.Size(263, 23);
            this.secretKeyInput.TabIndex = 1;
            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.Location = new System.Drawing.Point(21, 16);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new System.Drawing.Size(85, 15);
            this.accountNameLabel.TabIndex = 2;
            this.accountNameLabel.Text = "Account name";
            // 
            // privateKeyLabel
            // 
            this.privateKeyLabel.AutoSize = true;
            this.privateKeyLabel.Location = new System.Drawing.Point(21, 45);
            this.privateKeyLabel.Name = "privateKeyLabel";
            this.privateKeyLabel.Size = new System.Drawing.Size(64, 15);
            this.privateKeyLabel.TabIndex = 3;
            this.privateKeyLabel.Text = "Private key";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(300, 83);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(219, 83);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddAccountForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(398, 116);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.privateKeyLabel);
            this.Controls.Add(this.accountNameLabel);
            this.Controls.Add(this.secretKeyInput);
            this.Controls.Add(this.accountNameInput);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(414, 155);
            this.MinimumSize = new System.Drawing.Size(414, 155);
            this.Name = "AddAccountForm";
            this.Text = "DinoAuthenticator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox accountNameInput;
        private TextBox secretKeyInput;
        private Label accountNameLabel;
        private Label privateKeyLabel;
        private Button saveButton;
        private Button cancelButton;
    }
}