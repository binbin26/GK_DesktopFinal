using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GK_Desktop
{
    public partial class CheckingForm : Form
    {
        private bank_account account;

        private ListView listViewTransactions; // Declare the missing ListView
        public CheckingForm(bank_account account)
        {
            InitializeComponent();
            this.account = account;
            listViewTransactions = new ListView
            {
                Location = new Point(10, 200), // Adjust location as needed
                Size = new Size(500, 200),    // Adjust size as needed
                View = View.Details
            };


            // Add columns to the ListView
            listViewTransactions.Columns.Add("Transaction ID", 100);
            listViewTransactions.Columns.Add("Date", 100);
            listViewTransactions.Columns.Add("Amount", 100);
            listViewTransactions.Columns.Add("Type", 100);
            listViewTransactions.Columns.Add("Description", 100);
            this.Controls.Add(listViewTransactions);
            // Gán thông tin vào các label (đảm bảo bạn đã tạo các label này trên form)
            lblID.Text = $"Account ID: {account.account_id}";
            lblName.Text = $"Username: {account.owner_name}";
            lblPhone.Text = $"Password: {account.owner_phone}";
            lblType.Text = $"Account Type: {account.account_type}";
            lblAddress.Text = $"Address: {account.owner_address}";
            lblBalance.Text = $"Balance: {account.balance}";
            // Thêm các label khác nếu có thuộc tính khác
        }
        private string ShowInputDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 270, Width = 90, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }
        private void btnDes_Click(object sender, EventArgs e)
        {
            string input = ShowInputDialog("Nhập số tiền cần nộp:", "Deposit", "0");
            if (double.TryParse(input, out double amount) && amount > 0)
            {
                using (var conn = DataHelper.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new System.Data.SqlClient.SqlCommand(
                        "UPDATE bank_account SET balance = balance + @amount WHERE account_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@id", account.account_id.ToString());
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            account.balance += amount;
                            lblBalance.Text = $"Balance: {account.balance}";
                            MessageBox.Show("Nộp tiền thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            listViewTransactions.Items.Clear();
            using (var conn = DataHelper.GetConnection())
            {
                conn.Open();
                using (var cmd = new System.Data.SqlClient.SqlCommand(
                    "SELECT transaction_id, date, amount, type, description FROM transaction WHERE account_id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", account.account_id.ToString());
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ListViewItem(reader["transaction_id"].ToString());
                            item.SubItems.Add(reader["date"].ToString());
                            item.SubItems.Add(reader["amount"].ToString());
                            item.SubItems.Add(reader["type"].ToString());
                            item.SubItems.Add(reader["description"].ToString());
                            listViewTransactions.Items.Add(item);
                        }
                    }
                }
            }
        }
    }
}
