using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testService.Models
{
    public class Book
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public string Title { get; set; }

        public double Price { get; set; }
    }

    public static class BookStorage
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book()
            {
                Title = "Book 1",
                Price = 10.0
            },
            new Book()
            {
                Title = "Book 2",
                Price = 20.0
            }
        };

        public static IEnumerable<Book> GetAll()
        {
            return _books.AsReadOnly();
        }

        public static Book GetById(string id)
        {
            return _books.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static Book Add(Book book)
        {
            book.Id = Guid.NewGuid().ToString();
            _books.Add(book);    // id записи вы формируем на стороне сервера, а не на стороне клиента
            return book;
        }

    }
}