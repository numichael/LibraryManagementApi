using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetWebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public string Genre { get; set; }
        public char ISBN { get; set; }

        //ForeignKey
        //public int AuthorId { get; set; }
        //Navigation property
        //public Author Author { get; set;}   
    }
}