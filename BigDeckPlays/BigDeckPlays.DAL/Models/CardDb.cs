using System;
using System.ComponentModel.DataAnnotations;

namespace BigDeckPlays.DAL.Models
{
    public partial class CardDb:  IEquatable<CardDb>
    {
        [Key]
        public int CardId {get;set;}
        public string CardName {get;set;}
        public int ConvertedManaCost {get;set;}
        public string Cost {get;set;}
        public string OracleText {get;set;}
        public string Power {get;set;}
        public string Toughness {get;set;}
        public string Types {get;set;}
        public string Subtypes {get;set;}
        public string Colors {get;set;}

        public bool Equals(CardDb other)
        {
            return this.CardId == other.CardId;
        }

        public override bool Equals(object obj)
        {
            return this.Equals((CardDb)obj);
        }
    }
}
