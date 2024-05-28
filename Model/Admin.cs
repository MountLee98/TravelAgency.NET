using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biuro_podrozy_praca_inzynierska.Model
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public Admin()
        {
            Name = "";
            Password = "";
        }

        public Admin(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
