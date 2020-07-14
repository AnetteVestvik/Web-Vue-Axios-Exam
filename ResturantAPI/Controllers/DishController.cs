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

/* ---- Controller for the Dish ---- */
/* ---- Where the users can see the dishes ---- */
namespace ResturantAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase {

        private readonly ResturantContext _context;
        private readonly IWebHostEnvironment _hosting;

        public DishController(ResturantContext context, IWebHostEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }

        /*-------------------- Http get request to the API  -------------------------------*/
        [HttpGet]
        public async Task<IEnumerable<Dish>> Get(){
            List<Dish> dishList = await _context.Dish.ToListAsync();
            return dishList;            
        }
        
        /*------------------ Http get by ID request to the API  ---------------------------*/
        [HttpGet("{id}")]
        public async Task<Dish> Get(int id){
            Dish dish = await _context.Dish.FirstOrDefaultAsync( _dish => _dish.Id == id );
            return dish;
        }
        
        /*------------- Http put request to the API, makes it possible to edit a dish's rating  ---------*/
        [HttpPut]
        public async Task<Dish> Put(Dish updateDish){
            _context.Update(updateDish);
            await _context.SaveChangesAsync();
            return updateDish;
        }

        

    }

}