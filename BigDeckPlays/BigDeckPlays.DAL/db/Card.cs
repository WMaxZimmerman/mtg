using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class Card
    {
        public Card()
        {
            CardSet = new HashSet<CardSet>();
            CardTag = new HashSet<CardTag>();
            Deck = new HashSet<Deck>();
            DeckCard = new HashSet<DeckCard>();
            CollectionCard = new HashSet<CollectionCard>();
            CardFaces = new HashSet<CardFace>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Cmc { get; set; }
        public string Colors { get; set; }
        public string ColorIdentity { get; set; }
        public string ManaCost { get; set; }
        public string OracleText { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Loyalty { get; set; }
        public string Types { get; set; }
        public string Subtypes { get; set; }
        public int? EdhrecRank { get; set; }
        public bool Reserved { get; set; }
        public string CommanderLegality { get; set; }
        public string StandardLegality { get; set; }
        public string BrawlLegality { get; set; }
        public string PioneerLegality { get; set; }
        public string ModernLegality { get; set; }

        public virtual ICollection<CardSet> CardSet { get; set; }
        public virtual ICollection<CardTag> CardTag { get; set; }
        public virtual ICollection<Deck> Deck { get; set; }
        public virtual ICollection<DeckCard> DeckCard { get; set; }
        public virtual ICollection<CollectionCard> CollectionCard { get; set; }
        public virtual ICollection<CardFace> CardFaces { get; set; }
    }
}
