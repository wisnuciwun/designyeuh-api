using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using designyeuh_api_refactor.Authentication;
using designyeuh_api_refactor.DTO;
using designyeuh_api_refactor.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace designyeuh_api_refactor.Controllers
{
    [ApiController]
    [Route("api/amRd2xPxrZeDe8K")]
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
            var userExist = await userManager.FindByEmailAsync(newUser.Email);

            if(userExist != null)
            return BadRequest("User already exist");

            var send = SendEmail($"{newUser.UserName}", $"{newUser.Email}", $"Welcome {newUser.UserName} !", "Thank you for registering. If you receipt this email, it means you already registered in our Database system. Your personal data is stored only in our own machine, doubtless wouldn't go anywhere. And your password also safer with Password Hash configuration. Now, you can login in Designyeuh website with this email everytime and anywhere. \r\rEnjoy ;)"); 
            
            Task.WaitAll(send);   

                ApplicationUser user = new ApplicationUser()
                {
                    Email = newUser.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = newUser.UserName,
                    Role_Privileges = UserRoles.User,
                    Nationality = newUser.Nationality,
                    Created_Date = DateTime.Now,
                    Born = newUser.Born,
                    Works = newUser.Works
                };

                var result = await userManager.CreateAsync(user, newUser.Password);
                if(!result.Succeeded)
                {
                    return BadRequest("Failed to create user");
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
                    new Claim(ClaimTypes.Name, userExist.UserName, userExist.Id),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                foreach (var userrole in userRoles)
                {
                    authclaim.Add(new Claim(ClaimTypes.Role, userrole));
                }

                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: userExist.Role_Privileges,
                    expires: DateTime.Now.AddHours(5),
                    claims: authclaim,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token)});

            }
            
            return Unauthorized();
        }

        [Route("92p3S287zs")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin([FromBody] Register newUser)
        {
            var userExist = await userManager.FindByNameAsync(newUser.UserName);

            if(userExist != null)
            return BadRequest();

            ApplicationUser user = new ApplicationUser()
            {
                UserName = newUser.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = newUser.Email,
                Role_Privileges = UserRoles.Admin,
                Created_Date = DateTime.Now
            };
                        
            var result = await userManager.CreateAsync(user, newUser.Password);

            if(!result.Succeeded)
            {
                return BadRequest();
            }

            if(!await roleManager.RoleExistsAsync(UserRoles.Admin))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if(!await roleManager.RoleExistsAsync(UserRoles.User))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if(await roleManager.RoleExistsAsync(UserRoles.Admin))
            await userManager.AddToRoleAsync(user, UserRoles.Admin);

            return Ok(new ObjectResult("Admin Created Succesfully"));
        }

        public async Task<IActionResult> SendEmail(string To, string Toaddress, string Subject, string Texts)
        {
            var From = _configuration["EMAIL:UserName"];
            var Fromaddress = _configuration["EMAIL:Address"];

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(From,Fromaddress));
            message.To.Add(new MailboxAddress(To,Toaddress));
            message.Subject = Subject;
            message.Body = new  TextPart("plain"){
                Text = Texts
            };
            
            await Task.Delay(1);

            using (var client = new SmtpClient()){
                client.ServerCertificateValidationCallback = (s,c,h,e) => true;
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.Auto);
                client.Authenticate(Fromaddress, _configuration["EMAIL:Key"]);
                client.Send(message);
                client.Disconnect(true);
            }

            return Ok();

        }
    }
}
