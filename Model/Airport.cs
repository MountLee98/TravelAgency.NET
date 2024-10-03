using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace inz.Model
{
    public class Airport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public City City { get; set; }
        [InverseProperty("FromAirport")]
        public List<Trip> FromAirportTrips { get; set; }
        [InverseProperty("ToAirport")]
        public List<Trip> ToAirportTrips { get; set; }

        public Airport()
        {
            Name = "";
            City = new City();
            FromAirportTrips = new List<Trip>();
            ToAirportTrips = new List<Trip>();
        }

        public Airport(string name, City city)
        {
            Name = name;
            City = city;
            FromAirportTrips = new List<Trip>();
            ToAirportTrips = new List<Trip>();
        }
    }
}
