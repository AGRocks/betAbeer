using BetABeer.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BetABeer.Model.ModelEntities
{
    public class Reward : IClientEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }
}