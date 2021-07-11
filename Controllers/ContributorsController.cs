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
    [Route("api/hbfaj7bbn%jfbHb$QnCnTPP7")]
    [EnableCors("CorsPolicy")]
    public class ContributorsController : Controller
    {
        private readonly MasterContext _context;

        public ContributorsController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("T3jS0WpBJP")]
        public List<Contributors> GetContributors()
        {
            return _context.Contributors.ToList();
        }

        [HttpPost]
        [Route("Poh5V8QnZe")]
        public async Task<IActionResult> PostContributorData ([FromBody] Contributors[] input)
        {
            foreach (var x in input)
            {
                var newVal = new Contributors();
                newVal.Id = new Guid();
                newVal.Instagram = x.Instagram;
                newVal.Facebook = x.Facebook;
                newVal.Twitter = x.Twitter;
                newVal.Name = x.Name;
                newVal.Creation = x.Creation;
                newVal.ImgLink = x.ImgLink;
                newVal.Address = x.Address;

                _context.Contributors.Add(newVal);
                await _context.SaveChangesAsync();
            }
             return Ok();
        }

        [HttpPut]
        [Route("aTYM06FNYK")]
        public async Task<IActionResult> PutDataContributor([FromBody] Contributors input, [FromQuery] Guid id)
        {
            var findId = _context.Contributors.Where(x => x.Id == id).FirstOrDefault();
            if(findId != null)
            {
                findId.Instagram = input.Instagram;
                findId.Facebook = input.Facebook;
                findId.Twitter = input.Twitter;
                findId.Name = input.Name;
                findId.Creation = input.Creation;
                findId.ImgLink = input.ImgLink;
                findId.Address = input.Address;
                _context.Entry(findId).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("tRJV7SoSx5")]
        public async Task<IActionResult> DeleteContributor ([FromQuery] Guid id) {
            var findId = await _context.Contributors.FindAsync(id);
            if (findId == null) {
                return NotFound ();
            }

            _context.Contributors.Remove (findId);
            await _context.SaveChangesAsync ();

            return Ok (findId);
        }
        
    }
}
