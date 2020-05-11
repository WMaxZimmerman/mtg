using System;
using SharedSet = BigDeckPlays.Shared.Models.Set;
using BigDeckPlays.DAL.Models;

namespace BigDeckPlays.DAL.Mappers
{
    public static class SetMapper
    {        
        public static SharedSet ApiToShared(ApiSet apiSet)
        {
            return new SharedSet
            {
                Id = apiSet.Id,
                Code = apiSet.Code,
                Name = apiSet.Name,
                SetType = apiSet.Set_Type,
                ReleasedAt = apiSet.Released_At,
                BlockCode = apiSet.Block_Code,
                Block = apiSet.Block,
                CardCount = apiSet.CardCount
            };
        }
    }
}
