using Game_of_the_YEAR.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Game_of_the_YEAR.Repositories
{
    public static class DBRepo
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["connectDb"].ConnectionString;
        #region CREATE
        public static void  AddPlayerToDB (Player player) 
        {
            string stmt = "INSERT INTO player (e_mail,nickname) VALUES (@email, @playername) ";
            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();
                try
                {
                    using (var command = new NpgsqlCommand(stmt, conn))
                    {
                        command.Parameters.AddWithValue("email", player.Email);
                        command.Parameters.AddWithValue("playername", player.Nickname);
                        command.ExecuteNonQuery();
                    }
                    
                }
                catch(PostgresException )
                {
                    throw;                  
                }
            }
           
        }
        #endregion
        #region READ
        public static int GetAmountOfYears() 
        {
            string stmt = "SELECT COUNT (the_year_id) FROM the_year";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                long amount = 0;
                conn.Open();
                using (var command = new NpgsqlCommand(stmt,conn))
                {
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            amount = (long)reader["count"];
                        }

                    }
                    return Convert.ToInt32(amount);

                       
                }
            }
            
        }
        #endregion
        #region UPDATE
        #endregion
        #region DELETE
        #endregion
    }
}
