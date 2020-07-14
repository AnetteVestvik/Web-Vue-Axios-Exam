using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ResturantAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

/* ---- Controller for the Dish Admin  -----*/
/*----- Where the admin can delete, add and edit a dish -----*/
namespace ResturantAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class DishAdminController : ControllerBase{

        private readonly ResturantContext _context;
        private readonly IWebHostEnvironment _hosting;

        public DishAdminController(ResturantContext context, IWebHostEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }

        /*-------------------- Http get request to the API  -------------------------------*/
        [HttpGet]
        public async Task<IEnumerable<Dish>> Get(){
            List<Dish> dishList = await _context.Dish.ToListAsync();
            return dishList;
        }

        /*------------------ Http get by NAME request to the API  ---------------------------*/
        [HttpGet("{name}")]
        public async Task<Dish> Get(string name){
            Dish dish = await _context.Dish.FirstOrDefaultAsync( _dish => _dish.Name == name );
            return dish;
        }


        

        /*------------------ Http delete request to the API, deletes the dish in the API  -------------------*/
        [HttpDelete("{id}")]
        public async Task<Dish> Delete(int id){
            Dish dishToDelete = await _context.Dish.FirstAsync( dish => dish.Id == id );
            _context.Dish.Remove( dishToDelete );
            await _context.SaveChangesAsync();
            return dishToDelete;
        }
        /*------------------ Http put request to the API, makes it possible to edit a dish  ----------------*/
        [HttpPut]
        public async Task<Dish> Put(Dish updateDish){
            _context.Update(updateDish);
            await _context.SaveChangesAsync();
            return updateDish;
        }

        /*------------------ Http post request to the API, makes it possible to add a dish  -------------*/
        [HttpPost]
        public async Task<Dish> Post(Dish newDish){
            _context.Dish.Add(newDish);
            await _context.SaveChangesAsync();
            return newDish;
        }
        
        /*----------- Http post request to the API, makes it possible to add a dish with photo  -------------*/
        [HttpPost]
        [Route("[action]")]
        public void UploadImage(IFormFile file){
            string webRootPath = _hosting.WebRootPath;
            string absolutePath = Path.Combine($"{webRootPath}/images/{file.FileName}");
            using(var fileStream = new FileStream( absolutePath, FileMode.Create )){
                file.CopyTo( fileStream );
            }
        }

    }

}