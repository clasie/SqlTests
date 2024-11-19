

using System;
using System.Data.SqlClient;
using System.Text;

/**
 * using the usings, best practices
 * https://stackoverflow.com/questions/18373461/execute-insert-command-and-return-inserted-id-in-sql
 */

namespace SqlTests.Data;

public static class SqlServer
{
    private static SqlConnection getConnection() {
        return new SqlConnection(Constantes.CONN_STRING);
    }
    public static string ReadData() {
        SqlConnection? conn = null;
        SqlCommand? command = null;
        try
        {
            string sql = "SELECT * FROM sales.customers";

            using (conn = getConnection())
            {
                try
                {
                    conn.Open();

                    using (command = new SqlCommand(sql, conn))
                    {
                        var dataReader = command.ExecuteReader();
                        StringBuilder sb = new StringBuilder();
                        while (dataReader.Read())
                        {
                            sb.AppendLine($" {dataReader.GetValue(0)} - {dataReader.GetValue(1)}");
                        }
                        //command.Transaction.Commit();
                        //command.Transaction.
                        return sb.ToString();
                    }
                }
                catch (Exception ex) {
                    //conn.tran;
                   
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        catch (Exception ex) {
            MessageBox.Show(ex.ToString());
        }
        finally {
            command?.Dispose(); 
            conn?.Close();
        }
        return string.Empty;
    }
    public static void UpdateData()
    {
        SqlConnection? conn = null;
        SqlCommand? command = null;
        try
        {
            conn = getConnection();
            conn.Open();

            var randomNewFirstName = GetRandomText();
            var sql = $"UPDATE sales.customers SET first_name = '{randomNewFirstName}' WHERE customer_id = 1";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = new SqlCommand(sql, conn);
            adapter.UpdateCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString()); 
        }
        finally {
            command?.Dispose();
            conn?.Close(); 
        }
    }
    public static int InsertData() {
        SqlConnection? conn = null;
        SqlCommand? command = null;
        int res = 0;
        try {
            conn = getConnection();
            conn.Open();

            var fname = GetRandomText();
            var lastName = GetRandomText();
            var email = GetRandomText();

            var sql = $"INSERT INTO sales.customers (first_name, last_name, email) VALUES('{fname}', '{lastName}', '{email}'); SELECT SCOPE_IDENTITY()";
            
            command = new SqlCommand(sql, conn);
            //... TODO... command.Parameters.add
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            res = Convert.ToInt32(adapter.InsertCommand.ExecuteScalar());
            //var dataAdapter = new 
        }
        catch (Exception ex) { 
            MessageBox.Show(ex.ToString()); 
        }
        finally {
            command?.Dispose();
            conn?.Close();
        }
        return res;
    }
    private static string GetRandomText() {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);
        return finalString;
    }
}
