using System;
using System.Collections.Generic;
using System.Text;

namespace Game_of_the_YEAR
{
    class Player
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }

        public override string ToString()
        {
            return $"{Nickname}";
        }
    }
}
