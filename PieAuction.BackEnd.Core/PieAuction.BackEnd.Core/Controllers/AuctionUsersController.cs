using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PieAuction.BackEnd.Core.DataAccess;
using PieAuction.BackEnd.Core.Models;

namespace PieAuction.BackEnd.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionUsersController : ControllerBase
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