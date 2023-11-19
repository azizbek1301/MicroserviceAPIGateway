using LibraryAPI.DTOs;
using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface ILibrarySerice
    {
        public ValueTask<bool> CreateLibraryAsync(LibraryDto libraryDto);
        public ValueTask<List<Library>> GetAllLibraryAsync();
        public ValueTask<Library> GetByIdAsync(int id);
        public ValueTask<string> DeleteByIdAsync(int id);
        public ValueTask<string> UpdateLibraryAsync(int id, LibraryDto libraryDto);
    }
}
