using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiteDB;
using PieAuction.BackEnd.Models;

namespace PieAuction.BackEnd.Data_Access
{
    public class BidDao : DaoBase
    {
        public Bid InsertBid(Bid inBid)
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var bidCol = db.GetCollection<Bid>("Bids");
                var userDao = new AuctionUserDao();
                var pieDao = new PieDao();

                if (userDao.GetSingleUserById(inBid.AuctionUserId) == null)
                {
                    throw new KeyNotFoundException("Cannot find existing user: " + inBid.AuctionUserId);
                }

                if (pieDao.GetSinglePieById(inBid.PieId) == null)
                {
                    throw new KeyNotFoundException("Cannot find existing pie: " + inBid.PieId);
                }

                if (inBid.Amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(inBid), "Amount must be greater than 0.");
                }

                inBid.Id = Guid.NewGuid();
                inBid.Timestamp = DateTime.Now;

                bidCol.Insert(inBid);
                return inBid;
            }
        }

        public Bid[] GetBids()
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var bidCol = db.GetCollection<Bid>("Bids");
                return bidCol.FindAll().ToArray();
            }
        }
    }
}