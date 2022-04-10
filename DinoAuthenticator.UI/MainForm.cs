using DinoAuthenticator.AccountsTotp;
using Timer = System.Windows.Forms.Timer;

namespace DinoAuthenticator.UI;

public partial class MainForm : Form
{
    private static readonly int TIMER_INTERVAL = 1000;
    private static readonly int TIMER_LABEL_RED_THRESHOLD = 10;
    private static readonly string ACCOUNTS_FILE_NAME = "accounts.bin";

    private Timer timer;
    private int remainingTotpSeconds;

    private AccountsManager accountsManager;

    public MainForm() : base()
    {
        InitializeComponent();

        this.timerLabel.ForeColor = Color.DodgerBlue;

        this.timer = new Timer();
        this.timer.Interval = MainForm.TIMER_INTERVAL;
        this.timer.Tick += new EventHandler(this.Timer_tick);

        this.accountsManager = new AccountsManager(MainForm.ACCOUNTS_FILE_NAME);
    }

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose(); 
            }

            this.timer.Tick -= this.Timer_tick;
            this.timer.Dispose();
        }

        base.Dispose(disposing);
    }

    protected override void OnLoad(EventArgs e)
    {
        string[] accountNames = this.accountsManager.GetAccountNames();
        this.accountSelector.Items.AddRange(accountNames);

        base.OnLoad(e);
    }

    private void computeAndDisplayTotp()
    {
        this.timer.Stop();

        string selectedAccount = (string)this.accountSelector.SelectedItem;
        this.accountNameLabel.Text = selectedAccount;

        byte[] selectedAccountPrivateKey = this.accountsManager.GetAccountSecretKey(selectedAccount);
        ComputedTotp computedTotp = AccountsManager.ComputeTotp(selectedAccountPrivateKey);

        this.tokenLabel.Text = computedTotp.TotpCode;
        this.remainingTotpSeconds = computedTotp.InitialRemainingTotpSeconds;

        this.timer.Start();
    }

    private void Timer_tick(object? sender, EventArgs e)
    {
        this.timerLabel.Text = this.remainingTotpSeconds.ToString();

        if (this.remainingTotpSeconds == 0)
        {
            this.computeAndDisplayTotp();
        }
        else
        {
            this.timerLabel.ForeColor = (this.remainingTotpSeconds <= MainForm.TIMER_LABEL_RED_THRESHOLD) 
                ? Color.Red 
                : Color.DodgerBlue;

            this.remainingTotpSeconds -= 1;
        }
    }

    private void accountSelector_SelectionChangeCommitted(object sender, EventArgs e)
    {
        this.computeAndDisplayTotp();
    }

    private void showAccountForm()
    {
        AddAccountForm addAccountForm = new AddAccountForm(this.accountsManager);

        addAccountForm.ShowDialog(this);

        addAccountForm.Dispose();
    }

    private void reloadAccounts()
    {
        string[] accountNames = this.accountsManager.GetAccountNames();
        this.accountSelector.Items.Clear();
        this.accountSelector.Items.AddRange(accountNames);
    }

    private void addAccountButton_Click(object sender, EventArgs e)
    {
        showAccountForm();
        reloadAccounts();
    }
}
