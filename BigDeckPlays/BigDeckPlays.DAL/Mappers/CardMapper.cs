using System;
using BigDeckPlays.DAL.Models;
using SharedCard = BigDeckPlays.Shared.Models.Card;
using DbCard = BigDeckPlays.DAL.db.Card;

namespace BigDeckPlays.DAL.Mappers
{
    public static class CardMapper
    {
        public static char Dilimeter = '|';
        
        public static SharedCard StringToCard(string cardString)
        {
            var values = cardString.Split(Dilimeter);
            
            return new SharedCard
            {
                Name = values[1]
            };
        }

        public static string CardToString(SharedCard card)
        {
            return "";
        }

        public static SharedCard DbToShared(DbCard dbCard)
        {
            return new SharedCard
            {
                Name = dbCard.Name,
                Cmc = dbCard.Cmc ?? 0
            };
        }

        public static SharedCard ApiToShared(ApiCard apiCard)
        {
            // TODO: Need to figure out Types and Multi-Faced Cards
            return new SharedCard
            {
                Id = apiCard.Id,
                OracleId = apiCard.Oracle_Id,
                Name = apiCard.Name,
                Cmc = apiCard.Cmc,
                Colors = apiCard.Colors,
                ColorIdentity = apiCard.Color_Identity,
                ManaCost = apiCard.Mana_Cost,
                EdhrecRank = apiCard.Edhrec_Rank,
                OracleText = apiCard.Oracle_Text,
                Power = apiCard.Power,
                Toughness = apiCard.Toughness,
                Loyalty = apiCard.Loyalty,
                Reserved = apiCard.Reserved,
                CommanderLegality = apiCard.Legalities.Commander,
                StandardLegality = apiCard.Legalities.Standard,
                PioneerLegality = apiCard.Legalities.Pioneer,
                ModernLegality = apiCard.Legalities.Modern,
            };
        }
    }
}
