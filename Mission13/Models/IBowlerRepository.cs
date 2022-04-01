using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Repository Method
namespace Mission13.Models
{
    public interface IBowlerRepository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Teams> Teams { get; }
        void AddBowler(Bowler b);
        void DeleteBowler(Bowler b);
        void EditBowler(Bowler b);
    }
}
