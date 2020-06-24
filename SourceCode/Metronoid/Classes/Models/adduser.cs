using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using Metronoid.Classes.Models;

namespace Metronoid.Classes.Models
{
    public class adduser
    {
        private NpgsqlConnection cn;
        private NpgsqlCommand cmd;
        
        private string sql;
        private int idUser;
        private string username;
        
        public adduser()
        {
            cn = connexion.connectDatabase();
        }
        
        public int IdUser
        {
            get => idUser;
            set => idUser = value;
        }
        public string Username
        {
            get => username;
            set => username = value;
        }
        
        public bool Verifyusername()
        {
            cn.Open();
            sql = "SELECT iduser FROM users  WHERE nick = @nick;";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("nick",username );
            DataTable  dt  = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            return (dt.Rows.Count!=0) ? true : false;
        }
        
        public DataTable login()
        {
            DataTable dt;
            cn.Open();
            sql = "SELECT iduser FROM users u WHERE  u.nick=@nick";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("nick", username);
            dt  = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cn.Close();
            if (dt.Rows.Count<=0)
            {
                dt = null;
            }
            return dt;
          
        }
        public bool InsertUser()
        {
            cn.Open();
            sql = "INSERT INTO users(nick) VALUES (@nick);";
            cmd = new NpgsqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("nick", username);
            cmd.Prepare();
            var result = cmd.ExecuteNonQuery();
            cn.Close();
            return result == 1;
        }
        
    }
}