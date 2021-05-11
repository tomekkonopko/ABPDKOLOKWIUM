using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumAPBD.Models
{
    public class Championship
    {
        public int IdChampionShip { get; set; }
        public string OfficialName { get; set; }
        public int Year { get; set; }
        public ICollection<Championship_Team> championhip_Teams { get; set; }
    }
}
