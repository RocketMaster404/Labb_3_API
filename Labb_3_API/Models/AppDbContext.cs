using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Labb_3_API.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<Link> Links { get; set; }
       


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserInterest>()
                .HasKey(ui => new { ui.UserId, ui.InterestId });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Erik", LastName = "Larsson", Email = "erik@mail.com", PhoneNumber = "0701111111" },
                new User { Id = 2, FirstName = "Anna", LastName = "Svensson", Email = "anna@mail.com", PhoneNumber = "0702222222" },
                new User { Id = 3, FirstName = "Johan", LastName = "Karlsson", Email = "johan@mail.com", PhoneNumber = "0703333333" },
                new User { Id = 4, FirstName = "Lisa", LastName = "Andersson", Email = "lisa@mail.com", PhoneNumber = "0704444444" },
                new User { Id = 5, FirstName = "Oskar", LastName = "Nilsson", Email = "oskar@mail.com", PhoneNumber = "0705555555" },
                new User { Id = 6, FirstName = "Emma", LastName = "Johansson", Email = "emma@mail.com", PhoneNumber = "0706666666" },
                new User { Id = 7, FirstName = "Lucas", LastName = "Eriksson", Email = "lucas@mail.com", PhoneNumber = "0707777777" },
                new User { Id = 8, FirstName = "Maja", LastName = "Persson", Email = "maja@mail.com", PhoneNumber = "0708888888" },
                new User { Id = 9, FirstName = "Albin", LastName = "Gustafsson", Email = "albin@mail.com", PhoneNumber = "0709999999" },
                new User { Id = 10, FirstName = "Sara", LastName = "Berg", Email = "sara@mail.com", PhoneNumber = "0701010101" }
             );
            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Climbing", Description = "Rock climbing and bouldering" },
                new Interest { Id = 2, Title = "Gaming", Description = "Video games and esports" },
                new Interest { Id = 3, Title = "Running", Description = "Long distance running" },
                new Interest { Id = 4, Title = "Cooking", Description = "Making food and recipes" },
                new Interest { Id = 5, Title = "Music", Description = "Playing instruments and listening" }
            );
            modelBuilder.Entity<UserInterest>().HasData(
                new UserInterest { UserId = 1, InterestId = 1 },
                new UserInterest { UserId = 1, InterestId = 2 },

                new UserInterest { UserId = 2, InterestId = 2 },
                new UserInterest { UserId = 2, InterestId = 4 },

                new UserInterest { UserId = 3, InterestId = 3 },
                new UserInterest { UserId = 3, InterestId = 1 },

                new UserInterest { UserId = 4, InterestId = 5 },
                new UserInterest { UserId = 5, InterestId = 4 },

                new UserInterest { UserId = 6, InterestId = 3 },
                new UserInterest { UserId = 7, InterestId = 2 },

                new UserInterest { UserId = 8, InterestId = 1 },
                new UserInterest { UserId = 9, InterestId = 5 },

                new UserInterest { UserId = 10, InterestId = 2 }
            );
            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://climbing.com", UserId = 1, InterestId = 1 },
                new Link { Id = 2, Url = "https://twitch.tv", UserId = 1, InterestId = 2 },

                new Link { Id = 3, Url = "https://gaming.com", UserId = 2, InterestId = 2 },
                new Link { Id = 4, Url = "https://recipes.com", UserId = 2, InterestId = 4 },

                new Link { Id = 5, Url = "https://runfast.com", UserId = 3, InterestId = 3 },
                new Link { Id = 6, Url = "https://climbworld.com", UserId = 3, InterestId = 1 },

                new Link { Id = 7, Url = "https://spotify.com", UserId = 4, InterestId = 5 },
                new Link { Id = 8, Url = "https://foodblog.com", UserId = 5, InterestId = 4 },

                new Link { Id = 9, Url = "https://marathon.com", UserId = 6, InterestId = 3 },
                new Link { Id = 10, Url = "https://esports.com", UserId = 7, InterestId = 2 }
             );
        }

    }
}
