using System.ComponentModel.DataAnnotations;

/* ---- Defines the table Dish in the Database ---- */
namespace ResturantAPI.Models{

    public class Dish{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public string Allergies { get; set; }
        public string Content { get; set; }
        public string ImageSrc { get; set; }
        public bool Vegetarian { get; set; }
        public int Rateing { get; set; }
    }
}