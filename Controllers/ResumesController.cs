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

        [HttpGet]
        [Route("AllResumes")]
        public IActionResult Allresumes([FromQuery] int page, int perpage)
        {
            var data =  _context.Resumes.OrderByDescending(x => x.UploadDate).ToList();

            var offset = (page - 1) * perpage;
            var paged = data.Skip(offset).Take(perpage);

            return new ObjectResult(paged);
        }

        [HttpGet]
        [Route("Pages")]
        public IActionResult GetPage()
        {
            var countpage = _context.Resumes.ToList().Count();
            return new ObjectResult(countpage);
        }

        [HttpPost]
        [Route("Downloaded")]
        public async Task<IActionResult> PostDownloaded ([FromQuery] Guid id)
        {
            var find = _context.Resumes.Where(x => x.Id == id).FirstOrDefault();
            find.Downloaded = find.Downloaded + 1;

            _context.Resumes.Update(find);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
