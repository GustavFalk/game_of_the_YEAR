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
        public static Player  AddPlayerToDB (Player player) 
        {
            string stmt = "INSERT INTO player (e_mail,nickname) VALUES (@email, @playername) RETURNING player_id ";
            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();
                try
                {
                    using (var command = new NpgsqlCommand(stmt, conn))
                    {
                        command.Parameters.AddWithValue("email", player.Email);
                        command.Parameters.AddWithValue("playername", player.Nickname);
                        player.PlayerID = (Int32)command.ExecuteScalar();
                        return player;
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
        
            string stmt = "SELECT (the_year) FROM  the_year ORDER BY RANDOM() LIMIT 3";

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
        
      
        public static Player GetPlayer(string email)
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

        public static List<Highscore> GetHighscores()
        {            
            string stmt = "SELECT points, nickname FROM  game_round INNER JOIN player ON player.player_id=game_round.player_id ORDER BY points DESC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {

                List<Highscore> highscores = new List<Highscore>();
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Highscore highscore = new Highscore()
                            {
                                PlayerNickName = (string)reader["nickname"],
                                Points = (int)reader["points"]
                            };

                            highscores.Add(highscore);
                        }
                    }
                }
                return highscores;
            }
        }

        public static List<DiligenceScore> GetDiligenceScores()
        {            
            string stmt = "SELECT COUNT(game_round.player_id) AS antal_rundor, player.nickname FROM game_round INNER JOIN player ON game_round.player_id = player.player_id GROUP BY player.nickname ORDER BY antal_rundor DESC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {

                List<DiligenceScore> diligenceScores = new List<DiligenceScore>();
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DiligenceScore diligenceScore = new DiligenceScore()
                            {
                                PlayerNickName = (string)reader["nickname"],
                                GameRounds = (int)(long)reader["antal_rundor"]
                            };

                            diligenceScores.Add(diligenceScore);
                        }
                    }
                }
                return diligenceScores;
            }
        }

        public static Int64 GetPlacement(int score)
        {
            Int64 placement;
            string stmt = "select count (points) from game_round where points>= @score";
            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();
                try
                {
                    using (var command = new NpgsqlCommand(stmt, conn))
                    {
                        command.Parameters.AddWithValue("score", score);                      
                        placement = (Int64)command.ExecuteScalar();
                        return placement;
                    }
                }
                catch (PostgresException)
                {
                    throw;
                }
            }
        }
        public static Int64 GetDiligence(Int64 playerID)
        {
            Int64 playerDiligence;
            string stmt = "select count (round_id) from game_round where player_id = @player_id";
            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();
                try
                {
                    using (var command = new NpgsqlCommand(stmt, conn))
                    {
                        command.Parameters.AddWithValue("player_id", playerID);
                        playerDiligence = (Int64)command.ExecuteScalar();
                        return playerDiligence;
                    }
                }
                catch (PostgresException)
                {
                    throw;
                }
            }
        }
        public static Int64 GetPlacementDiligence(Int64 gameRounds)
        {
            Int64 playerDiligencePlacement;
            string stmt = "SELECT COUNT (antal_rundor) FROM (SELECT COUNT(game_round.player_id) AS antal_rundor, player.nickname FROM game_round INNER JOIN player ON game_round.player_id = player.player_id GROUP BY player.nickname) ss WHERE antal_rundor >= @game_rounds";
            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();
                try
                {
                    using (var command = new NpgsqlCommand(stmt, conn))
                    {
                        command.Parameters.AddWithValue("game_rounds", gameRounds);
                        playerDiligencePlacement = (Int64)command.ExecuteScalar();
                        return playerDiligencePlacement;
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
