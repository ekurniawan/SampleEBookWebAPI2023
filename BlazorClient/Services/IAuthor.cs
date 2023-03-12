using System;
using BlazorClient.Models;

namespace BlazorClient.Services
{
	public interface IAuthor
	{
		Task<IEnumerable<AuthorReadViewModel>> GetAuthors();
		Task<AuthorReadViewModel> GetAuthorById(string id);
	}
}

