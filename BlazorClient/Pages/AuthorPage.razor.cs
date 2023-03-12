using System;
using BlazorClient.Models;
using BlazorClient.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorClient.Pages
{
	public partial class AuthorPage
	{
        public IEnumerable<AuthorReadViewModel> Authors { get; set; }

        [Inject]
        public IAuthor AuthorService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Authors = (await AuthorService.GetAuthors()).ToList();
        }
    }
}

