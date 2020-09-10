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
