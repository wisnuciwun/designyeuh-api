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
    public class ResumesController : Controller
    {
        private readonly MasterContext _context;

        public ResumesController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Resumes> GetResume()
        {
            return _context.Resumes.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> PostResumeData ([FromBody] Resumes input)
        {
            var newVal = new Resumes();
            newVal.Id = new Guid();
            newVal.Author = input.Author;
            newVal.Filename = input.Filename;
            newVal.Link = input.Link;
            newVal.UploadDate = DateTime.Now;
            newVal.Title = input.Title;

            _context.Resumes.Add(newVal);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("SortByTime")]
        public IActionResult SortResumesByTimeAscending()
        {
            var data = _context.Resumes.OrderByDescending(x => x.UploadDate).Take(10);
            return new ObjectResult(data);
        }

        [HttpGet]
        [Route("SortByPopularity")]
        public IActionResult SortResumesByPopularityAscending()
        {
            var data = _context.Resumes.OrderByDescending(x => x.Downloaded).Take(10);
            return new ObjectResult(data);
        }

    }
}
