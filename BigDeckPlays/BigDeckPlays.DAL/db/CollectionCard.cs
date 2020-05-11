using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class CollectionCard
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public string CardId { get; set; }
        public int Quantity { get; set; }

        public virtual Card Card { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
