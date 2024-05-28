using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biuro_podrozy_praca_inzynierska.Model
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Password { get; set; }
        public List<TripPurchase> TripPurchases { get; set; }

        public Client()
        {
            Name = "";
            Surname = "";
            Password = "";
            TripPurchases = new List<TripPurchase>();
        }

        public Client(string name, string surname, string password)
        {
            Name = name;
            Surname = surname;
            Password = password;
            TripPurchases = new List<TripPurchase>();
        }
    }
}
