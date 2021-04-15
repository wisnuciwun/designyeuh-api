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
    public class ContributorsController : Controller
    {
        private readonly MasterContext _context;

        public ContributorsController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Contributors> GetContributors()
        {
            return _context.Contributors.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> PostResumeData ([FromBody] Contributors input)
        {
            var newVal = new Contributors();
            newVal.Id = new Guid();
            newVal.Instagram = input.Instagram;
            newVal.Facebook = input.Facebook;
            newVal.Twitter = input.Twitter;
            newVal.Name = input.Name;
            newVal.Creation = input.Creation;
            newVal.ImgLink = input.ImgLink;

            _context.Contributors.Add(newVal);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
