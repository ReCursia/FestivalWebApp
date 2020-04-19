using FestivalWebApp.Data.Database.Configurations;
using FestivalWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalWebApp.Data.Database
{
    public class FestivalDatabaseContext : DbContext
    {
        public FestivalDatabaseContext(DbContextOptions<FestivalDatabaseContext> options) : base(options) {}

        public DbSet<FestivalDatabaseModel> Festivals { get; set; }

        public DbSet<ParticipantDatabaseModel> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FestivalConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
        }
    }
}