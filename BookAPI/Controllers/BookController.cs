using BookAPI.DTOs;
using BookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
            
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateBookAsync(BookDto bookDto)
        {
            var res=_bookService.CreateBookAsync(bookDto);
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res=await _bookService.GetAllBooksAsync();
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _bookService.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res=await _bookService.DeleteByIdAsync(id);
            return Ok(res);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateBookAsync(int id, BookDto bookDto)
        {
            var res=await _bookService.UpdateBookAsync(id, bookDto);
            return Ok(res);
        }
    }
}
