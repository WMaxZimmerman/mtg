using System;
using System.Collections.Generic;

namespace BigDeckPlays.DAL.Models
{
    public class ApiCard
    {
        public Guid Id { get; set; }
        public Guid Oracle_Id { get; set; }
        public string Name { get; set; }
        public decimal Cmc { get; set; }
        public List<char> Colors { get; set; }
        public List<char> Color_Identity { get; set; }
        public string Mana_Cost { get; set; }
        public int? Edhrec_Rank { get; set; }
        public bool Foil { get; set; }
        public bool Nonfoil { get; set; }
        public string Oracle_Text { get; set; }
        public ApiLegality Legalities { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Loyalty { get; set; }
        public string Type_Line { get; set; }
        public bool Reserved { get; set; }

        // Not Using
        public int Mtgo_Id { get; set; }        
        public int Tcgplayer_Id { get; set; }
        public Uri Rulings_Uri {get; set; }
        public Uri Scryfall_Uri {get; set; }
        public Uri Uri {get; set; }
        public char[]? Color_Indicator { get; set; }
    }
}
