using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public List<Author> GetAllAuthors(string job, string search)
        {
            if (string.IsNullOrWhiteSpace(job) && string.IsNullOrWhiteSpace(search))
            {
                return GetAllAuthors();
            }

            var authorCollection = _context.Authors as IQueryable<Author>;

            if (string.IsNullOrWhiteSpace(job))
            {
                job = job.Trim();
                authorCollection = authorCollection.Where(a => a.JobRole == job);
            }

            if (string.IsNullOrWhiteSpace(search))
            {
                job = job.Trim();
                authorCollection = authorCollection.Where(a => a.FullName.Contains(search));
            }

            return authorCollection.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _context.Authors.Find(id);
        }
    }
}
