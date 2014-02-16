using BetABeer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BetABeer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ModelContext();
            var betsCount = context.Bets.Count();
        }
    }
}
