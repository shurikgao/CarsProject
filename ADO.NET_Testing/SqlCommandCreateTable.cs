using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NET_Testing
{
    internal class SqlCommandCreateTable
    {
        public static void CreateTable()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sqlCommandText =
                    "Create Table BrokenCars(Id int not null identity(1,1) primary key, name NVARCHAR(255))";
                using (var sqlCommand = new SqlCommand(sqlCommandText, sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static void ExecuteScalarTest()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sqlCommandText = "SELECT COUNT(*) From BrokenCars;";
                using (var sqlCommand = new SqlCommand(sqlCommandText, sqlConnection))
                {
                    var count = sqlCommand.ExecuteScalar();
                }
            }
        }

        public static void ExecuteReaderTest()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sqlCommandText = "SELECT * From BrokenCars;";
                using (var sqlCommand = new SqlCommand(sqlCommandText, sqlConnection))
                {
                    var carReader = sqlCommand.ExecuteReader();
                    while (carReader.Read())
                    {
                        var id = (int) carReader["Id"];
                        var name = (string) carReader["name"];
                        Console.WriteLine("Car Id={0},Name={1}", id, name);
                    }
                }
            }
        }

        public static void ParametrizationQuery()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sqlCommantText = "SELECT * From BrokenCars WHERE Id=@id;";
                using (var sqlCommand = new SqlCommand(sqlCommantText, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int);
                    sqlCommand.Parameters["@id"].Value = 1;

                    var carReader = sqlCommand.ExecuteReader();
                    while (carReader.Read())
                    {
                        var id = (int) carReader["Id"];
                        var name = (string) carReader["name"];
                        Console.WriteLine("Car Id={0},Name={1}", id, name);
                    }
                }
            }
        }
    }
}