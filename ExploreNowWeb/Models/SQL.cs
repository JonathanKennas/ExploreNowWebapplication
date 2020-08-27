using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Npgsql;


namespace ExploreNowWeb.Models
{
    public class SQL : DbContext
    {
        //Testa https://www.elephantsql.com/docs/dotnet.html

        //https://www.youtube.com/watch?v=ooYmB2bQuEY
        //public SQL() : base(nameOrConnectionString: "DefaultConnectionString") { }
        //public virtual DbSet<User> Users { get; set; }
        
        //Ansutning till databas, fungerar
        public static NpgsqlCommand cmd = new NpgsqlCommand();
        public static NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        public static NpgsqlDataReader dr;
        public static NpgsqlConnection conn = new NpgsqlConnection("Server=horton.elephantsql.com;Port=5432;Database=gzuphjxe;UserId=gzuphjxe;Password=z7e1xVGNfHB-UVo8Ul_R4Zjxwxqj1sXa;SslMode=Require;");
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();
        public static string query;
    }
}