using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Biuro_podrozy_praca_inzynierska.Model
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Airport FromAirport { get; set; }
        [Required]
        public Airport ToAirport { get; set; }
        [Required]
        public Hotel Hotel { get; set; }
        public DateTime DepartureDate{ get; set; }
        public DateTime ArrivalDate { get; set; }
        public int DaysDuration => (ArrivalDate.Date - DepartureDate.Date).Days;
        [DataType(DataType.Currency)]
        public decimal PriceForAdult { get; set; }
        [DataType(DataType.Currency)]
        public decimal PriceForChild { get; set; }
        public bool IsLastMinute { get; set; }
        public bool IsFirstMinute { get; set; }
        [Required]
        public int NumberOfBooking { get; set; }
        public List<TripPurchase> ListOfBookings { get; set; }

        public Trip()
        {
            FromAirport = new Airport();
            ToAirport = new Airport();
            Hotel = new Hotel();
            NumberOfBooking = 0;
            ListOfBookings = new List<TripPurchase>();
        }
        public Trip(String name, Airport fromAirport, Airport toAirport, Hotel hotel, int numberOfBooking)
        {
            Name = name;
            FromAirport = fromAirport;
            ToAirport = toAirport;
            Hotel = hotel;
            NumberOfBooking = numberOfBooking;
            ListOfBookings = new List<TripPurchase>();
        }

        public Trip(String name, Airport fromAirport, Airport toAirport, Hotel hotel, DateTime deparutreDate, 
            DateTime arrivalDate, decimal priceForAdult, decimal priceForChild, bool isLastMinute, 
            bool isFirstMinute, int numberOfBooking)
        {
            Name = name;
            FromAirport = fromAirport;
            ToAirport = toAirport;
            Hotel = hotel;
            DepartureDate = deparutreDate;
            ArrivalDate = arrivalDate;
            PriceForAdult = priceForAdult;
            PriceForChild = priceForChild;
            IsLastMinute = isLastMinute;
            IsFirstMinute = isFirstMinute;
            NumberOfBooking = numberOfBooking;
            ListOfBookings = new List<TripPurchase>();
        }
    }
}
