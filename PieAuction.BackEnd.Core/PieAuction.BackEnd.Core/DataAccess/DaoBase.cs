using System.IO;

namespace PieAuction.BackEnd.Core.DataAccess
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
