using AuthorAPI.ApplicationDbContext;
using AuthorAPI.DTOs;
using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDBContext _dbContext;
        public AuthorService(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        public async ValueTask<bool> CreateAuthorAsync(AuthorDto authorDto)
        {
            try
            {
                var res = new Author()
                {
                    Name = authorDto.Name,
                    Surname = authorDto.Surname,
                    Email = authorDto.Email,
                };
                await _dbContext.Authors.AddAsync(res);
                await _dbContext.SaveChangesAsync();
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
                var res = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
                if(res!=null)
                {
                    _dbContext.Authors.Remove(res);
                    await _dbContext.SaveChangesAsync();
                    return "Deleted";
                }
                else
                {
                    return "Not found Author";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<Author>> GetAllAsync()
        {
            try
            {
                var res = await _dbContext.Authors.AsNoTracking().ToListAsync();
                return res;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<Author> GetByIdAsync(int id)
        {
            try
            {
                var res = await _dbContext.Authors.FirstOrDefaultAsync(x=>x.Id==id);
                return res;

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateAuthorAsync(int id, AuthorDto authorDto)
        {
            try
            {
                var res = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    res.Name = authorDto.Name;
                    res.Surname = authorDto.Surname;
                    res.Email = authorDto.Email;
                    await _dbContext.SaveChangesAsync();
                    return "YAngilndi";
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
