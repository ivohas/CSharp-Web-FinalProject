﻿using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using BookFindingAndRatingSystem.Web.ViewModels.Book;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AllAutorViewModel>> GetAllAutorsAsync();

        Task<IEnumerable<AllBookViewModel>> GetAllAutorsBookAsync(string id);

        Task<AllAutorViewModel?> GetAutorByIdAsync(string id);
        Task CreateNewAuthorAsync(AuthorViewModel model);
        Task<AuthorViewModel> GetAuthorForEditByIdAsync(int id);
        Task EditAuthorAsync(AuthorViewModel model);
    }
}
