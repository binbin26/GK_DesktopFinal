using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Numerics;

namespace GK_Desktop
{
    public class BankDbContext
    {
        private readonly string _connectionString;

        public BankDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<transaction> GetTransactions()
        {
            var transactions = new List<transaction>();

            using (var connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                var command = new OleDbCommand("SELECT trans_id, account_id, happend_time, action_desc, note FROM [transaction]", connection);

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
            }

            return transactions;
        }


        // Thêm các phương thức CRUD khác nếu cần
    }
}
