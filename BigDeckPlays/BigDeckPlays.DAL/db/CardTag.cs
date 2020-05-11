using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class CardTag
    {
        public int Id { get; set; }
        public string CardId { get; set; }
        public int TagId { get; set; }

        public virtual Card Card { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
