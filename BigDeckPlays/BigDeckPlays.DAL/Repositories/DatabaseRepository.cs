using BigDeckPlays.DAL.db;
using BigDeckPlays.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigDeckPlays.DAL.Repositories
{
    public interface IDatabaseRepository
    {
        IEnumerable<BigDeckPlays.Shared.Models.Card> Cards();
        IEnumerable<BigDeckPlays.Shared.Models.Set> Sets();
        void AddSet(Set newSet);
    }
    
    public class DatabaseRepository : IDatabaseRepository
    {
        private BigDeckPlaysContext _db;
        
        public DatabaseRepository()
        {
            _db = new BigDeckPlaysContext();
        }

        public IEnumerable<BigDeckPlays.Shared.Models.Card> Cards()
        {
            return _db.Card.AsEnumerable().Select(CardMapper.DbToShared);
        }

        public IEnumerable<BigDeckPlays.Shared.Models.Set> Sets()
        {
            return _db.Set.AsEnumerable().Select(SetMapper.DbToShared);
        }

        public void AddSet(Set newSet)
        {
            try
            {
                _db.Set.Add(newSet);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                System.Console.WriteLine($"Failed to add {newSet.Name}");
                System.Console.WriteLine(e.InnerException);
            }
        }
    }
}
