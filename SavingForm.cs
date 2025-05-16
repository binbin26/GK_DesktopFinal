using System;
using System.Windows.Forms;

namespace GK_Desktop
{
    public partial class SavingForm : Form
    {
        private bank_account _account;

        public SavingForm(bank_account account)
        {
            InitializeComponent();
            _account = account;
            InitializeAccountInfo();
        }

        private void InitializeAccountInfo()
        {
            // Create labels to display account info
            var lblAccountId = new Label { Text = $"Account ID: {_account.account_id}", Left = 20, Top = 20, AutoSize = true };
            var lblOwnerName = new Label { Text = $"Owner Name: {_account.owner_name}", Left = 20, Top = 50, AutoSize = true };
            var lblOwnerAddress = new Label { Text = $"Address: {_account.owner_address}", Left = 20, Top = 80, AutoSize = true };
            var lblOwnerPhone = new Label { Text = $"Phone: {_account.owner_phone}", Left = 20, Top = 110, AutoSize = true };

            // Create Back button
            var btnBack = new Button { Text = "Back", Left = 20, Top = 150, Width = 80 };
            btnBack.Click += (s, e) => { this.Close(); };

            // Add controls to the form
            this.Controls.Add(lblAccountId);
            this.Controls.Add(lblOwnerName);
            this.Controls.Add(lblOwnerAddress);
            this.Controls.Add(lblOwnerPhone);
            this.Controls.Add(btnBack);

            this.Text = "Saving Account Information";
            this.ClientSize = new System.Drawing.Size(350, 200);
        }
    }
}
