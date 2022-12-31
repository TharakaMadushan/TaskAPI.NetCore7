using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services.Authors
{
    public interface IAuthorReporsitory
    {
        public List<Author> GetAllAuthors();
        public List<Author> GetAllAuthor(string job, string search);
        public Author GetAuthor(int id);
        public Author AddAuthor(Author author);
    }
} 
