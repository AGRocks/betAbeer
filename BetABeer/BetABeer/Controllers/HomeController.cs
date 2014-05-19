using BetABeer.Model.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetABeer.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateBet()
        {
            return View();
        }
    }
}
