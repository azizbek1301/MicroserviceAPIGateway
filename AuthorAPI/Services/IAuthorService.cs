using AuthorAPI.DTOs;
using AuthorAPI.Models;

namespace AuthorAPI.Services
{
    public interface IAuthorService
    {
        public ValueTask<bool> CreateAuthorAsync(AuthorDto authorDto);
        public ValueTask<List<Author>>GetAllAsync();
        public ValueTask<Author> GetByIdAsync(int id);
        public ValueTask<string>DeleteByIdAsync(int id);
        public ValueTask<string> UpdateAuthorAsync(int id,AuthorDto authorDto);
    }
}
