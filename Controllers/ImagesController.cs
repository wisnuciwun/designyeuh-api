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
    public class ImagesController : Controller
    {
        private readonly MasterContext _context;

        public ImagesController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Images> GetImage()
        {
            return _context.Images.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> PostImageData ([FromBody] Images input)
        {
            var newVal = new Images();
            newVal.Id = new Guid();
            newVal.Author = input.Author;
            newVal.Filename = input.Filename;
            newVal.Link = input.Link;
            newVal.UploadDate = DateTime.Now;
            newVal.Title = input.Title;

            _context.Images.Add(newVal);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("SortByTime")]
        public IActionResult SortResumesByTimeAscending()
        {
            var data = _context.Images.OrderByDescending(x => x.UploadDate).Take(10);
            return new ObjectResult(data);
        }

        [HttpGet]
        [Route("SortByPopularity")]
        public IActionResult SortResumesByPopularityAscending()
        {
            var data = _context.Images.OrderByDescending(x => x.Downloaded).Take(10);
            return new ObjectResult(data);
        }

        [HttpGet]
        [Route("AllImages")]
        public IActionResult Allresumes([FromQuery] int page, int perpage)
        {
            var data =  _context.Images.OrderByDescending(x => x.UploadDate).ToList();

            var offset = (page - 1) * perpage;
            var paged = data.Skip(offset).Take(perpage);

            return new ObjectResult(paged);
        }

        [HttpGet]
        [Route("Pages")]
        public IActionResult GetPage()
        {
            var countpage = _context.Images.ToList().Count();
            return new ObjectResult(countpage);
        }

    }
}
