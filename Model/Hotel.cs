using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace inz.Model
{
    public enum Stars
    {
        One,
        Two,
        Three,
        Four,
        Five
    }
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Stars Star { get; set; }
        [Required]
        public City City { get; set; }
        public List<Trip> Trips { get; set; }

        public Hotel()
        {
            Name = "";
            Star = new Stars();
            City = new City();
            Trips = new List<Trip>();
        }

        public Hotel(string name, Stars star, City city)
        {
            Name = name;
            Star = star;
            City = city;
            Trips = new List<Trip>();
        }
    }
}
