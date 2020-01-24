using PieAuction.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PieAuction.BackEnd.Data_Access;


namespace PieAuction.BackEnd.Controllers
{
    [RoutePrefix("api/bids")]
    public class BidsController : ApiController
    {
        [HttpPost]
        public Bid NewBid(Bid inBid)
        {
            var bidDao = new BidDao();
            return bidDao.NewBid(inBid);
        }
        
    }
}
