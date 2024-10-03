using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace inz.Model
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int NumId { get; set; }

        public String Name { get; set; }
        public String Surname { get; set; }
        public List<TripPurchase> TripPurchases { get; set; }
        public User()
        {
            Name = "";
            Surname = "";
            TripPurchases = new List<TripPurchase>();
        }
    }
}
