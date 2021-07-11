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

        [HttpPost]
        [Route("ZwxxizLrn8")]
        public async Task<IActionResult> PostDonationData ([FromBody] Donations[] input)
        {
            foreach (var x in input)
            {
                var newVal = new Donations();
                newVal.Id = new Guid();
                newVal.Payment = x.Payment;
                newVal.ImgLink = x.ImgLink;

                _context.Donations.Add(newVal);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPut]
        [Route("gBEK4VJDRV")]
        public async Task<IActionResult> PutDataDonation([FromBody] Donations input, [FromQuery] Guid id)
        {
            var findId = _context.Donations.Where(x => x.Id == id).FirstOrDefault();
            if(findId != null)
            {
                findId.Payment = input.Payment;
                findId.ImgLink = input.ImgLink;
                _context.Entry(findId).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("GGLNfjOCVx")]
        public async Task<IActionResult> DeleteDonation ([FromQuery] Guid id) {
            var findId = await _context.Donations.FindAsync(id);
            if (findId == null) {
                return NotFound ();
            }

            _context.Donations.Remove (findId);
            await _context.SaveChangesAsync ();

            return Ok (findId);
        }

    }
}
