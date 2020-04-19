namespace FestivalWebApp.Core.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int FestivalId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }

        public Festival Festival { get; set; }

        public override string ToString()
        {
            return "Participant: " + Id + " "
                   + Age + " "
                   + FestivalId + " "
                   + Name + " "
                   + SecondName + " "
                   + Festival;
        }
    }
}