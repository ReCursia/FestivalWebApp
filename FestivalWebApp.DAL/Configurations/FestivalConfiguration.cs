using FestivalWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FestivalWebApp.Data.Database.Configurations
{
    public class FestivalConfiguration : IEntityTypeConfiguration<FestivalDatabaseModel>
    {
        private const int FestivalNameMaxSize = 50;
        private const int FestivalDescriptionMaxSize = 200;

        public void Configure(EntityTypeBuilder<FestivalDatabaseModel> builder)
        {
            builder.HasKey(festival => festival.Id);

            builder.Property(festival => festival.Id)
                .UseIdentityColumn();

            builder.Property(festival => festival.Name)
                .IsRequired()
                .HasMaxLength(FestivalNameMaxSize);

            builder.Property(festival => festival.Description)
                .HasMaxLength(FestivalDescriptionMaxSize);

            builder.Property(festival => festival.Date)
                .IsRequired();

            builder.HasMany(f => f.Participants)
                .WithOne(p => p.Festival)
                .HasForeignKey(p => p.FestivalId);

            builder.ToTable("Festivals");
        }
    }
}