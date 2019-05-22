using System.Data.SQLite;
using System.IO;


namespace TestExamAssignment.Database
{
   public class DatabaseHandler
    {
        public SQLiteConnection myConnection;

        public DatabaseHandler() {
            myConnection = new SQLiteConnection("Data Source=TestDatabase");

            if (!File.Exists("./TestDatabase"))
            {
                SQLiteConnection.CreateFile("TestDatabase");
                System.Console.WriteLine("Database is created");
            }          
        }
        public void OpenConnection() {

            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection() {

            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}
