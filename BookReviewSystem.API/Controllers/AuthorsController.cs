using BookReviewSystem.API.Data;
using BookReviewSystem.API.Models.Domain;
using BookReviewSystem.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookReviewSystemDbContext dbContext;

        public AuthorsController(BookReviewSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDomains = dbContext.Authors.ToList();
            var authorDtos = new List<AuthorDto>();

            foreach (var authorDomain in authorDomains)
            {
                authorDtos.Add(new AuthorDto()
                {
                    AuthorId = authorDomain.AuthorId,
                    FirstName = authorDomain.FirstName,
                    LastName = authorDomain.LastName
                });
            }
            return Ok(authorDtos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var authorDomain = dbContext.Authors.FirstOrDefault(x => x.AuthorId == id);
            
            if (authorDomain == null)
            {
                return NotFound();
            }

            var autorDto = new AuthorDto
            {
                AuthorId = authorDomain.AuthorId,
                FirstName = authorDomain.FirstName,
                LastName = authorDomain.LastName
            };
            return Ok(autorDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddAuthorRequestDto addAuthorDto)
        {
            var authorDomain = new Author
            {
                FirstName = addAuthorDto.FirstName,
                LastName = addAuthorDto.LastName
            };

            dbContext.Authors.Add(authorDomain);
            dbContext.SaveChanges();

            var authorDto = new AuthorDto
            {
                AuthorId = authorDomain.AuthorId,
                FirstName = addAuthorDto.FirstName,
                LastName = addAuthorDto.LastName
            };

            return CreatedAtAction(nameof(GetById), new { id = authorDomain.AuthorId }, authorDomain);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateAuthorRequestDto updateAuthorRequestDto)
        {
            var authorDomain = dbContext.Authors.FirstOrDefault(x => x.AuthorId == id);

            if (authorDomain == null)
            {
                return NotFound();
            }

            authorDomain.FirstName = updateAuthorRequestDto.FirstName;
            authorDomain.LastName = updateAuthorRequestDto.LastName;
            dbContext.SaveChanges();

            var auhorDto = new AuthorDto
            {
                AuthorId = authorDomain.AuthorId,
                FirstName = authorDomain.FirstName,
                LastName = authorDomain.LastName
            };
            return Ok(auhorDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var authotDomain = dbContext.Authors.FirstOrDefault(x => x.AuthorId == id);

            if (authotDomain == null)
            {
                return NotFound();
            }

            dbContext.Authors.Remove(authotDomain);
            dbContext.SaveChanges();

            var authorDto = new AuthorDto
            {
                AuthorId = authotDomain.AuthorId,
                FirstName = authotDomain.FirstName,
                LastName = authotDomain.LastName
            };
            return Ok(authorDto);
        }

    }
}
