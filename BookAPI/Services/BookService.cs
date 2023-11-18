using BookAPI.DataAcsess;
using BookAPI.DTOs;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async ValueTask<bool> CreateBookAsync(BookDto book)
        {
            try
            {
                var res = new Book()
                {
                    Name = book.Name,
                    Price = book.Price,
                };
                await _context.Books.AddAsync(res);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async ValueTask<string> DeleteByIdAsync(int id)
        {
            try
            {
                var res = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
                if(res !=null)
                {
                    _context.Books.Remove(res);
                    await _context.SaveChangesAsync();
                    return "Delete";
                }
                else
                {
                    return "Not found Book";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Book>> GetAllBooksAsync()
        {
            try
            {
                var res = await _context.Books.AsNoTracking().ToListAsync();
                return res;

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Book> GetByIdAsync(int id)
        {
            try
            {
                var res = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateBookAsync(int id, BookDto book)
        {
            try
            {
                var res = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    res.Name = book.Name;
                    res.Price = book.Price;
                    await _context.SaveChangesAsync();
                    return "Yangilandi";
                }
                else
                {
                    return "Topilmadi";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
