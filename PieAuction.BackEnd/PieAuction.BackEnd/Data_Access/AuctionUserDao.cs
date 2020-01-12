using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using LiteDB;
using PieAuction.BackEnd.Models;

namespace PieAuction.BackEnd.Data_Access
{
    public class AuctionUserDao: DaoBase
    {
        public AuctionUser GetSingleUserById(Guid userId)
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var userCol = db.GetCollection<AuctionUser>("Users");
                return userCol.FindById(userId);
            }
        }

        public AuctionUser[] GetFilteredListOfUsers(Expression<Func<AuctionUser, bool>> predicate = null)
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var userCol = db.GetCollection<AuctionUser>("Users");
                if (predicate == null)
                {
                    return userCol.FindAll().ToArray();
                }
                else
                {
                    return userCol.Find(predicate).ToArray();
                }
            }

        }

        public AuctionUser NewUser(AuctionUser inUser)
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var userCol = db.GetCollection<AuctionUser>("Users");
                var newUser = new AuctionUser()
                {
                    Id = Guid.NewGuid(),
                    FirstName = inUser.FirstName,
                    LastName = inUser.LastName,
                    IsStudent = inUser.IsStudent
                };

                userCol.Insert(newUser);
                return newUser;
            }
        }
    }
}