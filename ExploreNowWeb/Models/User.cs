using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExploreNowWeb.Models
{
    [Table("user", Schema = "public")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserActivityID { get; set; }
        public int PermissionID { get; set; }
        public static List<User> logg = new List<User>();
        public static List<User> usersList = new List<User>();
        public User()
        {

        }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public User(string firstname, string lastname, string email, string password, int permissionid)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            PermissionID = permissionid;
        }
        public User(int id, string firstname, string lastname, string email, string password, int useractivityid, int permissionid)
        {
            ID = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            UserActivityID = useractivityid;
            PermissionID = permissionid;
        }
        public User(string firstname, string lastname, string email) // Test för utläsning
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }
        public List<User> getUsers() // Test för utläsning
        {
            try
            {
                SQL.conn.Open();
                SQL.query = "SELECT firstname, lastname, email FROM users";
                SQL.cmd = new NpgsqlCommand(SQL.query, SQL.conn);
                SQL.dr = SQL.cmd.ExecuteReader();
                while (SQL.dr.Read())
                {
                    usersList.Add(item: new User(SQL.dr["firstname"].ToString(), SQL.dr["lastname"].ToString(), SQL.dr["email"].ToString()));
                }
                return usersList;
            }
            catch (NpgsqlException ex)
            {
                throw;
            }
            finally
            {
                SQL.conn.Close();
            }
        }
        public List<User> Login(string email, string password)
        {
            logg.Clear();
            try
            {
                SQL.conn.Open();
                SQL.query = "SELECT id, firstname, lastname, email, password, user_activity_id, permission_id FROM users WHERE (email = @mail) AND (password = @pword)";
                SQL.cmd = new Npgsql.NpgsqlCommand(SQL.query, SQL.conn);
                SQL.cmd.Parameters.AddWithValue("@mail", NpgsqlTypes.NpgsqlDbType.Varchar); //https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlparametercollection.addwithvalue(v=vs.110).aspx
                SQL.cmd.Parameters["@mail"].Value = email;
                SQL.cmd.Parameters.AddWithValue("@pword", NpgsqlTypes.NpgsqlDbType.Varchar);
                SQL.cmd.Parameters["@pword"].Value = password;
                SQL.dr = SQL.cmd.ExecuteReader();
                if (SQL.dr.HasRows)
                {
                    while (SQL.dr.Read())
                    {
                        logg.Add(new User(SQL.dr.GetInt32(SQL.dr.GetOrdinal("id")), SQL.dr["firstname"].ToString(), SQL.dr["lastname"].ToString(), SQL.dr["email"].ToString(), SQL.dr["password"].ToString(), SQL.dr.GetInt32(SQL.dr.GetOrdinal("user_activity_id")), SQL.dr.GetInt32(SQL.dr.GetOrdinal("permission_id"))));
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw;
            }
            finally
            {
                SQL.conn.Close();
            }
            return logg;
        }
        public User Register(string firstname, string lastname, string email, string password, int permission_id)
        {
            try
            {
                SQL.conn.Open();
                SQL.query = "INSERT INTO users (firstname, lastname, email, password, permission_id) VALUES (@fname, @lname, @email, @pword, @perm_id)";
                SQL.cmd = new NpgsqlCommand(SQL.query, SQL.conn);
                SQL.cmd.Parameters.AddWithValue("@fname", NpgsqlTypes.NpgsqlDbType.Varchar);
                SQL.cmd.Parameters["@fname"].Value = firstname;
                SQL.cmd.Parameters.AddWithValue("@lname", NpgsqlTypes.NpgsqlDbType.Varchar);
                SQL.cmd.Parameters["@lname"].Value = lastname;
                SQL.cmd.Parameters.AddWithValue("@email", NpgsqlTypes.NpgsqlDbType.Varchar);
                SQL.cmd.Parameters["@email"].Value = email;
                SQL.cmd.Parameters.AddWithValue("@pword", NpgsqlTypes.NpgsqlDbType.Varchar);
                SQL.cmd.Parameters["@pword"].Value = password;
                SQL.cmd.Parameters.AddWithValue("@perm_id", NpgsqlTypes.NpgsqlDbType.Integer);
                SQL.cmd.Parameters["@perm_id"].Value = permission_id;
                SQL.cmd.ExecuteNonQuery();
                return new User(firstname, lastname, email, password, permission_id);
            }
            catch (NpgsqlException ex)
            {

                throw;
            }
            finally
            {
                SQL.conn.Close();
            }
        }
    }
}