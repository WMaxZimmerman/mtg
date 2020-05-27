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
        void CompleteSet(BigDeckPlays.Shared.Models.Set completedSet);
        void AddSet(Set newSet);
        void AddCard(Card card, Set cardSet = null);
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

        public void CompleteSet(BigDeckPlays.Shared.Models.Set completedSet)
        {
            try
            {
                var dbSet = _db.Set.FirstOrDefault(s => s.Id == completedSet.Id);
                if (dbSet != null)
                {
                    dbSet.Completed = true;
                    _db.Set.Update(dbSet);
                    _db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine($"Failed to update set {completedSet.Name}");
                System.Console.WriteLine(e.InnerException);
            }
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

        public void AddCard(Card card, Set cardSet = null)
        {
            if (card.Types.Contains("Token") || card.CardFaces.Any(cf => cf.Types.Contains("Token")))
            {
                System.Console.WriteLine($"Skipping card {card.Name}");
                return;
            }
            try
            {
                var cardId = _db.Card.SingleOrDefault(c => c.Id == card.Id)?.Id;
                if (cardId == null)
                {
                    _db.Card.Add(card);
                }

                cardId = cardId ?? card.Id;
                
                if (cardSet != null)
                {
                    var foundCardSet = _db.CardSet.SingleOrDefault(cs => cs.CardId == cardId && cs.SetId == cardSet.Id);
                    if (foundCardSet == null)
                    {
                        var newId = Guid.NewGuid();
                        while(_db.CardSet.FirstOrDefault(cs => cs.Id == newId) != null)
                        {
                            newId = Guid.NewGuid();
                        }
                        
                        var newCardSet = new CardSet()
                        {
                            Id = Guid.NewGuid(),
                            CardId = (Guid)cardId,
                            SetId = cardSet.Id,
                        };
                        _db.CardSet.Add(newCardSet);
                    }
                }
                
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                System.Console.WriteLine($"Failed to add card {card.Name} for set {cardSet?.Name}");
                System.Console.WriteLine(e.InnerException);
            }
        }
    }
}
