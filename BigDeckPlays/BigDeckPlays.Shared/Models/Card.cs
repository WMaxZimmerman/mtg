using System;
using System.Collections.Generic;

namespace BigDeckPlays.Shared.Models
{
    public class Card: IEquatable<Card>
    {
        public Guid Id { get; set; }
        public Guid OracleId { get; set; }
        public string Name { get; set; }
        public decimal Cmc { get; set; }
        public List<char> Colors { get; set; }
        public List<char> ColorIdentity { get; set; }
        public string ManaCost { get; set; }
        public int? EdhrecRank { get; set; }
        public string OracleText { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Loyalty { get; set; }
        public List<string> Types { get; set; }
        public List<string> Subtypes { get; set; }
        public bool Reserved { get; set; }
        public string CommanderLegality { get; set; }
        public string StandardLegality { get; set; }
        public string ModernLegality { get; set; }
        public string PioneerLegality { get; set; }

        public bool Equals(Card other)
        {
            return this.Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            return this.Equals((Card)obj);
        }
    }
}
