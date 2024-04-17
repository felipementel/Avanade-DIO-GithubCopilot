/*
Essa classe é uma classe de serviço que implementa a interface IBookService.
Ela é responsável por realizar a lógica de negócio da aplicação,
como validações e chamadas de métodos de repositório.
Ela é injetada na BookAppService.
*/

using Avanade.DIO.BookStore.Domain.Aggregates.Book.Interfaces.Repositories;
using Avanade.DIO.BookStore.Domain.Aggregates.Book.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Domain.Aggregates.Book.Services
{
    public class BookService : IBookService
    {
        private readonly IValidator<Entities.Book> _validations;

        private readonly IBookRepository _bookRepository;

        public BookService(
            IValidator<Entities.Book> validations,
            IBookRepository BookRepository)
        {
            _validations = validations;
            _bookRepository = BookRepository;
        }

        public async Task<Entities.Book> AddBookAsync(Entities.Book book)
        {
            if (_validations == null)
                throw new ArgumentException($"Não foi informado o validador da classe {nameof(Book)}");

            var validated = await _validations.ValidateAsync(book, opt =>
            {
                opt.IncludeRuleSets("new");
            });

            if (!validated.IsValid)
            {
                book.Erros = validated.Errors.Select(x => x.ErrorMessage).ToList();
                return book;
            }

            return await _bookRepository.AddAsync(book);
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            var item = await _bookRepository.FindByIdAsync(id);

            if (item is null)
                return false;

            await _bookRepository.DeleteAsync(id);

            return true;
        }

        public async Task<Entities.Book> GetBookAsync(string id)
        {
            return await _bookRepository.FindByIdAsync(id);
        }

        public async Task<List<Entities.Book>> ListBookAsync()
        {
            return await _bookRepository.FindAllAsync();
        }

        public async Task<Entities.Book> UpdateBookAsync(string id, Entities.Book book)
        {
            var validated = await _validations.ValidateAsync(book, opt =>
            {
                opt.IncludeRuleSets("update");
            });

            if (!validated.IsValid)
            {
                book.Erros = validated.Errors.Select(x => x.ErrorMessage).ToList();
                return book;
            }

            var item = await _bookRepository.FindByIdAsync(id);

            if (item is not null)
            {
                var newItem = item with
                {
                    Title = book.Title,
                    Author = book.Author,
                    Active = book.Active,
                    LauchDate = book.LauchDate,
                    BookPublisher = book.BookPublisher,
                    Value = book.Value,

                    Erros = book.Erros
                };

                await _bookRepository.UpdateAsync(newItem);

                return newItem;
            }
            else
            {
                return book;
            }
        }
    }
}