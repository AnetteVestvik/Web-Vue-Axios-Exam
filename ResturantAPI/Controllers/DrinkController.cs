using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

/* ---- Controller for the Drink ---- */
/* ---- Where the users can see the drinks ---- */
namespace ResturantAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase {

        private readonly ResturantContext _context;
        private readonly IWebHostEnvironment _hosting;

        public DrinkController(ResturantContext context, IWebHostEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }

        /*-------------------- Http get request to the API  -------------------------------*/
        [HttpGet]
        public async Task<IEnumerable<Drink>> Get(){
            List<Drink> drinkList = await _context.Drink.ToListAsync();
            return drinkList;            
        }
        
        
        
        /*
        [HttpPut]
        public async Task<Drink> Put(Drink updateDrink){
            _context.Update(updateDrink);
            await _context.SaveChangesAsync();
            return updateDrink;
        }
        */
        
      

    }

}