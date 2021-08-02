using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using designyeuh_api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace designyeuh_api.Controllers
{
    [ApiController]
    [Route("api/yB90ygbgjTjhdcf%gFhD0n!LJ")]
    [EnableCors("CorsPolicy")]
    public class DonationsController : Controller
    {
        private readonly MasterContext _context;
        public DonationsController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("p94pWBtP7t")]
        public List<Donations> GetContributors()
        {
            return _context.Donations.ToList();
        }
    }
}
