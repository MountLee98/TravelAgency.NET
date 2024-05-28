using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biuro_podrozy_praca_inzynierska.Model
{
    public class TripPurchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public int ChildNumber { get; set; }
        [Required]
        public int AdultNumber { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public Trip Trip { get; set; }

        public TripPurchase()
        {
            ChildNumber = 0;
            AdultNumber = 0;
            Price = 0;
            Client = new Client();
            Trip = new Trip();
        }

        public TripPurchase(int childNumber, int adultNumber, decimal price, Client client, Trip trip)
        {
            ChildNumber = childNumber;
            AdultNumber = adultNumber;
            Price = price;
            Client = client;
            Trip = trip;
        }
    }
}
