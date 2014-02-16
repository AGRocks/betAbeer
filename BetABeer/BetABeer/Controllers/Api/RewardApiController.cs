using BetABeer.Api.Controllers;
using BetABeer.Model.ModelEntities;
using BetABeer.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BetABeer.Controllers.Api
{
    public class RewardController : BaseCRUDController<Reward>
    {
        public RewardController(IRepository<Reward> repo)
            : base(repo) 
        {
        }
    }
}