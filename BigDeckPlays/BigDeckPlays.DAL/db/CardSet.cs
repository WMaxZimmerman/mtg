using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.db
{
    public partial class CardSet
    {
        public int Id { get; set; }
        public string CardId { get; set; }
        public string SetId { get; set; }
        public decimal? HighPrice { get; set; }
        public decimal? MedianPrice { get; set; }
        public decimal? LowPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Card Card { get; set; }
        public virtual Set Set { get; set; }
    }
}
