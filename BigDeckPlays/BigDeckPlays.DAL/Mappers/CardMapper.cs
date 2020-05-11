using System;
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
                Name = values[1],
                Quantity = Convert.ToInt32(values[0])
            };
        }

        public static string CardToString(SharedCard card)
        {
            return $"{card.Quantity}{Dilimeter}{card.Name}";
        }

        public static SharedCard DbToShared(DbCard dbCard)
        {
            return new SharedCard
            {
                Name = dbCard.Name,
                Cmc = dbCard.Cmc ?? 0
            };
        }
    }
}
