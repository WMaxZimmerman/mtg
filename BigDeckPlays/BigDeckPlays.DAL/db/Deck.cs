using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class Deck
    {
        public Deck()
        {
            DeckCard = new HashSet<DeckCard>();
            DeckTag = new HashSet<DeckTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Commander { get; set; }

        public virtual Card CommanderNavigation { get; set; }
        public virtual ICollection<DeckCard> DeckCard { get; set; }
        public virtual ICollection<DeckTag> DeckTag { get; set; }
    }
}
