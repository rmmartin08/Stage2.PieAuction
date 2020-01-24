using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PieAuction.BackEnd.Models
{
    public class Bid
    {
        public Guid Id { get; set; }
        public Guid AuctionUserId { get; set; }
        public Guid PieId { get; set; }
        public DateTime Timestamp { get; set; }
        public int Amount { get; set; }
    }
}