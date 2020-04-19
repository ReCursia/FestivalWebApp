namespace FestivalWebApp.API.Models
{
    public class ParticipantUpdateRequestBody
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public int FestivalId { get; set; }
    }
}