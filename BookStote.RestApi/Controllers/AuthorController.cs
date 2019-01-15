using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookStore.Core.Interfaces;
using BookStore.Core.Entities;
using BookStote.RestApi.Filters;

namespace BookStote.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;

        public AuthorController(IAuthorService AuthorService)
        {
            _AuthorService = AuthorService;
        }

        // GET api/Author
        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            return _AuthorService.GetAll();
        }

        // GET api/Author/5
        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            return _AuthorService.Get(id);
        }

        // POST api/Author
        [HttpPost]
        public void Post([FromBody] Author Author)
        {
            //TODO Have a llok to put global validations
            _AuthorService.Add(Author);
        }

        // PUT api/Author/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author Author)
        {
            //TODO Have a llok to put global validations
            _AuthorService.Update(Author);
        }

        // DELETE api/Author/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO Have a llok to put global validations
            var b = _AuthorService.Get(id);

            if (b != null)
            {
                _AuthorService.Remove(b);
            }
        }
    }
}
