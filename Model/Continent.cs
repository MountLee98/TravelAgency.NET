using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biuro_podrozy_praca_inzynierska.Model
{
    public class Continent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public List<Country> Countries { get; set; }

        public Continent()
        {
            Name = "";
            Countries = new List<Country>();
        }

        public Continent(string name)
        {
            Name = name;
            Countries = new List<Country>();
        }
    }
}
