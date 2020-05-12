using System;

namespace BigDeckPlays.DAL.db
{
    public partial class DeckCard
    {
        public Guid Id { get; set; }
        public Guid DeckId { get; set; }
        public Guid CardId { get; set; }
        public int Quantity { get; set; }

        public virtual Card Card { get; set; }
        public virtual Deck Deck { get; set; }
    }
}
