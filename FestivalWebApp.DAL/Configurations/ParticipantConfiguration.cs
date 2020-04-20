using FestivalWebApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FestivalWebApp.DAL.Configurations
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        private const int NameMaxSize = 50;
        private const int SecondNameMaxSize = 50;

        public void Configure(EntityTypeBuilder<Participant> builder)
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

            builder.ToTable("Participants");
        }
    }
}