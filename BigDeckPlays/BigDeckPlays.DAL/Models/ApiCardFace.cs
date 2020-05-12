using System;

namespace BigDeckPlays.DAL.Models
{
    public class ApiCardFace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mana_Cost { get; set; }
        public string Oracle_Text { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Loyalty { get; set; }
        public string Type_Line { get; set; }
    }
}
