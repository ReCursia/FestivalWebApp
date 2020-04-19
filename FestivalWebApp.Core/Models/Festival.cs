using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FestivalWebApp.Core.Models
{
    public class Festival
    {
        public int Id { get; set; }

        public ICollection<Participant> Participants { get; set; } = new Collection<Participant>();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return "Festival: " + Id + " "
                   + Name + " "
                   + Description + " "
                   + Date;
        }
    }
}