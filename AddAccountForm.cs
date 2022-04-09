using System.Security.Cryptography;

namespace DinoAuthenticator
{
    public partial class AddAccountForm : Form
    {
        public AddAccountForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string accountName = this.accountNameInput.Text;
            string secretKeyInput = this.secretKeyInput.Text;

            if (accountName.Trim() != "" && secretKeyInput.Trim() != "")
            {
                Account account = new Account(accountName, secretKeyInput);

                try
                {
                    AccountsManager.SaveAccount(account);
                }
                catch (Exception ex) when (ex is IOException || 
                                           ex is CryptographicException)
                {
                    MessageBox.Show("An error has ocurred while trying to save account");
                }

                this.Close();
            }
        }
    }
}
