using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PieAuction.BackEnd.Core.DataAccess;
using PieAuction.BackEnd.Core.Models;

namespace PieAuction.BackEnd.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiesController : ControllerBase
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