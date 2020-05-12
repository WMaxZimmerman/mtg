using SharedSet = BigDeckPlays.Shared.Models.Set;
using DbSet = BigDeckPlays.DAL.db.Set;
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
                CardCount = apiSet.Card_Count
            };
        }

        public static DbSet ApiToDb(ApiSet apiSet)
        {
            return new DbSet
            {
                Id = apiSet.Id,
                Code = apiSet.Code,
                Name = apiSet.Name,
                SetType = apiSet.Set_Type,
                ReleasedAt = apiSet.Released_At,
                BlockCode = apiSet.Block_Code,
                Block = apiSet.Block,
                CardCount = apiSet.Card_Count
            };
        }

        public static SharedSet DbToShared(DbSet dbSet)
        {
            return new SharedSet
            {
                Id = dbSet.Id,
                Code = dbSet.Code,
                Name = dbSet.Name,
                SetType = dbSet.SetType,
                ReleasedAt = dbSet.ReleasedAt,
                BlockCode = dbSet.BlockCode,
                Block = dbSet.Block,
                CardCount = dbSet.CardCount
            };
        }

        public static DbSet SharedToDb(SharedSet sharedSet)
        {
            return new DbSet
            {
                Id = sharedSet.Id,
                Code = sharedSet.Code,
                Name = sharedSet.Name,
                SetType = sharedSet.SetType,
                ReleasedAt = sharedSet.ReleasedAt,
                BlockCode = sharedSet.BlockCode,
                Block = sharedSet.Block,
                CardCount = sharedSet.CardCount
            };
        }
    }
}
