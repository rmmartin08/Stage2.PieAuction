using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LiteDB;
using PieAuction.BackEnd.Core.Models;

namespace PieAuction.BackEnd.Core.DataAccess
{
    public class PieDao : DaoBase
    {
        public Pie GetSinglePieById(Guid pieId)
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var pieCol = db.GetCollection<Pie>("Pies");
                return pieCol.FindById(pieId);
            }
        }

        public Pie[] GetPies(Expression<Func<Pie, bool>> predicate = null)
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var pieCol = db.GetCollection<Pie>("Pies");
                return predicate == null
                    ? pieCol.FindAll().ToArray()
                    : pieCol.Find(predicate).ToArray();
            }
        }

        public Pie InsertNewPie(Pie inPie)
        {
            using (var db = new LiteDatabase(PieAuctionDbLocation))
            {
                var pieCol = db.GetCollection<Pie>("Pies");
                var userDao = new AuctionUserDao();
                foreach (var madeByUserId in inPie.MadeByUserIds)
                {
                    var foundUser = userDao.GetSingleUserById(madeByUserId);
                    if (foundUser == null)
                    {
                        throw new KeyNotFoundException("User doesn't exist: " + madeByUserId.ToString());
                    }
                }
                var newPie = new Pie()
                {
                    Id = Guid.NewGuid(),
                    Flavor = inPie.Flavor,
                    IsGlutenFree = inPie.IsGlutenFree,
                    IsVegan = inPie.IsVegan,
                    MadeByUserIds = inPie.MadeByUserIds,
                    Name = inPie.Name,
                    SoldToUserId = null,
                    ImageAddress = inPie.ImageAddress,
                    StartDateTime = DateTime.Now,
                    EndDateTime = inPie.EndDateTime != default(DateTime) ? inPie.EndDateTime : DateTime.Now.AddHours(2)
                };

                pieCol.Insert(newPie);
                return newPie;
            }
        }
    }

}
