namespace DinoAuthenticator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.accountNameLabel = new System.Windows.Forms.Label();
            this.tokenLabel = new System.Windows.Forms.Label();
            this.accountSelector = new System.Windows.Forms.ComboBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.addAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.accountNameLabel.Location = new System.Drawing.Point(77, 62);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new System.Drawing.Size(179, 47);
            this.accountNameLabel.TabIndex = 0;
            this.accountNameLabel.Text = "Account #";
            // 
            // tokenLabel
            // 
            this.tokenLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tokenLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.tokenLabel.Location = new System.Drawing.Point(94, 109);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(144, 47);
            this.tokenLabel.TabIndex = 1;
            this.tokenLabel.Text = "000000";
            // 
            // accountSelector
            // 
            this.accountSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.accountSelector.FormattingEnabled = true;
            this.accountSelector.Location = new System.Drawing.Point(12, 12);
            this.accountSelector.Name = "accountSelector";
            this.accountSelector.Size = new System.Drawing.Size(244, 23);
            this.accountSelector.TabIndex = 2;
            this.accountSelector.SelectionChangeCommitted += new System.EventHandler(this.accountSelector_SelectionChangeCommitted);
            // 
            // timerLabel
            // 
            this.timerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timerLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timerLabel.Location = new System.Drawing.Point(291, 196);
            this.timerLabel.MaximumSize = new System.Drawing.Size(50, 37);
            this.timerLabel.MinimumSize = new System.Drawing.Size(50, 37);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(50, 37);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "30";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addAccountButton
            // 
            this.addAccountButton.Location = new System.Drawing.Point(261, 12);
            this.addAccountButton.Name = "addAccountButton";
            this.addAccountButton.Size = new System.Drawing.Size(88, 23);
            this.addAccountButton.TabIndex = 4;
            this.addAccountButton.Text = "Add Account";
            this.addAccountButton.UseVisualStyleBackColor = true;
            this.addAccountButton.Click += new System.EventHandler(this.addAccountButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 242);
            this.Controls.Add(this.addAccountButton);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.accountSelector);
            this.Controls.Add(this.tokenLabel);
            this.Controls.Add(this.accountNameLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(369, 281);
            this.MinimumSize = new System.Drawing.Size(369, 281);
            this.Name = "MainForm";
            this.Text = "DinoAuthenticator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label accountNameLabel;
        private Label tokenLabel;
        private ComboBox accountSelector;
        private Label timerLabel;
        private Button addAccountButton;
    }
}