using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services.Authors;
using TaskAPI.Services.Models;

namespace TaskAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorReporsitory _service;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorReporsitory service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<AuthorDTO>> GetAuthors(string job, string search)
        {
            var authors = _service.GetAllAuthors(job, search);
            var mappedAuthors = _mapper.Map<ICollection<AuthorDTO>>(authors);
            return Ok(mappedAuthors);
        }

        [HttpGet("{id}")] 
        public IActionResult GetAuthor(int id)
        {
            var author = _service.GetAuthor(id);

            if (author is null)
            {
                return NotFound();
            }

            var mappedAuthor = _mapper.Map<AuthorDTO>(author);
            return Ok(mappedAuthor);
        }
    }
}
