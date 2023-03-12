using System;
using SampleWebAPI.CoreBookStoreWebAPI.Models;

namespace SampleWebAPI.CoreBookStoreWebAPI.Data
{
	public interface IAuthor
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author> Insert(Author author);
		Task<Author> GetById(int id);
		Task<Author> Update(Author author);
		Task Delete(int id);
	}
}

