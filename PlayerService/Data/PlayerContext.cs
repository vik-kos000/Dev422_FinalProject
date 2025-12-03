using Microsoft.EntityFrameworkCore;
using PlayerService.Model;

namespace PlayerService.Data
{
    public class PlayerContext : DbContext
    {
        //constructor 
        public PlayerContext(DbContextOptions options) : base(options)
        {
            //empty
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData
            (
                new Player
                {
                    PlayerId = 1,
                    Name = "Test",
                    Position = "Quarter Back",
                    IsDrafted = false,
                    TeamId = 1
                },
                new Player
                {
                    PlayerId = 2,
                    Name = "Test",
                    Position = "Quarter Back",
                    IsDrafted = false,
                    TeamId = 1
                },
                new Player
                {
                    PlayerId = 3,
                    Name = "Test",
                    Position = "Quarter Back",
                    IsDrafted = false,
                    TeamId = 1
                },
                new Player
                {
                    PlayerId = 4,
                    Name = "Test",
                    Position = "Quarter Back",
                    IsDrafted = false,
                    TeamId = 1
                },
                new Player
                {
                    PlayerId = 5,
                    Name = "Test",
                    Position = "Quarter Back",
                    IsDrafted = false,
                    TeamId = 1
                },
                new Player
                {
                    PlayerId = 6,
                    Name = "Test",
                    Position = "Quarter Back",
                    IsDrafted = false,
                    TeamId = 1
                }
            );
        }


    }
}
