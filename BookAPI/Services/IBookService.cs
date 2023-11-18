using BookAPI.DTOs;
using BookAPI.Models;

namespace BookAPI.Services
{
    public interface IBookService
    {
        public ValueTask<bool> CreateBookAsync (BookDto book);
        public ValueTask<List<Book>> GetAllBooksAsync ();
        public ValueTask<Book> GetByIdAsync (int id);
        public ValueTask<string>DeleteByIdAsync(int id);
        public ValueTask<string> UpdateBookAsync(int id, BookDto book);

    }
}
