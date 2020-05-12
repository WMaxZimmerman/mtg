using System;

namespace BigDeckPlays.DAL.db
{
    public partial class CollectionCard
    {
        public Guid Id { get; set; }
        public Guid CollectionId { get; set; }
        public Guid CardId { get; set; }
        public int Quantity { get; set; }

        public virtual Card Card { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
