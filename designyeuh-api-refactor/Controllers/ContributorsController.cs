using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using designyeuh_api_refactor.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace designyeuh_api_refactor.Controllers
{
    [ApiController]
    [Route("api/GZKHwxPb8lxoIhQ")]
    [EnableCors("CorsPolicy")]
    public class ContributorsController : Controller
    {
        private readonly MasterContext _context;

        public ContributorsController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("T3jS0WpBJP")]
        public List<Contributors> GetContributors()
        {
            return _context.Contributors.ToList();
        }
    }
}
