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
        public static void AddGameRoundToDB()
        {
            string stmt = "INSERT INTO game_round (points, player_id) VALUES (@points, @player_id) ";
            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();
                try
                {
                    using (var command = new NpgsqlCommand(stmt, conn))
                    {
                        command.Parameters.AddWithValue("player_id", CurrentGame.CurrentPlayer.PlayerID);
                        command.Parameters.AddWithValue("points", CurrentGame.TotalPoints);
                        command.ExecuteNonQuery();
                    }

                }
                catch (PostgresException)
                {
                    throw;
                }
            }

        }
        #endregion
        #region READ
        public static List<Question> GetQuestions()
        {
        
            string stmt = "SELECT (the_year) FROM  the_year ORDER BY RANDOM() LIMIT 10";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                
                List<Question> questions = new List<Question>();
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader ())
                    {
                        while (reader.Read())
                        {
                            Question question = new Question((int)reader["the_year"]);                          
                               
                            questions.Add(question);
                        }
                    }
                }
                return questions;
            }            
        }

        public static List<string> GetClues(int year)
        {
            string stmt = "SELECT clues_text FROM clues INNER JOIN the_year ON the_year.the_year_id=clues.the_year_id WHERE the_year.the_year= @year ORDER BY RANDOM()";
            
            using (var conn = new NpgsqlConnection(connectionString))
            {                
                List<string> clues = new List<string>();
                string clue;
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    command.Parameters.AddWithValue("year", year);
                    using (var reader = command.ExecuteReader())
                    {                       
                        while(reader.Read())
                        {
                            clue = (string)reader["clues_text"];
                            clues.Add(clue);
                        }
                    }                    
                }
                return clues;
            }
        }
        
        //public static int GetAmountOfYears() 
        //{
            //string stmt = "SELECT COUNT (the_year_id) FROM the_year";
            //using (var conn = new NpgsqlConnection(connectionString))
            //{
                //long amount = 0;
                //conn.Open();
                //using (var command = new NpgsqlCommand(stmt,conn))
                //{
                    
                    //using (var reader = command.ExecuteReader())
                    //{
                        //while (reader.Read())
                        //{
                            //amount = (long)reader["count"];
                        //}

                    //}
                    //return Convert.ToInt32(amount);

                       
                //}
            //}
            
        //}
                       
        //        }
        //    }
            
        //}
        public static Player GetPlayerFromDB(string email)
        {
            string stmt = "SELECT player_id, e_mail, nickname FROM player WHERE e_mail=@email";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                Player player = null;
                conn.Open();
                try
                {

                    using (var command = new NpgsqlCommand(stmt, conn))
                    {
                        command.Parameters.AddWithValue("email", email);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                player = new Player
                                {
                                    PlayerID = (int)reader["player_id"],
                                    Email = email,
                                    Nickname = (string)reader["nickname"]
                                };

                            }
                            return player;
                        }
                    }
                }
                catch (PostgresException)
                {
                    throw;
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
