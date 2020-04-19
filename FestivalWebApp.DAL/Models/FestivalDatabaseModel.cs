using System;
using System.Collections.Generic;

namespace FestivalWebApp.DAL.Models
{
    public class FestivalDatabaseModel
    {
        public int Id { get; set; }
        public ICollection<ParticipantDatabaseModel> Participants { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}