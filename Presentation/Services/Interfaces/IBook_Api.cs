using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Interfaces
{
    public interface IBook_Api
    {
        Task<List<Book>> GetBooks();
        Task<bool> CreateBook(Book book);
    }
}
