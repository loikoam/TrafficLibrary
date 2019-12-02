using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testService.Models;
using testService.Logic;
using testService.Data.Context;

namespace testService.Logic.Services
{
    class BookServices : IBookService
    {
        private TestServiceContext _context = new TestServiceContext();

        private bool _isDisposed;

        public void Dispose()//этот метод не должен вызывать исключения, не важно сколько раз он должен вызываться
        {
            Dispose(true);
        }

        ~BookServices()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed)
            {
                return;
            }

            _context?.Dispose();
            _isDisposed = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }

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
