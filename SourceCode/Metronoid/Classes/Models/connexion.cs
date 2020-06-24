using System;
using System.Windows.Forms;
using Npgsql;

namespace Metronoid.Classes.Models
{
    public static class connexion
    {
        private static NpgsqlConnection cn;
        private static string str_connect;
        private static string host;
        private static string port;
        private static string user_id;
        private static string password;
        private static string database;
        
        static connexion()
        {
            host = "localhost";
            user_id = "postgres";
            port = "5432";
            password = "Cynth14";
            database = "juego";
        }
        
        public static NpgsqlConnection connectDatabase()
        {
            try
            {
                str_connect = $"Server={host};Port={port}; User Id={user_id}; Password={password}; Database={database}";
                cn = new NpgsqlConnection(str_connect);
                return cn;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
    
}