using System;

namespace PieAuction.BackEnd.Core.Models
{
    public class AuctionUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsStudent { get; set; }
    }
}
