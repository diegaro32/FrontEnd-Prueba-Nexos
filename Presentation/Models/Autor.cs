using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class Autor
    {
        public int IdAutor { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public String CityName { get; set; }
        [Required]
        public int IdCity { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
