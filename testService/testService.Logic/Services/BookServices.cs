using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testService.Models;

namespace testService.Logic.Services
{
    class BookServices : IBookService
    {
        //getById, GetAll... methods
        public Book GetById(string id)
        {
            //тут должно быть какое-либо преобразование, иначе не имеет смысла
            return BookStorage.GetById(id);
        }
        public IEnumerable<Book> GetAll()
        {
            return BookStorage.GetAll();
        }
    }
}
