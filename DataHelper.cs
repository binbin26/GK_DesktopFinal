using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
//using Microsoft.IdentityModel.Protocols;

namespace GK_Desktop
{
    public static class DataHelper
    {
        public static readonly string connectionString;

        static DataHelper()
        {
            var connStr = ConfigurationManager.ConnectionStrings["Bank"];
            if (connStr == null)
                throw new InvalidOperationException("Connection string 'Bank' not found in configuration.");
            connectionString = connStr.ConnectionString;
        }

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        // Ví dụ: Lấy danh sách transaction từ database bằng ADO.NET
        public static List<transaction> GetTransactions()
        {
            var transactions = new List<transaction>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT trans_id, account_id, happend_time, action_desc, note FROM [transaction]", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var trans = new transaction
                    {
                        trans_id = Guid.Parse(reader["trans_id"].ToString()), // Fixed conversion to Guid
                        account_id = BigInteger.Parse(reader["account_id"].ToString()), // Fixed conversion to BigInteger
                        happend_time = Convert.ToDateTime(reader["happend_time"]),
                        action_desc = reader["action_desc"].ToString(),
                        note = reader["note"].ToString()
                    };
                    transactions.Add(trans);
                }
            }
            return transactions;
        }

        public static bool Login(string accountId, string password, out string accountType)
        {
            accountType = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT account_type FROM bank_account WHERE account_id = @accountId AND password = @password", connection))
            {
                command.Parameters.AddWithValue("@accountId", accountId);
                command.Parameters.AddWithValue("@password", password);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    accountType = result.ToString();
                    AddTransaction(accountId, "Login", "Đăng nhập thành công");
                    return true;
                }
                return false;
            }
        }
        public static List<transaction> GetTransactionsByAccountId(string accountId)
        {
            var transactions = new List<transaction>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [transaction] WHERE account_id = @accountId", connection))
            {
                command.Parameters.AddWithValue("@accountId", accountId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new transaction
                        {
                            trans_id = Guid.Parse(reader["trans_id"].ToString()),
                            account_id = BigInteger.Parse(reader["account_id"].ToString()),
                            happend_time = Convert.ToDateTime(reader["happend_time"]),
                            action_desc = reader["action_desc"].ToString(),
                            note = reader["note"].ToString()
                        });
                    }
                }
            }
            return transactions;
        }
        public static bank_account GetAccountById(string accountId)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM bank_account WHERE account_id = @accountId", connection))
            {
                command.Parameters.AddWithValue("@accountId", accountId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new bank_account
                        {
                            account_id = BigInteger.Parse(reader["account_id"].ToString()),
                            owner_name = reader["owner_name"].ToString(),
                            owner_address = reader["owner_address"].ToString(),
                            owner_phone = reader["owner_phone"].ToString(),
                            balance = (double)Convert.ToDecimal(reader["balance"]),
                            account_type = reader["account_type"].ToString(),
                            password = reader["password"].ToString()
                        };
                    }
                }
            }
            return null;
        }
        public static bool Deposit(string accountId, decimal amount)
        {
            if (amount <= 0) return false;
            using (var connection = GetConnection())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var updateCmd = new SqlCommand("UPDATE bank_account SET balance = balance + @amount WHERE account_id = @accountId", connection, transaction);
                    updateCmd.Parameters.AddWithValue("@amount", amount);
                    updateCmd.Parameters.AddWithValue("@accountId", accountId);
                    int rows = updateCmd.ExecuteNonQuery();

                    if (rows == 1)
                    {
                        AddTransaction(accountId, "Deposit", $"Nộp tiền: {amount}", connection, transaction);
                        transaction.Commit();
                        return true;
                    }
                    transaction.Rollback();
                    return false;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public static void AddTransaction(string accountId, string actionDesc, string note, SqlConnection conn = null, SqlTransaction tran = null)
        {
            bool localConn = false;
            if (conn == null)
            {
                conn = GetConnection();
                localConn = true;
            }
            using (var command = new SqlCommand("INSERT INTO [transaction] (trans_id, account_id, happend_time, action_desc, note) VALUES (@transId, @accountId, @time, @action, @note)", conn, tran))
            {
                command.Parameters.AddWithValue("@transId", Guid.NewGuid());
                command.Parameters.AddWithValue("@accountId", accountId);
                command.Parameters.AddWithValue("@time", DateTime.Now);
                command.Parameters.AddWithValue("@action", actionDesc);
                command.Parameters.AddWithValue("@note", note);
                command.ExecuteNonQuery();
            }
            if (localConn) conn.Dispose();
        }

    }
}
