using System;
using System.Collections.Generic;
using System.Linq;
using AspNetWebApi.Data;
using AspNetWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebApi.Controllers
{
    
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
     private readonly AppDbContext _context;
        
        public BookController(AppDbContext context)
        {
            _context = context;
        }
    
    // GET all action
    [HttpGet]

        public ActionResult<List<Book>> GetAll()
        {
            List<Book> books = _context.Books.ToList();
            return Ok(books);
        }

    // GET by Id action
    [HttpGet("{Id}")]

        public IActionResult SingleBook(int Id)
        {
            if (Id <= 0) return NotFound();

            var book = _context.Books.FirstOrDefault(x => x.Id == Id);

            if (book == null)
        {
            return NotFound();
        }

            return Ok(book);
        }

    // POST action
    [HttpPost]

        public IActionResult Add(Book model)
            {
                if (model == null) throw new ArgumentNullException(message: "Book cannot be null", null);

                 _context.Books.Add(model);
                 _context.SaveChanges();
                 return CreatedAtAction("Add", model);
            }

    // PUT action
    [HttpPut("{Id}")]

        public IActionResult EditBook( int Id, [FromBody] Book model)
        {
                if (Id <= 0) return NotFound();
                if (model == null) throw new ArgumentNullException(message: "Book cannot be null", null);

                var book = _context.Books.FirstOrDefault(x => x.Id == Id);

                if (book == null)
                {
                    return NotFound();
                }

                book.Id = model.Id;
                book.Title = model.Title;
                book.Author = model.Author;
                book.Price = model.Price;
                book.Genre = model.Genre;
                book.ISBN = model.ISBN;

                _context.Books.Update(book);
                _context.SaveChanges();
                return Ok(book);
            }

    // DELETE action
    [HttpDelete("{Id}")]

            public IActionResult DeleteBook(int Id)
            {
                  if (Id <= 0) return NotFound();

                  var book = _context.Books.FirstOrDefault(x => x.Id == Id);
                    
                 if (book == null)
                 {
                    return NotFound();
                 }

                 _context.Books.Remove(book);
                 _context.SaveChanges();
                 return Ok(book);
            }
}
}

