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
    [RoutePrefix("api/auctionusers")]
    public class AuctionUsersController : ApiController
    {
        [HttpGet]
        [Route("{userId:Guid}")]
        public AuctionUser GetAuctionUser(Guid userId)
        {
            var userDao = new AuctionUserDao();
            return userDao.GetSingleUserById(userId);
        }

        [HttpGet]
        public AuctionUser[] GetAuctionUsers(bool? isStudent = null)
        {
            var userDao = new AuctionUserDao();
            IEnumerable<AuctionUser> users = userDao.GetFilteredListOfUsers();
            if (isStudent.HasValue)
            {
                users = users.Where(u => u.IsStudent == isStudent.Value);
            }

            return users.ToArray();
        }

        [HttpPost]
        public AuctionUser NewAuctionUser(AuctionUser inUser)
        {
            var userDao = new AuctionUserDao();
            return userDao.NewUser(inUser);
        }
    }
}
