using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class Book
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public short NumberOfPages { get; set; }
        public string AutorName { get; set; }
        public int IdAutor { get; set; }
    }
}
