using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CollectionCard> CollectionCard { get; set; }
    }
}
