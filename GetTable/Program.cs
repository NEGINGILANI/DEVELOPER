using System.Data.SqlClient;

Console.WriteLine("Enter server Name :...");
string serverName = Console.ReadLine();

Console.WriteLine("Enter Database Name :...");
string databaseName = Console.ReadLine();

Console.WriteLine("Enter User Name :...");
string userName = Console.ReadLine();

Console.WriteLine("Enter Password :...");
string password = Console.ReadLine();

//Console.WriteLine($"connection string is : \n Server={serverName} ; Initial catalog= {databaseName} ; User Id={userName} ; Password={password}");


var connString = @"Data Source=" + serverName + ";Initial Catalog="
                     + databaseName + ";Persist Security Info=True;User ID=" + userName + ";Password=" + password;

Console.WriteLine(connString);
SqlConnection conn = new SqlConnection(connString);


try
{
    Console.WriteLine("Openning Connection ...");

    //open connection
    conn.Open();

    Console.WriteLine("Connection successful!");
    SqlCommand cmd = new SqlCommand("select TABLE_NAME from  information_schema.tables  where TABLE_TYPE='BASE TABLE'", conn); 
    using (SqlDataReader reader = cmd.ExecuteReader())
{
    while (reader.Read())
    {
        Console.WriteLine(reader[0]);
    }
}

}
catch (Exception e)
{
    Console.WriteLine("Error: " + e.Message);
}

Console.Read();

