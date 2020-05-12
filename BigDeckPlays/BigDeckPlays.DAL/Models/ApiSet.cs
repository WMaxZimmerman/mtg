using System;

namespace BigDeckPlays.DAL.Models
{
    public class ApiSet
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Set_Type { get; set; }
        public DateTime Released_At { get; set; }
        public string Block_Code { get; set; }
        public string Block { get; set; }
        public int Card_Count { get; set; }

        // Not Using
        public string Parent_Set_Code { get; set; }
        public string Mtgo_Code { get; set; }
        public int? Tcgplayer_Code { get; set; }
        public bool Digital { get; set; }
        public bool Foil_Only { get; set; }
        public Uri Scryfall_Uri { get; set; }
        public Uri Uri { get; set; }
        public Uri Icon_Svg_Uri { get; set; }
        public Uri Search_Uri { get; set; }
    }
}
