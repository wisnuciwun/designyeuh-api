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
    [Route("api/dZ8&nkpB7RsWpkTv$sVIm9TTy")]
    [EnableCors("CorsPolicy")]
    public class ImagesController : Controller
    {
        private readonly MasterContext _context;

        public ImagesController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("kn69JVJH1a")]
        public List<Images> GetImages()
        {
            return _context.Images.ToList();
        }

        [HttpGet]
        [Route("aCIJI6W7jp")]
        public IActionResult SortImagesByTimeAscending()
        {
            var data = _context.Images.OrderByDescending(x => x.UploadDate).Take(10);
            return new ObjectResult(data);
        }

        [HttpGet]
        [Route("9gW6Mq21Q5")]
        public IActionResult SortImagesByPopularityAscending()
        {
            var data = _context.Images.OrderByDescending(x => x.Downloaded).Take(10);
            return new ObjectResult(data);
        }

        [HttpGet]
        [Route("wPiArezdNl")]
        public IActionResult AllImages([FromQuery] int page, int perpage)
        {
            var data =  _context.Images.OrderByDescending(x => x.UploadDate).ToList();

            var offset = (page - 1) * perpage;
            var paged = data.Skip(offset).Take(perpage);

            return new ObjectResult(paged);
        }

        [HttpGet]
        [Route("NTX2ig1uX4")]
        public IActionResult GetPageImages()
        {
            var countpage = _context.Images.ToList().Count();
            return new ObjectResult(countpage);
        }

        [HttpPost]
        [Route("WKc7kvvUhp")]
        public async Task<IActionResult> PostDownloadedImages ([FromQuery] Guid id)
        {
            var find = _context.Images.Where(x => x.Id == id).FirstOrDefault();
            find.Downloaded = find.Downloaded + 1;

            _context.Images.Update(find);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
