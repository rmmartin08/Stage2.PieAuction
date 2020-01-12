using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LiteDB;
using PieAuction.BackEnd.Data_Access;
using PieAuction.BackEnd.Models;

namespace PieAuction.BackEnd.Controllers
{
    [RoutePrefix("api/pies")]
    public class PiesController : ApiController
    {
        [HttpGet]
        [Route("{pieId:Guid}")]
        public Pie GetSinglePie(Guid pieId)
        {
            var pieDao = new PieDao();
            return pieDao.GetSinglePieById(pieId);
        }

        [HttpGet]
        public Pie[] GetPies(bool? isVegan = null, bool? isGlutenFree = null, string flavor = null, Guid? madeByUserId = null, int? limit = null, bool? randomOrder = null)
        {
            var pieDao = new PieDao();
            IEnumerable<Pie> pies = pieDao.GetPies();

            if (isVegan.HasValue)
            {
                pies = pies.Where(p => p.IsVegan == isVegan.Value);
            }

            if (isGlutenFree.HasValue)
            {
                pies = pies.Where(p => p.IsGlutenFree == isGlutenFree.Value);
            }

            if (!string.IsNullOrWhiteSpace(flavor))
            {
                pies = pies.Where(p => p.Flavor.Contains(flavor));
            }

            if (madeByUserId.HasValue)
            {
                pies = pies.Where(p => p.MadeByUserIds.Contains(madeByUserId.Value));
            }

            if (randomOrder.HasValue)
            {
                var rand = new Random();
                pies = pies.OrderBy(p => rand.NextDouble());
            }

            if (limit.HasValue)
            {
                pies = pies.Take(limit.Value);
            }

            return pies.ToArray();
        }

        [HttpPost]
        public Pie AddNewPie(Pie inPie)
        {
            var pieDao = new PieDao();
            return pieDao.InsertNewPie(inPie);
        }
    }
}
