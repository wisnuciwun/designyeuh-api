using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using designyeuh_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace designyeuh_api.Controllers
{
    [ApiController]
    [Route("api/xY9bN@KVMtk%zYwMMZUR5m&LS")]
    [EnableCors("CorsPolicy")]
    public class ResumesController : Controller
    {
        private readonly MasterContext _context;

        public ResumesController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("85Ac17eClf")]
        public List<Resumes> GetResumes()
        {
            return _context.Resumes.ToList();
        }


        [HttpGet]
        [Route("r2ImyKmxUZ")]
        public IActionResult SortResumesByTimeAscending()
        {
            var data = _context.Resumes.OrderByDescending(x => x.UploadDate).Take(10);
            return new ObjectResult(data);
        }

        [HttpGet]
        [Route("87stPpQrZy")]
        public IActionResult SortResumesByPopularityAscending()
        {
            var data = _context.Resumes.OrderByDescending(x => x.Downloaded).Take(10);
            return new ObjectResult(data);
        }

        [HttpGet]
        [Route("a1PfYcu7AB")]
        public IActionResult Allresumes([FromQuery] int page, int perpage)
        {
            var data =  _context.Resumes.OrderByDescending(x => x.UploadDate).ToList();

            var offset = (page - 1) * perpage;
            var paged = data.Skip(offset).Take(perpage);

            return new ObjectResult(paged);
        }

        [HttpGet]
        [Route("bWrc6tHEPR")]
        public IActionResult GetPageResumes()
        {
            var countpage = _context.Resumes.ToList().Count();
            return new ObjectResult(countpage);
        }

        [HttpPost]
        [Route("8CudWiLDO7")]
        public async Task<IActionResult> PostDownloadedResumes ([FromQuery] Guid id)
        {
            var find = _context.Resumes.Where(x => x.Id == id).FirstOrDefault();
            find.Downloaded = find.Downloaded + 1;

            _context.Resumes.Update(find);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
