using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class DeckTag
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int TagId { get; set; }
        public int Quantity { get; set; }

        public virtual Deck Deck { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
