using FestivalWebApp.Core.Models;

namespace FestivalWebApp.DAL.Models
{
    public class ParticipantDatabaseModel : Participant
    {
        public FestivalDatabaseModel Festival { get; set; }
    }
}