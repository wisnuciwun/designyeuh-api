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
    [Route("api/byg7Gvd%hfjam&n8BEU5r77Q")]
    [EnableCors("CorsPolicy")]
    public class UsersController : Controller
    {
        private readonly MasterContext _context;

        public UsersController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("6kJQ6Tqyzt")]
        public List<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpPost]
        [Route("q6gsc9mXIY")]
        public async Task<IActionResult> PostUsersData ([FromBody] Users input)
        {

            var newVal = new Users();
            newVal.Id = new Guid();
            newVal.Username = input.Username;
            newVal.Nationality = input.Nationality;
            newVal.Born = input.Born;
            newVal.Created_Date = DateTime.Now;
            newVal.Address = input.Address;
            newVal.Works = input.Works;
            newVal.Role_Privileges = "TAQcA2b6Pa";
            _context.Users.Add(newVal);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("SNhhB1KYCc")]
        public async Task<IActionResult> PutDataUser([FromBody] Users input, [FromQuery] Guid id)
        {
            var findId = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if(findId != null)
            {
                findId.Username = input.Username;
                findId.Born = input.Born;
                findId.Nationality = input.Nationality;
                findId.Address = input.Address;
                findId.Role_Privileges = input.Role_Privileges;
                _context.Entry(findId).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("wlcBSH0EA1")]
        public async Task<IActionResult> DeleteUser ([FromQuery] Guid id) {
            var findId = await _context.Users.FindAsync(id);
            if (findId == null) {
                return NotFound ();
            }

            _context.Users.Remove (findId);
            await _context.SaveChangesAsync ();

            return Ok (findId);
        }
    }
}
