using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace inz.Model
{
    public class Role : IdentityRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public Role()
        {

        }

        public Role(string name, string normalizedName)
        {
            Name = name;
            NormalizedName = normalizedName;
        }
    }
}
