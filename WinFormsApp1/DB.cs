using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems;");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }

        /*static string DBConnect = "user=root; host=localhost; password=IvanVladimirov888; database=Сomputer_systems";
        static public MySqlDataAdapter msDataAdapter;
        static MySqlConnection myConnect;
        static public MySqlCommand msCommand;

        public static bool ConnectionDB()
        {
            try
            {
                myConnect = new MySqlConnection(DBConnect);
                myConnect.Open();
                msCommand = new MySqlCommand();
                msCommand.Connection = myConnect;
                msDataAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static void CloseDB()
        {
            myConnect.Close();
        }
        public MySqlConnection getConnection()
        {
            return myConnect;
        }*/
   }
}