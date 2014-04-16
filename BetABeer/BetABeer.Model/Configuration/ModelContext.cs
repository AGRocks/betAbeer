using BetABeer.Model.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BetABeer.Model
{
    /// <summary>
    /// Class contains configuration of modelcontext
    /// </summary>
    public partial class ModelContext
    {
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}