using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class Tag
    {
        public Tag()
        {
            CardTag = new HashSet<CardTag>();
            DeckTag = new HashSet<DeckTag>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CardTag> CardTag { get; set; }
        public virtual ICollection<DeckTag> DeckTag { get; set; }
    }
}
