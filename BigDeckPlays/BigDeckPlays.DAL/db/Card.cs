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
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int? Cmc { get; set; }
        public string Cost { get; set; }
        public string OracleText { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Types { get; set; }
        public string SubTypes { get; set; }
        public string Colors { get; set; }

        public virtual ICollection<CardSet> CardSet { get; set; }
        public virtual ICollection<CardTag> CardTag { get; set; }
        public virtual ICollection<Deck> Deck { get; set; }
        public virtual ICollection<DeckCard> DeckCard { get; set; }
    }
}
