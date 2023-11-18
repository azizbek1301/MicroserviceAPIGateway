using BookAPI.DTOs;
using BookAPI.Models;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        public ValueTask<bool> CreateBookAsync(BookDto book)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<Book>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Book> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> UpdateBookAsync(int id, BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
