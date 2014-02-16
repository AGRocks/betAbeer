using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BetABeer.Model.ModelEntities;
using BetABeer.Model;
using BetABeer.Model.Utilities;
using Microsoft.AspNet.SignalR;
using BetABeer.Hubs;

namespace BetABeer.Controllers
{
    public class BetController : Controller
    {
        private IRepository<Bet> repo;
        private IDbDataProvider dataProvider;

        public BetController(IDbDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            this.repo = new Repository<Bet>(dataProvider);
        }
        

        // GET: /Bet/
        public async Task<ActionResult> Index()
        {
            var bets = repo.GetAll().Include(b => b.Bookie).Include(b => b.Reward).Include(b => b.TheMan);
            return View(await bets.ToListAsync());
        }

        // GET: /Bet/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            Bet bet = repo.GetById(id.Value);
            if (bet == null)
            {
                return HttpNotFound();
            }
            return View(bet);
        }

        // GET: /Bet/Create
        public ActionResult Create()
        {
            ViewBag.BookieUserId = new SelectList(dataProvider.GetDbSet<User>(), "Id", "Name");
            ViewBag.RewardId = new SelectList(dataProvider.GetDbSet<Reward>(), "Id", "Name");
            ViewBag.TheManUserId = new SelectList(dataProvider.GetDbSet<User>(), "Id", "Name");
            return View();
        }

        // POST: /Bet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Title,Description,RewardsCount,DueDate,RewardId,BookieUserId,TheManUserId")] Bet bet)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(bet);
                repo.Save(); // SaveChangesAsync();

                // Notify clients that new bet was added.
                var context = GlobalHost.ConnectionManager.GetHubContext<BetNotificationsHub>();
                context.Clients.All.newBetArrived(bet.Id);

                return RedirectToAction("Index");
            }

            ViewBag.BookieUserId = new SelectList(dataProvider.GetDbSet<User>(), "Id", "Name");
            ViewBag.RewardId = new SelectList(dataProvider.GetDbSet<Reward>(), "Id", "Name");
            ViewBag.TheManUserId = new SelectList(dataProvider.GetDbSet<User>(), "Id", "Name");
            return View(bet);
        }

        // GET: /Bet/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            var bet = repo.GetById(id);
            if (bet == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookieUserId = new SelectList(dataProvider.GetDbSet<User>(), "Id", "Name");
            ViewBag.RewardId = new SelectList(dataProvider.GetDbSet<Reward>(), "Id", "Name");
            ViewBag.TheManUserId = new SelectList(dataProvider.GetDbSet<User>(), "Id", "Name");
            return View(bet);
        }

        // POST: /Bet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Title,Description,RewardsCount,DueDate,RewardId,BookieUserId,TheManUserId")] Bet bet)
        {
            if (ModelState.IsValid)
            {
                repo.Attach(bet);
                repo.Save(); //SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BookieUserId = new SelectList(dataProvider.GetDbSet<User>(), "Id", "Name");
            ViewBag.RewardId = new SelectList(dataProvider.GetDbSet<Reward>(), "Id", "Name");
            ViewBag.TheManUserId = new SelectList(dataProvider.GetDbSet<User>(), "Id", "Name");
            return View(bet);
        }

        // GET: /Bet/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            var bet = repo.GetById(id);
            if (bet == null)
            {
                return HttpNotFound();
            }

            return View(bet);
        }

        // POST: /Bet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var bet = repo.GetById(id);
            repo.Delete(bet);
            repo.Save();//SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)dataProvider).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
