using BigDeckPlays.DAL.db;
using BigDeckPlays.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace BigDeckPlays.DAL.Repositories
{
    public interface IDatabaseRepository
    {
        IEnumerable<BigDeckPlays.Shared.Models.Card> Cards();
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
    }
}
