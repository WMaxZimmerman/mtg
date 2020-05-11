using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class DeckCard
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public string CardId { get; set; }
        public int Quantity { get; set; }

        public virtual Card Card { get; set; }
        public virtual Deck Deck { get; set; }
    }
}
