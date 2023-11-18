using AuthorAPI.DTOs;
using AuthorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
            
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateAuthorAsync(AuthorDto authorDto)
        {
            var res=_authorService.CreateAuthorAsync(authorDto);
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res=await _authorService.GetAllAsync();
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res=await _authorService.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res=await _authorService.DeleteByIdAsync(id);   
            return Ok(res);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateAuthorAsync(int id, AuthorDto authorDto)
        {
            var res=await _authorService.UpdateAuthorAsync(id, authorDto);
            return Ok(res);
        }
        
    }
}
