using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PieAuction.BackEnd.Data_Access;
using PieAuction.BackEnd.Models;

namespace PieAuction.BackEnd.Controllers
{
    public class BidsController : ApiController
    {
        [HttpPost]
        public Bid NewBid(Bid inBid)
        {
            var bidDao = new BidDao();
            return bidDao.InsertBid(inBid);
        }

        [HttpGet]
        public Bid[] GetBids(Guid? pieId = null, Guid? auctionUserId = null)
        {
            var bidDao = new BidDao();
            IEnumerable<Bid> bids = bidDao.GetBids();
            if (pieId.HasValue)
            {
                bids = bids.Where(b => b.PieId == pieId);
            }

            if (auctionUserId.HasValue)
            {
                bids = bids.Where(b => b.AuctionUserId == auctionUserId);
            }

            return bids.ToArray();
        }
    }
}
