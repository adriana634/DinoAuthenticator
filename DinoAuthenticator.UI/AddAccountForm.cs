using DinoAuthenticator.AccountsTotp;

namespace DinoAuthenticator.UI;

public partial class AddAccountForm : Form
{
    private AccountsManager accountsManager;

    public AddAccountForm(AccountsManager accountsManager) : base()
    {
        InitializeComponent();

        this.accountsManager = accountsManager;
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
                this.accountsManager.SaveAccount(account);
            }
            catch (Exception)
            {
                MessageBox.Show("An error has ocurred while trying to save account");
            }

            this.Close();
        }
    }
}
