using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using designyeuh_api.Authentication;
using designyeuh_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace designyeuh_api.Controllers
{
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/pehYG75jb$9*6rQWx^A4mOpW")]
    [EnableCors("CorsPolicy")]
    public class AdministratorController : Controller
    {
        private readonly MasterContext _context;

        public AdministratorController(MasterContext context)
        {
            _context = context;
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

        [HttpPost]
        [Route("dik25dWhR6")]
        public async Task<IActionResult> PostImagesData ([FromBody] Images[] input)
        {
              foreach (var x in input)
            {
                var newVal = new Images();
                newVal.Id = new Guid();
                newVal.Author = x.Author;
                newVal.Filename = x.Filename;
                newVal.Link = x.Link;
                newVal.Link_Mobile = x.Link_Mobile;
                newVal.UploadDate = DateTime.Now;
                newVal.Title = x.Title;
                newVal.Downloaded = 0;
                _context.Images.Add(newVal);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPut]
        [Route("aNho5iy0Ve")]
        public async Task<IActionResult> PutDataImage([FromBody] Images input, [FromQuery] Guid id)
        {
            var findId = _context.Images.Where(x => x.Id == id).FirstOrDefault();
            if(findId != null)
            {
                findId.Link = input.Link;
                findId.Link_Mobile = input.Link_Mobile;
                findId.Title = input.Title;
                findId.UploadDate = input.UploadDate;
                findId.Author = input.Author;
                findId.Filename = input.Filename;
                _context.Entry(findId).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("dPSfTOsrEa")]
        public async Task<IActionResult> DeleteImage ([FromQuery] Guid id) {
            var findId = await _context.Images.FindAsync(id);
            if (findId == null) {
                return NotFound ();
            }

            _context.Images.Remove (findId);
            await _context.SaveChangesAsync ();

            return Ok (findId);
        }

        [HttpPost]
        [Route("TwcHvQWwS6")]
        public async Task<IActionResult> PostResumesData ([FromBody] Resumes[] input)
        {
            foreach (var x in input)
            {
                var newVal = new Resumes();
                newVal.Id = new Guid();
                newVal.Author = x.Author;
                newVal.Filename = x.Filename;
                newVal.Link = x.Link;
                newVal.UploadDate = DateTime.Now;
                newVal.Title = x.Title;
                newVal.Downloaded = 0;

                _context.Resumes.Add(newVal);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPut]
        [Route("KROBFzOhPN")]
        public async Task<IActionResult> PutDataResume([FromBody] Resumes input, [FromQuery] Guid id)
        {
            var findId = _context.Resumes.Where(x => x.Id == id).FirstOrDefault();
            if(findId != null)
            {
                findId.Link = input.Link;
                findId.Title = input.Title;
                findId.UploadDate = input.UploadDate;
                findId.Author = input.Author;
                findId.Filename = input.Filename;
                _context.Entry(findId).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("5FCFfRqbqO")]
        public async Task<IActionResult> DeleteResume ([FromQuery] Guid id) {
            var findId = await _context.Resumes.FindAsync(id);
            if (findId == null) {
                return NotFound ();
            }

            _context.Resumes.Remove (findId);
            await _context.SaveChangesAsync ();

            return Ok (findId);
        }
    }
}
