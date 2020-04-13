using FestivalWebApp.Data.Configurations;
using FestivalWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalWebApp.Data.Database
{
    public class FestivalDatabaseContext : DbContext
    {
        public DbSet<FestivalDatabaseModel> festivals { get; set; }

        public DbSet<ParticipantDatabaseModel> participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FestivalConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
        }
    }
}