using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biuro_podrozy_praca_inzynierska.Model
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Continent Continent { get; set; }
        public List<City> Cities { get; set; }

        public Country()
        {
            Name = "";
            Continent = new Continent();
            Cities = new List<City>();
        }

        public Country(string name, Continent continent)
        {
            Name = name;
            Continent = continent;
            Cities = new List<City>();
        }
    }
}
