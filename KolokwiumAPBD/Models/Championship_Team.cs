using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumAPBD.Models
{
    public class Championship_Team
    {
        public int idTeam { get; set; }
        public int idChampionship { get; set; }
        public float score { get; set; }
        public Championship championship { get; set; }
        public Team team { get; set; }
    }
}
