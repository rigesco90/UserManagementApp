using MySql.Data.MySqlClient;

namespace UserManagementApp.Utils
{
    public class ConectionDBUtil
    {
        private static string SERVER = "server=127.0.0.1";
        private static string DATABASE = "database=managementuserbd";
        private static string USER = "Uid=root";
        private static string PASWORD = "pwd=;";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection con = new MySqlConnection(SERVER +";" +DATABASE +";"+ USER + ";" + PASWORD);
            con.Open();
            return con;
        }
    }
}