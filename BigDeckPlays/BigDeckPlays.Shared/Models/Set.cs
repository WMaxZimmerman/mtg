using System;

namespace BigDeckPlays.Shared.Models
{
    public class Set
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Set_Type { get; set; }
        public int Card_Count { get; set; }
        public DateTime Released_At { get; set; }
    }
}
