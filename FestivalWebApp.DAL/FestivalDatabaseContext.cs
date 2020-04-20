using FestivalWebApp.Core.Models;
using FestivalWebApp.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FestivalWebApp.DAL
{
    public class FestivalDatabaseContext : DbContext
    {
        public FestivalDatabaseContext(DbContextOptions<FestivalDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Festival> Festivals { get; set; }

        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FestivalConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantConfiguration());
        }
    }
}