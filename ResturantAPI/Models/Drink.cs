using System.ComponentModel.DataAnnotations;

/* ---- Defines the table Dish in the Database ---- */
namespace ResturantAPI.Models{

    public class Drink{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public int Size { get; set; }
        public string ImageSrc { get; set; }
    }
}