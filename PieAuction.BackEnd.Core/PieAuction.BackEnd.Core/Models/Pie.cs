using System;

namespace PieAuction.BackEnd.Core.Models
{
    public class Pie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Flavor { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsVegan { get; set; }
        public Guid[] MadeByUserIds { get; set; }
        public Guid? SoldToUserId { get; set; }
        public string ImageAddress { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
