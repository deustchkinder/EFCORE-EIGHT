using App.Data;
using App.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserxController : ControllerBase
    {
        private readonly MyDbContext _db;
        public UserxController(MyDbContext db)
        {
            _db = db;
        }

        [HttpPost("/")]
        public async Task<IActionResult> Post([FromBody] Userx userx)
        {
            await _db.Users.AddAsync(userx);
            await _db.SaveChangesAsync();
            return Ok(userx);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Users.ToListAsync());
        }
    }
}
