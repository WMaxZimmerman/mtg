using System;

namespace BigDeckPlays.DAL.db
{
    public partial class DeckTag
    {
        public Guid Id { get; set; }
        public Guid DeckId { get; set; }
        public Guid TagId { get; set; }
        public int Quantity { get; set; }

        public virtual Deck Deck { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
