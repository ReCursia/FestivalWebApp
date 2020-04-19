namespace FestivalWebApp.Presentation.Models
{
    public class ParticipantRequestBody
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public int FestivalId { get; set; }
    }
}