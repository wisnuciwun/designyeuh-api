using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using designyeuh_api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace designyeuh_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class DonationsController : Controller
    {
        private readonly MasterContext _context;
        public DonationsController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Donations> GetContributors()
        {
            return _context.Donations.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> PostResumeData ([FromBody] Donations input)
        {
            var newVal = new Donations();
            newVal.Id = new Guid();
            newVal.Payment = input.Payment;
            newVal.ImgLink = input.ImgLink;

            _context.Donations.Add(newVal);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
