using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlerRepository : IBowlerRepository
    {
        public BowlersDBContext _context {get;set;}
        public EFBowlerRepository(BowlersDBContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Teams> Teams => _context.Teams;
        public void AddBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();

        }
        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();

        }
        public void EditBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();

        }
    }
}
