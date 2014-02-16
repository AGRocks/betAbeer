using BetABeer.Model.ModelEntities;
using BetABeer.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BetABeer.Api.Controllers
{
    public class BetController : BaseCRUDController<Bet>
    {
        public BetController(IRepository<Bet> repo)
            : base(repo)
        {
        }
    }
}