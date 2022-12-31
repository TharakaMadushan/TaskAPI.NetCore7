using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
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
            var authors = _service.GetAllAuthor(job, search);
            var mappedAuthors = _mapper.Map<ICollection<AuthorDTO>>(authors);
            return Ok(mappedAuthors);
        }

        [HttpGet("{id}", Name = "GetAuthor")] 
        public IActionResult GetAuthor(int id)
        {
            var author = _service.GetAuthor(id);

            if (author is null)
            {
                return (IActionResult)_service.GetAllAuthors();
            }

            var mappedAuthor = _mapper.Map<AuthorDTO>(author);
            return Ok(mappedAuthor);
        }

        [HttpPost]
        public ActionResult<CreateAuthorDTO> CreateAuthor (CreateAuthorDTO author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            var createAuthor = _service.AddAuthor(authorEntity);
            var authorForReturn = _mapper.Map <AuthorDTO>(createAuthor);


            return CreatedAtRoute("GetAuthor", new { id = authorForReturn.Id }, authorForReturn);
        }
    }
}
