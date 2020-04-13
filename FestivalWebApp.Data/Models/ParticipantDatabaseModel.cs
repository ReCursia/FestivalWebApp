using FestivalWebApp.Domain.Models;

namespace FestivalWebApp.Data.Models
{
    public class ParticipantDatabaseModel : Participant
    {
        public FestivalDatabaseModel Festival { get; set; }
    }
}