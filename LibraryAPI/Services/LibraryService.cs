using LibraryAPI.DataAcsess;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class LibraryService : ILibrarySerice
    {
        private readonly AppDbContext _context;
        public LibraryService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async ValueTask<bool> CreateLibraryAsync(LibraryDto libraryDto)
        {
            try
            {

                var res = new Library()
                {
                    Name = libraryDto.Name,
                    
                };
                await _context.Libraries.AddAsync(res);
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
                var res = await _context.Libraries.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    _context.Libraries.Remove(res);
                    await _context.SaveChangesAsync();
                    return "o'chirildi";

                }
                else
                {
                    return "Not found";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Library>> GetAllLibraryAsync()
        {
            try
            {
                var res= await _context.Libraries.AsNoTracking().ToListAsync();
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Library> GetByIdAsync(int id)
        {
            try
            {
                var res = await _context.Libraries.FirstOrDefaultAsync(x => x.Id == id);
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateLibraryAsync(int id, LibraryDto libraryDto)
        {
            try
            {
                var res = await _context.Libraries.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    res.Name = libraryDto.Name;
                    
                    await _context.SaveChangesAsync();
                    return "Yangilandi";
                }
                else
                {
                    return "Topilmadi";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
