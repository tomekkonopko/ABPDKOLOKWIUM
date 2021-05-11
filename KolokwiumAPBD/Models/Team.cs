using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumAPBD.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }
        public ICollection<Championship_Team> championhip_Teams { get; set; }
        public ICollection<Player_Team> player_Teams { get; set; }
    }
}
