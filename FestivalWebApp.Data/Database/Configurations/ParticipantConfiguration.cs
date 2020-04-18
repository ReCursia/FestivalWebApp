using FestivalWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FestivalWebApp.Data.Database.Configurations
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<ParticipantDatabaseModel>
    {
        private const int NameMaxSize = 50;
        private const int SecondNameMaxSize = 50;

        public void Configure(EntityTypeBuilder<ParticipantDatabaseModel> builder)
        {
            builder.HasKey(participant => participant.Id);

            builder.Property(participant => participant.Id)
                .UseIdentityColumn();

            builder.Property(participant => participant.Name)
                .IsRequired()
                .HasMaxLength(NameMaxSize);

            builder.Property(participant => participant.SecondName)
                .IsRequired()
                .HasMaxLength(SecondNameMaxSize);

            builder.HasOne(participant => participant.Festival)
                .WithMany(festival => festival.Participants)
                .HasForeignKey(participant => participant.FestivalId);

            builder.ToTable("Participants");
        }
    }
}