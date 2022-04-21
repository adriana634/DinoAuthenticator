namespace DinoAuthenticator.UI;

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
            this.secretKeyLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clipboardQrCodePictureBox = new System.Windows.Forms.PictureBox();
            this.importPrivateKeyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clipboardQrCodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // accountNameInput
            // 
            this.accountNameInput.Location = new System.Drawing.Point(112, 250);
            this.accountNameInput.Name = "accountNameInput";
            this.accountNameInput.Size = new System.Drawing.Size(263, 23);
            this.accountNameInput.TabIndex = 0;
            // 
            // secretKeyInput
            // 
            this.secretKeyInput.Location = new System.Drawing.Point(112, 279);
            this.secretKeyInput.Name = "secretKeyInput";
            this.secretKeyInput.Size = new System.Drawing.Size(263, 23);
            this.secretKeyInput.TabIndex = 1;
            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.Location = new System.Drawing.Point(21, 253);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new System.Drawing.Size(85, 15);
            this.accountNameLabel.TabIndex = 2;
            this.accountNameLabel.Text = "Account name";
            // 
            // secretKeyLabel
            // 
            this.secretKeyLabel.AutoSize = true;
            this.secretKeyLabel.Location = new System.Drawing.Point(21, 282);
            this.secretKeyLabel.Name = "secretKeyLabel";
            this.secretKeyLabel.Size = new System.Drawing.Size(60, 15);
            this.secretKeyLabel.TabIndex = 3;
            this.secretKeyLabel.Text = "Secret key";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(300, 320);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(219, 320);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // clipboardQrCodePictureBox
            // 
            this.clipboardQrCodePictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.clipboardQrCodePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clipboardQrCodePictureBox.Location = new System.Drawing.Point(126, 12);
            this.clipboardQrCodePictureBox.Name = "clipboardQrCodePictureBox";
            this.clipboardQrCodePictureBox.Size = new System.Drawing.Size(150, 150);
            this.clipboardQrCodePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clipboardQrCodePictureBox.TabIndex = 6;
            this.clipboardQrCodePictureBox.TabStop = false;
            // 
            // importPrivateKeyButton
            // 
            this.importPrivateKeyButton.Location = new System.Drawing.Point(126, 186);
            this.importPrivateKeyButton.Name = "importPrivateKeyButton";
            this.importPrivateKeyButton.Size = new System.Drawing.Size(150, 39);
            this.importPrivateKeyButton.TabIndex = 7;
            this.importPrivateKeyButton.Text = "Import QR code from clipboard";
            this.importPrivateKeyButton.UseVisualStyleBackColor = true;
            this.importPrivateKeyButton.Click += new System.EventHandler(this.importPrivateKeyButton_Click);
            // 
            // AddAccountForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(398, 361);
            this.Controls.Add(this.importPrivateKeyButton);
            this.Controls.Add(this.clipboardQrCodePictureBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.secretKeyLabel);
            this.Controls.Add(this.accountNameLabel);
            this.Controls.Add(this.secretKeyInput);
            this.Controls.Add(this.accountNameInput);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(414, 400);
            this.MinimumSize = new System.Drawing.Size(414, 400);
            this.Name = "AddAccountForm";
            this.Text = "DinoAuthenticator";
            ((System.ComponentModel.ISupportInitialize)(this.clipboardQrCodePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TextBox accountNameInput;
    private TextBox secretKeyInput;
    private Label accountNameLabel;
    private Label secretKeyLabel;
    private Button saveButton;
    private Button cancelButton;
    private PictureBox clipboardQrCodePictureBox;
    private Button importPrivateKeyButton;
}
