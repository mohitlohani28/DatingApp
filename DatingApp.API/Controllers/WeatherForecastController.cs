using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        public WeatherForecastController(DataContext context)
        {
            this._context = context;

        }
        public async Task<IActionResult> Get()
        {
            var data= await _context.Values.ToListAsync();

              return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var d= await _context.Values.Where(s=>s.Id==id).FirstOrDefaultAsync();

            if(d==null){
              return NotFound("Data not found");
            }

            return Ok(d);
        }
    }
}
