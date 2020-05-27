using System;
using BigDeckPlays.DAL.Models;
using SharedCard = BigDeckPlays.Shared.Models.Card;
using SharedFace = BigDeckPlays.Shared.Models.CardFace;
using DbCard = BigDeckPlays.DAL.db.Card;
using DbFace = BigDeckPlays.DAL.db.CardFace;
using System.Linq;
using System.Collections.Generic;

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

        public static DbCard SharedToDb(SharedCard sharedCard)
        {
            return new DbCard
            {
                Id = sharedCard.Id,
                Name = sharedCard.Name,
                Cmc = (int)sharedCard.Cmc,
                Colors = string.Join(',', sharedCard.Colors),
                ColorIdentity = string.Join(',', sharedCard.ColorIdentity),
                ManaCost = sharedCard.ManaCost,
                EdhrecRank = sharedCard.EdhrecRank,
                OracleText = sharedCard.OracleText,
                Power = sharedCard.Power,
                Toughness = sharedCard.Toughness,
                Loyalty = sharedCard.Loyalty,
                Reserved = sharedCard.Reserved,
                CommanderLegality = sharedCard.CommanderLegality,
                StandardLegality = sharedCard.StandardLegality,
                PioneerLegality = sharedCard.PioneerLegality,
                ModernLegality = sharedCard.ModernLegality,
                BrawlLegality = sharedCard.BrawlLegality,
                Types = string.Join(",", sharedCard.Types),
                Subtypes = string.Join(",", sharedCard.Subtypes),
                CardFaces = sharedCard.Faces.Select(f => SharedToDb(f)).ToList()
            };
        }

        private static DbFace SharedToDb(SharedFace sharedFace)
        {
            return new DbFace
            {
                Id = sharedFace.Id,
                ParentId = sharedFace.ParentId,
                Name = sharedFace.Name,
                ManaCost = sharedFace.ManaCost,
                OracleText = sharedFace.OracleText,
                Power = sharedFace.Power,
                Toughness = sharedFace.Toughness,
                Loyalty = sharedFace.Loyalty,
                Types = string.Join(",", sharedFace.Types),
                Subtypes = string.Join(",", sharedFace.Subtypes)
            };
        }

        public static SharedCard ApiToShared(ApiCard apiCard)
        {
            // TODO: Need to figure out Types and Multi-Faced Cards
            var types = new List<string>();
            var subtypes = new List<string>();
            if (apiCard.Card_Faces.Count == 0)
            {
                var tempType = apiCard.Type_Line.Split(" - ").ToList();
                types = tempType[0].Split(' ').ToList();
                if (tempType.Count > 1)
                {
                    subtypes = tempType[1].Split(' ').ToList();
                }
            }
            
            
            return new SharedCard
            {
                Id = apiCard.Oracle_Id,
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
                BrawlLegality = apiCard.Legalities.Brawl,
                Types = types,
                Subtypes = subtypes,
                Faces = apiCard.Card_Faces.Select(f => ApiToShared(f, apiCard.Id)).ToList()
            };
        }

        private static  SharedFace ApiToShared(ApiCardFace apiFace, Guid parentId)
        {
            var types = new List<string>();
            var subtypes = new List<string>();
            
            var tempType = apiFace.Type_Line?.Split(" - ").ToList();
            if (tempType != null && tempType.Count > 0)
            {
                types = tempType[0].Split(' ').ToList();
                subtypes = new List<string>();
                if (tempType.Count > 1)
                {
                    subtypes = tempType[1].Split(' ').ToList();
                }
            }
            
            return new SharedFace
            {
                Id = Guid.NewGuid(),
                ParentId = parentId,
                Name = apiFace.Name,
                ManaCost = apiFace.Mana_Cost,
                OracleText = apiFace.Oracle_Text,
                Power = apiFace.Power,
                Toughness = apiFace.Toughness,
                Loyalty = apiFace.Loyalty,
                Types = types,
                Subtypes = subtypes
            };
        }
    }
}
