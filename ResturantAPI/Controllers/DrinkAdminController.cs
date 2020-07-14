using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ResturantAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

/* ---- Controller for the Drink Admin  -----*/
/*----- Where the admin can delete, add and edit a drink -----*/
namespace ResturantAPI.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class DrinkAdminController : ControllerBase{

        private readonly ResturantContext _context;
        private readonly IWebHostEnvironment _hosting;

        public DrinkAdminController(ResturantContext context, IWebHostEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }

        /*-------------------- Http get request to the API  -------------------------------*/
        [HttpGet]
        public async Task<IEnumerable<Drink>> Get(){
            List<Drink> drinkList = await _context.Drink.ToListAsync();
            return drinkList;
        }
        /*------------------ Http get by NAME request to the API  ---------------------------*/
        [HttpGet("{name}")]
        public async Task<Drink> Get(string name){
            Drink drink = await _context.Drink.FirstOrDefaultAsync( _drink => _drink.Name == name );
            return drink;
        }
        
        /*------------------ Http delete request to the API, deletes the drink in the API  -------------------*/
        [HttpDelete("{id}")]
        public async Task<Drink> Delete(int id){
            Drink drinkToDelete = await _context.Drink.FirstAsync( drink => drink.Id == id );
            _context.Drink.Remove( drinkToDelete );
            await _context.SaveChangesAsync();
            return drinkToDelete;
        }

        /*------------------ Http post request to the API, makes it possible to add a drink  -------------*/
        [HttpPost]
        public async Task<Drink> Post(Drink newDrink){
            _context.Drink.Add(newDrink);
            await _context.SaveChangesAsync();
            return newDrink;
        }

        /*------------------ Http put request to the API, makes it possible to edit a drink  ----------------*/
        [HttpPut]
        public async Task<Drink> Put(Drink updateDrink){
            _context.Update(updateDrink);
            await _context.SaveChangesAsync();
            return updateDrink;
        }

        /*----------- Http post request to the API, makes it possible to add a drink with photo  -------------*/
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