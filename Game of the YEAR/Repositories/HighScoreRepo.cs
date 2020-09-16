using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Game_of_the_YEAR.Repositories
{
    class HighScoreRepo
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["connectDb"].ConnectionString;

        public static IEnumerable<Player> GetPlayers()
        {
            string stmt = "select player_id, email, nickname from player";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                Player player = null;
                List<Player> players = new List<Player>();
                conn.Open();
                using (var command = new NpgsqlCommand(stmt, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player = new Player
                            {
                                Id = (int)reader["player_id"],
                                Email = (string)reader["email"],
                                Nickname = (string)reader["nickname"],
                            };
                            players.Add(player);
                        }
                    }
                }
                return players;
            }
        }

    }
}
