using System;

namespace BigDeckPlays.DAL.db
{
    public partial class CardSet
    {
        public int Id { get; set; }
        public Guid CardId { get; set; }
        public Guid SetId { get; set; }
        public decimal? HighPrice { get; set; }
        public decimal? MedianPrice { get; set; }
        public decimal? LowPrice { get; set; }

        public virtual Card Card { get; set; }
        public virtual Set Set { get; set; }
    }
}
