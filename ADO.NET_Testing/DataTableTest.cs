using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Testing
{
    internal class DataTableTest
    {
        public static void DataAdapterExample()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommandText = "SELECT * FROM BrokenCars;";
                var dataAdapter = new SqlDataAdapter(sqlCommandText, sqlConnection);

                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                var insertText = "INSERT INTO BrokenCars(name) VALUES(@Name)";
                var insertCommand = new SqlCommand(insertText, sqlConnection);
                insertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 255, "name");
                dataAdapter.InsertCommand = insertCommand;
                var row = dataTable.NewRow();
                row["Name"] = "ZAZ";
                dataTable.Rows.Add(row);
                dataAdapter.Update(dataTable);

                //var deleteRow = dataTable.Rows[4];
                //dataTable.Rows.Remove(deleteRow);
                //dataAdapter.Update(dataTable);

                sqlConnection.Open();
                var delFromTable = @"DELETE FROM BrokenCars WHERE ID > 4;";
                var delCommand = new SqlCommand(delFromTable, sqlConnection);
                dataAdapter.DeleteCommand = delCommand;
                dataAdapter.DeleteCommand.ExecuteNonQuery();
                dataAdapter.Update(dataTable);
            }
        }
    }
}