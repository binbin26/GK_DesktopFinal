using System;
using System.Numerics;
using System.Windows.Forms;

namespace GK_Desktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrAccountId = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra thông tin đăng nhập từ database (username hoặc account_id)
            using (var connection = DataHelper.GetConnection())
            using (var command = new System.Data.SqlClient.SqlCommand(
                "SELECT account_id, account_type FROM bank_account WHERE account_id = @account_id AND password = @password", connection))
            {
                command.Parameters.AddWithValue("@account_id", usernameOrAccountId);
                command.Parameters.AddWithValue("@password", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Đăng nhập thành công
                        var accountId = reader["account_id"].ToString();
                        var accountType = reader["account_type"].ToString();

                        // Chuyển hướng theo loại tài khoản
                        if (accountType == "Checking")
                        {
                            MessageBox.Show("Đăng nhập Checking thành công!");
                            var account = new bank_account { account_id = BigInteger.Parse(accountId), account_type = accountType };
                            new CheckingForm(account).Show();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập Saving thành công!");
                            // Inside the btnLogin_Click method
                            var account = new bank_account
                            {
                                account_id = BigInteger.Parse(accountId), // Convert string to BigInteger
                                account_type = accountType
                            };
                            new SavingForm(account).Show(); 
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
