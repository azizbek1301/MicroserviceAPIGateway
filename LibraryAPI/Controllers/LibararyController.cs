using LibraryAPI.DTOs;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LibararyController : ControllerBase
    {
        private readonly ILibrarySerice _librarySerice;
        public LibararyController(ILibrarySerice librarySerice)
        {
            _librarySerice = librarySerice;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateLibraryAsync(LibraryDto libraryDto)
        {
            var res = _librarySerice.CreateLibraryAsync(libraryDto);
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _librarySerice.GetAllLibraryAsync();
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _librarySerice.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await _librarySerice.DeleteByIdAsync(id);
            return Ok(res);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateEmployeeAsync(int id, LibraryDto libraryDto)
        {
            var res = await _librarySerice.UpdateLibraryAsync(id, libraryDto);
            return Ok(res);
        }
    }
}
