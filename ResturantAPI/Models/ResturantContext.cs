using Microsoft.EntityFrameworkCore;

namespace ResturantAPI.Models{

    public class ResturantContext : DbContext {
        
        public ResturantContext( DbContextOptions<ResturantContext> options) : base(options){}

        public DbSet<Dish> Dish { get; set; }
        public DbSet<Drink> Drink { get; set; }

    }

}