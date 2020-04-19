using System;

namespace FestivalWebApp.API.Models
{
    public class FestivalCreateRequestBody
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}