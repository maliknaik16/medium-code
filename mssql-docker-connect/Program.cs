
using System;
using System.Data.SqlClient;

namespace mssql_docker_connect
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                // Initialize the connection string.
                string connetionString = @"Data Source=localhost;User ID=sa;Password=C#1234SQLServer";

                // Connect to the SQL Server using the connection string.
                SqlConnection conn = new SqlConnection(connetionString);

                // Open the connection.
                conn.Open();

                // Set the SQL query.
                string sql = "SELECT "
                             + "SERVERPROPERTY('MachineName') AS ComputerName,"
                             + "SERVERPROPERTY('ServerName') AS InstanceName,"
                             + "SERVERPROPERTY('Edition') AS Edition,"
                             + "SERVERPROPERTY('ProductVersion') AS ProductVersion,"
                             + "SERVERPROPERTY('ProductLevel') AS ProductLevel";

                // Instantiate the SqlCommand object with the SQL query and connection.
                SqlCommand command = new SqlCommand(sql, conn);

                // Get the data reader.
                SqlDataReader dataReader = command.ExecuteReader();

                // Read the first row.
                dataReader.Read();

                // Print each column.
                Console.WriteLine("ComputerName: " + dataReader.GetValue(0));
                Console.WriteLine("InstanceName: " + dataReader.GetValue(1));
                Console.WriteLine("Edition: " + dataReader.GetValue(2));
                Console.WriteLine("ProductVersion: " + dataReader.GetValue(3));
                Console.WriteLine("ProductLevel: " + dataReader.GetValue(4));

                // Finally, Close the connection.
                conn.Close();
            } catch(Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
