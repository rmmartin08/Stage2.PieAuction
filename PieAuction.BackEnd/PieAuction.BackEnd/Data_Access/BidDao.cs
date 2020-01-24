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
        public Bid NewBid(Bid inBid)
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var bidCol = db.GetCollection<Bid>("Bids");
                var newBid = new Bid()
                {
                    Id = Guid.NewGuid(),
                    AuctionUserId = inBid.AuctionUserId,
                    PieId = inBid.PieId,
                    Amount = inBid.Amount,
                    Timestamp = DateTime.Now                
                    };

                   bidCol.Insert(newBid);
                   return newBid;
                }
           
        }
        }

    }

