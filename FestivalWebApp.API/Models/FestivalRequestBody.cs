using System;

namespace FestivalWebApp.Presentation.Models
{
    public class FestivalRequestBody
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}