using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Services.Interfaces
{
    public interface IAutor_Api
    {
        Task<List<Autor>> GetAutors();
        Task<bool> CreateAutor(Autor autor);
    }
}
