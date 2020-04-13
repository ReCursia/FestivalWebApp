namespace FestivalWebApp.Domain.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int FestivalId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
    }
}