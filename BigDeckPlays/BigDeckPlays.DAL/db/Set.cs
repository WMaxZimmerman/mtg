using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class Set
    {
        public Set()
        {
            CardSet = new HashSet<CardSet>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Border { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int? Number { get; set; }

        public virtual ICollection<CardSet> CardSet { get; set; }
    }
}
