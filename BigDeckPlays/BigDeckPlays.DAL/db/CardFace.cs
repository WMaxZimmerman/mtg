using System;

namespace BigDeckPlays.DAL.db
{
    public partial class CardFace
    {
        public CardFace()
        {
        }

        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string OracleText { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Loyalty { get; set; }
        public string Types { get; set; }
        public string Subtypes { get; set; }

        public virtual Card Card { get; set; }
    }
}
