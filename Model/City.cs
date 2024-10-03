using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace inz.Model
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Country Country { get; set; }
        public List<Hotel> Hotel { get; set; }
        public List<Airport> Airport { get; set; }

        public City()
        {
            Name = "";
            Country = new Country();
            Hotel = new List<Hotel>(); 
            Airport = new List<Airport>(); 
        }

        public City(string name, Country country)
        {
            Name = name;
            Country = country;
            Hotel = new List<Hotel>();
            Airport = new List<Airport>();
        }
    }
}
