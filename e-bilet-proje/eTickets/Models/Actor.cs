using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profil Resmi")]
        [Required(ErrorMessage ="Profil Resmi zorunlu")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Adı ve Soy Adı")]
        [Required(ErrorMessage = "Ad ve Soy Ad zorunlu")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Ad ve Soy Ad 3-50 karakter arasında olmak zorunda")]
        public string FullName { get; set; }
        [Display(Name = "Biyografi")]
        [Required(ErrorMessage = "Biyografi zorunlu")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
