using System;
using System.Collections.Generic;

namespace BigDeckPlays.Shared.Models
{
    public class Set
    {
        public Set()
        {
            Cards = new List<Card>();
        }
        
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string SetType { get; set; }
        public DateTime ReleasedAt { get; set; }
        public string BlockCode { get; set; }
        public string Block { get; set; }
        public int CardCount { get; set; }
        public bool Digital { get; set; }
        public bool FoilOnly { get; set; }
        public bool Completed { get; set; }

        public IEnumerable<Card> Cards { get; set; }
    }
}
