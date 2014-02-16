using BetABeer.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetABeer.Model.ModelEntities
{
    public class User : IClientEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}