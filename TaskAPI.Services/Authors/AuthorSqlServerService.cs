using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.DataAccess;
using TaskAPI.Models;

namespace TaskAPI.Services.Authors
{
    public class AuthorSqlServerService : IAuthorReporsitory
    {
        private readonly ToDoDbContext _context = new ToDoDbContext();
        public List<Author> GetAllAuthors()
        {
           return _context.Authors.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _context.Authors.Find(id);
        }
    }
}
