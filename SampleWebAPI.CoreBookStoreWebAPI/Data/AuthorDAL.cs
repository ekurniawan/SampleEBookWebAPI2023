using System;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.CoreBookStoreWebAPI.Models;

namespace SampleWebAPI.CoreBookStoreWebAPI.Data
{
	public class AuthorDAL : IAuthor
	{
        private readonly PubContext _context;

        public AuthorDAL(PubContext context)
		{
            _context = context;
		}

        public async Task Delete(int id)
        {
            try
            {
                var deleteAuthor = await GetById(id);
                _context.Authors.Remove(deleteAuthor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}"); 
            }
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> GetById(int id)
        {
            var author = await _context.Authors.Where(a => a.AuthorId == id).FirstOrDefaultAsync();
            if (author != null)
                return author;
            else
                throw new Exception($"Author with id {id} not found");
        }

        public async Task<Author> Insert(Author author)
        {
            try
            {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return author;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Author> Update(Author author)
        {
            try
            {
                var updateAuthor = await GetById(author.AuthorId);
              
                updateAuthor.FirstName = author.FirstName;
                updateAuthor.LastName = author.LastName;
                await _context.SaveChangesAsync();
                return updateAuthor;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}

