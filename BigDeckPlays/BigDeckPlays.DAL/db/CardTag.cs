using System;

namespace BigDeckPlays.DAL.db
{
    public partial class CardTag
    {
        public Guid Id { get; set; }
        public Guid CardId { get; set; }
        public Guid TagId { get; set; }

        public virtual Card Card { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
