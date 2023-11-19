using BookList_Project.Entities;
using BookList_Project.Models;
using BookList_Project.Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList_Project.Services
{
    internal class BookService
    {
        private readonly AuthorRepo _authorRepo;
        private readonly GenreRepo _genreRepo;
        private readonly PublisherRepo _publisherRepo;
        private readonly BookRepo _bookRepo;

        public BookService(AuthorRepo authorRepo, GenreRepo genreRepo, PublisherRepo publisherRepo, BookRepo bookRepo)
        {
            _authorRepo = authorRepo;
            _genreRepo = genreRepo;
            _publisherRepo = publisherRepo;
            _bookRepo = bookRepo;
        }

        public async Task<bool> CreateBookAsync(BookRegistrationForm form)
        {
            try
            {
                if (!await _bookRepo.ExistsAsync(x => x.Title == form.Title && x.Author.FirstName == form.Author.FirstName && x.Author.LastName == form.Author.LastName))
                {
                    var authorEntity = await _authorRepo.GetAsync(x => x.FirstName == form.Author.FirstName && x.LastName == form.Author.LastName);
                    authorEntity ??= await _authorRepo.CreateAsync(new AuthorEntity { FirstName = form.Author.FirstName, LastName = form.Author.LastName });

                    var genreEntity = await _genreRepo.GetAsync(x => x.Name == form.Genre.Name);
                    genreEntity ??= await _genreRepo.CreateAsync(new GenreEntity { Name = form.Genre.Name, });

                    var publisherEntity = await _publisherRepo.GetAsync(x => x.Name == form.Publisher.Name);
                    publisherEntity ??= await _publisherRepo.CreateAsync(new PublisherEntity { Name = form.Publisher.Name, });

                    BookEntity bookEntity = await _bookRepo.CreateAsync(new BookEntity { Title = form.Title, Description = form.Description, PublishedYear = form.PublishedYear, AuthorId = authorEntity.Id, GenreId = genreEntity.Id, PublisherId = publisherEntity.Id });
                    if (bookEntity != null)
                        return true;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            try
            {
                var books = await _bookRepo.GetAllAsync();
                return books;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<BookEntity> GetBookAsync(string title)
        {
            try
            {
                var book = await _bookRepo.GetAsync(x => x.Title == title);
                return book;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<BookEntity> UpdateBookAsync(BookEntity book)
        {
            try
            {
                var existingBook = await _bookRepo.GetAsync(x => x.Title == book.Title);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Description = book.Description;
                    existingBook.PublishedYear = book.PublishedYear;
                    existingBook.Author.FirstName = book.Author.FirstName;
                    existingBook.Author.LastName = book.Author.LastName;
                    existingBook.Publisher.Name = book.Publisher.Name;
                    existingBook.Genre.Name = book.Genre.Name;

                    await _bookRepo.UpdateAsync(existingBook);
                    return existingBook;
                }
                else
                {
                    return null!;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null!; }
        }

        public async Task<bool> DeleteBookAsync(string title)
        {
            try
            {
                var deleteBook = await _bookRepo.GetAsync(book => book.Title == title);

                if (deleteBook != null)
                {
                    return await _bookRepo.DeleteAsync(book => book.Title == title);
                }
                else
                {
                    Debug.WriteLine($"Book with title '{title} was not found for deletion.");
                    return false;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

    }
}

