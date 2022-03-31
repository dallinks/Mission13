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
    }
}
