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
        public ActionResult<ICollection<AuthorDTO>> GetAuthors()
        {
            var authors = _service.GetAllAuthors();
            var mappedAuthors = _mapper.Map<ICollection<AuthorDTO>>(authors);
            //var authorDto = new List<AuthorDTO>();

            //foreach (var author in authors)
            //{
            //    authorDto.Add(new AuthorDTO
            //    {
            //        Id = author.Id,
            //        FullName = author.FullName,
            //        Address = $"{author.AddressNo}, {author.Street}, {author.City}"
            //    });
            //}

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
