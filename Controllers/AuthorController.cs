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
public class AuthorController : ControllerBase
{
     private readonly AppDbContext _context;
        
        public AuthorController(AppDbContext context)
        {
            _context = context;
        }
    
    // GET all action
    [HttpGet]

        public ActionResult<List<Author>> GetAll()
        {
            List<Author> authors = _context.Authors.ToList();
            return Ok(authors);
        }

    // GET by Id action
    [HttpGet("{Id}")]

        public IActionResult SingleBook(int Id)
        {
            if (Id <= 0) return NotFound();

            var author = _context.Authors.FirstOrDefault(x => x.Id == Id);

            if (author == null)
        {
            return NotFound();
        }

            return Ok(author);
        }

    // POST action
    [HttpPost]

        public IActionResult Add(Author model)
            {
                if (model == null) throw new ArgumentNullException(message: "Author cannot be null", null);

                 _context.Authors.Add(model);
                 _context.SaveChanges();
                 return CreatedAtAction("Add", model);
            }

    // PUT action
    [HttpPut("{Id}")]

        public IActionResult EditAuthor( int Id, [FromBody] Author model)
        {
                if (Id <= 0) return NotFound();
                if (model == null) throw new ArgumentNullException(message: "Author cannot be null", null);

                var author = _context.Authors.FirstOrDefault(x => x.Id == Id);

                if (author == null)
                {
                    return NotFound();
                }

                author.Id = model.Id;
                author.Name = model.Name;

                _context.Authors.Update(author);
                _context.SaveChanges();
                return Ok(author);
            }

    // DELETE action
    [HttpDelete("{Id}")]

            public IActionResult DeleteAuthor(int Id)
            {
                  if (Id <= 0) return NotFound();

                  var author = _context.Authors.FirstOrDefault(x => x.Id == Id);
                    
                 if (author == null)
                 {
                    return NotFound();
                 }

                 _context.Authors.Remove(author);
                 _context.SaveChanges();
                 return Ok(author);
            }
}
}

