using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumAPBD.Models
{
    public class Player_Team
    {
        public int IdPlayer { get; set; }
        public int IdTeam { get; set; }
        public int NumofShirt { get; set; }
        public string comment { get; set; }
        public Team team { get; set; }
        public Player player { get; set; }
    }
}
