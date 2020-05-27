using System;
using System.Collections.Generic;

namespace BigDeckPlays.Shared.Models
{
    public class CardFace
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public string OracleText { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Loyalty { get; set; }
        public List<string> Types { get; set; }
        public List<string> Subtypes { get; set; }
    }
}
