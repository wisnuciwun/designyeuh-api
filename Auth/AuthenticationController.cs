using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using designyeuh_api.Authentication;
using designyeuh_api.DTO;
using designyeuh_api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace designyeuh_api.Controllers
{
    [ApiController]
    [Route("api/cBdhiu^jfw%bfah*8TC4uTdd9f")]
    [EnableCors("CorsPolicy")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("MFwL8GPwO5")]
        public async Task<IActionResult> Register([FromBody] Register newUser)
        {
            var userExist = await userManager.FindByNameAsync(newUser.UserName);

            if(userExist != null)
            return BadRequest();

            ApplicationUser user = new ApplicationUser()
            {
                Email = newUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = newUser.UserName,        
            };
                        
            var result = await userManager.CreateAsync(user, newUser.Password);
            if(!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok(new ObjectResult("User Created Succesfully"));

            }

            [HttpPost]
            [Route("0mCEPcpnzp")]
            public async Task<ActionResult> Login([FromBody] Login login)
            {
                var userExist = await userManager.FindByEmailAsync(login.Email);

                if(userExist!=null && await userManager.CheckPasswordAsync(userExist, login.Password))
                {
                    var userRoles = await userManager.GetRolesAsync(userExist);
                    var authclaim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userExist.UserName),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };

                    foreach (var userrole in userRoles)
                    {
                        authclaim.Add(new Claim(ClaimTypes.Role, userrole));
                    }

                    var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(5),
                        claims: authclaim,
                        signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

                }

                return Unauthorized();

            }

        [Route("92p3S287zs")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin([FromBody] AspNetUsers newUser)
        {
            var userExist = await userManager.FindByEmailAsync(newUser.UserName);

            if(userExist != null)
            return BadRequest();

            ApplicationUser user = new ApplicationUser()
            {

                Email = newUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = newUser.UserName
            };
                        
            var result = await userManager.CreateAsync(user, newUser.Password);

            if(!result.Succeeded)
            {
                return BadRequest();
            }

            if(await roleManager.RoleExistsAsync(UserRoles.Admin))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if(await roleManager.RoleExistsAsync(UserRoles.User))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if(await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new ObjectResult("User Created Succesfully"));

            }

        }

    }
