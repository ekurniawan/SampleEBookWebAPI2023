using System;
using System.Net.Http.Json;
using BlazorClient.Models;

namespace BlazorClient.Services
{
	public class AuthorService : IAuthor
	{
        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public async Task<AuthorReadViewModel> GetAuthorById(string id)
        {
            return await _httpClient.GetFromJsonAsync<AuthorReadViewModel>($"api/Authors/{id}");
        }

        public async Task<IEnumerable<AuthorReadViewModel>> GetAuthors()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<AuthorReadViewModel>>($"api/Authors");
        }
    }
}

