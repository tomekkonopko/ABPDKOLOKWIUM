using KolokwiumAPBD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumAPBD.Data
{
    public class KolokwiumDbContext : DbContext
    {
        public DbSet<Championship> championships { get; set; }
        public DbSet<Championship_Team> championship_Teams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player_Team> player_Teams { get; set; }
        public DbSet<Player> players { get; set; }

        public KolokwiumDbContext()
        {

        }

        public KolokwiumDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18902;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.Property(p => p.FirstName).IsRequired();
                opt.Property(p => p.LastName).IsRequired();
                opt.HasMany(p => p.player_Teams).WithOne(p => p.player).HasForeignKey(p => p.IdPlayer);
                var Players = new List<Player>
                {
                new Player
                {
                    IdPlayer = 1,
                    FirstName="Jerzy",
                    LastName= "Dudek",
                },
                new Player
                {
                    IdPlayer = 2,
                    FirstName="Robercik",
                    LastName= "Lewandowski",
                }
                };
                opt.HasData(Players);
                

            });
            modelBuilder.Entity<Player_Team>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.HasKey(p => p.IdTeam);
                opt.Property(p => p.comment).IsRequired();

                /*var Players_Team = new List<Player_Team>
                {
                new Player_Team
                {
                    IdPlayer = 1,
                    IdTeam=1
                },
                new Player_Team
                {
                    IdPlayer = 2,
                    IdTeam=2
                }
                };
                opt.HasData(Players_Team);*/


            });
            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(p => p.IdTeam);
                opt.Property(p => p.TeamName).IsRequired();
                opt.HasMany(p => p.championhip_Teams).WithOne(p => p.team).HasForeignKey(p => p.idTeam);
                opt.HasMany(p => p.player_Teams).WithOne(p => p.team).HasForeignKey(p => p.IdTeam);

                var Teams = new List<Team>
                {
                    new Team
                    {
                       IdTeam=1,
                       TeamName="Legia Warszawa",
                        MaxAge = 20
                     },
                    new Team
                    {
                       IdTeam=2,
                       TeamName="Lech Poznan",
                        MaxAge = 25
                     }
                };
                opt.HasData(Teams);
            });
            modelBuilder.Entity<Championship_Team>(opt =>
            {
                opt.HasKey(p => p.idTeam);
                opt.HasKey(p => p.idChampionship);


                var Champ_Team = new List<Championship_Team>
                {
                new Championship_Team
                {
                    idTeam = 1,
                    idChampionship=1
                },
                new Championship_Team
                {
                    idTeam = 2,
                    idChampionship=2
                }
                };
                opt.HasData(Champ_Team);


            });
            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(p => p.IdChampionShip);
                opt.Property(p => p.OfficialName).IsRequired();
                opt.HasMany(p => p.championhip_Teams).WithOne(p => p.championship).HasForeignKey(p => p.idChampionship);

                var Champ = new List<Championship>
                {
                new Championship
                {
                    IdChampionShip = 1,
                    OfficialName="Liga Propan"
                },
                new Championship
                {
                    IdChampionShip = 2,
                    OfficialName="Liga Butan"
                }
                };
                opt.HasData(Champ);



            });


        }




    }
}
