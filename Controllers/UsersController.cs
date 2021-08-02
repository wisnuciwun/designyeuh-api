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
    [Authorize]
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
        public List<AspNetUsers> GetAspNetUsers()
        {
            return _context.AspNetUsers.ToList();
        }

        // [HttpGet]
        // [Route("xheFS312s5")]
        // public async Task<IActionResult> GetUserFavorites([FromQuery] string username)
        // {
        //     var usernameData = await _context.AspNetUsers.Select(x => x.Interest_Item).ToListAsync();

        //     string
        // }


        // [HttpPut]
        // [Route("SNhhB1KYCc")]
        // public async Task<IActionResult> PutDataUser([FromBody] AspNetUsers input, [FromQuery] Guid id)
        // {
        //     var findId = _context.AspNetUsers.Where(x => x.Id == id).FirstOrDefault();
        //     if(findId != null)
        //     {
        //         findId.UserName = input.UserName;
        //         findId.Born = input.Born;
        //         findId.Nationality = input.Nationality;
        //         // findId.Password = input.Password;
        //         findId.Role_Privileges = input.Role_Privileges;
        //         _context.Entry(findId).State = EntityState.Modified;
        //         await _context.SaveChangesAsync();
        //     }
        //     return Ok();
        // }

        [HttpDelete]
        [Route("wlcBSH0EA1")]
        public async Task<IActionResult> DeleteUser ([FromQuery] Guid id) {
            var findId = await _context.AspNetUsers.FindAsync(id);
            if (findId == null) {
                return NotFound ();
            }

            _context.AspNetUsers.Remove (findId);
            await _context.SaveChangesAsync ();

            return Ok (findId);
        }
    }
}
