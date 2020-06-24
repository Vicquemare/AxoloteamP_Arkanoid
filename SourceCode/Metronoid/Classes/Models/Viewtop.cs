using System.Data;
using Npgsql;
using Metronoid.Classes.Models;
using System;

namespace Metronoid.Classes.Controllers
{
    public class Viewtop
    {
        private NpgsqlConnection cn;
        private NpgsqlCommand cmd;
        private string sql;
        private DateTime Date;
        private int iduser;
        
        public int Iduser
                {
                    get => iduser;
                    set => iduser = value;
                }
        
                public DateTime date
                {
                    get => Date;
                    set => Date = value;
                }
        
        public Viewtop(){
        cn = connexion.connectDatabase();
        }
        
        public DataTable Top()
                {
                    cn.Open();
                    sql = "SELECT * FROM score order by score DESC FETCH FIRST 10 ROWS ONLY;";
                    cmd = new NpgsqlCommand(sql, cn);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    cn.Close();
                    return dt;
                }
        public void InsertScore(){
        cn.Open();
        sql = "INSERT INTO score(createdate,score) VALUES (@score);";
        cmd = new NpgsqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("createdate", Date); 
        var result = cmd.ExecuteNonQuery();
        cn.Close();
                
         }
    }
}