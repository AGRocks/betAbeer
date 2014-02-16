using BetABeer.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BetABeer.Model.ModelEntities
{
    public class Bet : IClientEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayName("How much..")]
        public int RewardsCount { get; set; }

        [DisplayName("Deadline")]
        public DateTime DueDate { get; set; }

        [ForeignKey("RewardId")]        
        public Reward Reward { get; set; }

        [ForeignKey("BookieUserId")]        
        public User Bookie { get; set; }

        [ForeignKey("TheManUserId")]        
        public User TheMan { get; set; }

        [DisplayName("Reward")]
        public long RewardId { get; set; }

        [DisplayName("Bookie")]
        public long BookieUserId { get; set; }

        [DisplayName("Gambler")]
        public long TheManUserId { get; set; }
    }
}