using System;
using System.Collections.Generic;
using BookStore.Core.Interfaces;
using BookStore.Core.Entities;
using BookStote.RestApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BookStote.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return _bookService.GetAll();
        }

        // GET api/book/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return _bookService.Get(id);
        }

        // POST api/book
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            try
            {
                _bookService.Add(book);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            //TODO Have a llok to put global validations
            _bookService.Update(book);
        }

        // DELETE api/book/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO Have a llok to put global validations
            var b = _bookService.Get(id);

            if (b != null)
            {
                _bookService.Remove(b);            
            }
        }
    }
}
