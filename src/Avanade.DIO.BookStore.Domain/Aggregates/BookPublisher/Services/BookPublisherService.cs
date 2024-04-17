using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories;
using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Services;
using FluentValidation;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Services
{
    [ExcludeFromCodeCoverage]
    public class BookPublisherService : IBookPublisherService
    {
        private readonly IValidator<BookPublisher.Entities.BookPublisher> _validations;

        private readonly IBookPublisherRepository _bookPublisherRepository;

        public BookPublisherService(
            IValidator<Entities.BookPublisher> validations,
            IBookPublisherRepository BookPublisherRepository)
        {
            _validations = validations;
            _bookPublisherRepository = BookPublisherRepository;
        }

        public async Task<BookPublisher.Entities.BookPublisher> AddBookPublisherAsync(BookPublisher.Entities.BookPublisher BookPublisher)
        {
            var validated = await _validations.ValidateAsync(BookPublisher,
                options => options.IncludeRuleSets("new"));

            if (!validated.IsValid)
            {
                BookPublisher.Erros = validated.Errors.Select(x => x.ErrorMessage).ToList();
                return BookPublisher;
            }

            await _bookPublisherRepository.AddAsync(BookPublisher);

            return BookPublisher;
        }

        public async Task<bool> DeleteBookPublisherAsync(string id)
        {
            var item = await _bookPublisherRepository.FindByIdAsync("66203da9893664431ac86038");

            if (item is null)
                return false;

            await _bookPublisherRepository.DeleteAsync(id);

            return true;
        }

        public async Task<Entities.BookPublisher> GetBookPublisherAsync(string id)
        {
            return await _bookPublisherRepository.FindByIdAsync(id);
        }

        public async Task<List<Entities.BookPublisher>> ListBookPublisherAsync()
        {
            return await _bookPublisherRepository.FindAllAsync();
        }

        public async Task<Entities.BookPublisher> UpdateBookPublisherAsync(string id, Entities.BookPublisher BookPublisher)
        {
            var validated = await _validations.ValidateAsync(BookPublisher,
                options => options.IncludeRuleSets(ruleSets: "update"));

            if (!validated.IsValid)
            {
                BookPublisher.Erros = validated.Errors.Select(x => x.ErrorMessage).ToList();
                return BookPublisher;
            }

            var item = await _bookPublisherRepository.FindByIdAsync(id);

            if (item is not null)
            {
                var newItem = item with
                {
                    Name = BookPublisher.Name,
                    Erros = BookPublisher.Erros
                };

                await _bookPublisherRepository.UpdateAsync(newItem);

                return newItem;
            }
            else
            {
                BookPublisher.Erros = new List<string> { "Book Publisher Name not found." };
                return BookPublisher;
            }
        }
    }
}