using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PieAuction.BackEnd.Data_Access
{
    public class DaoBase
    {
        public const string PieAuctionDbLocation = @"C:\PieAuction\PieAuction.db";

        public DaoBase()
        {
            var piaAuctionDbDir = Path.GetDirectoryName(PieAuctionDbLocation);
            if (piaAuctionDbDir != null && !Directory.Exists(piaAuctionDbDir))
            {
                Directory.CreateDirectory(piaAuctionDbDir);
            }
        }
    }
}