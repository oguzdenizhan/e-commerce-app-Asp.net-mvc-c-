using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profil Resmi")]
        public string ProfilePictureURL { get; set; }

        [Display(Name ="Adı ve Soyadı")]
        public string FullName { get; set; }

        [Display(Name ="Biyografi")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
