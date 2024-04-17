using AutoMapper;
using Avanade.DIO.BookStore.Application.Dtos.BookPublisher;
using Avanade.DIO.BookStore.Application.Interfaces.BookPublisher;
using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Application.Services.BookPublisher
{
    public class BookPublisherAppService : IBookPublisherAppService
    {
        private readonly IMapper _mapper;

        private readonly IBookPublisherService _bookPublisherAppService;

        public BookPublisherAppService(IMapper mapper, IBookPublisherService bookPublisherService)
        {
            _mapper = mapper;
            _bookPublisherAppService = bookPublisherService;
        }

        public async Task<BookPublisherDto> AddBookPublisherAsync(BookPublisherDto BookPublisherDto)
        {
            var itemDomain = _mapper.Map<BookPublisherDto, Domain.Aggregates.BookPublisher.Entities.BookPublisher>(BookPublisherDto);

            var item = await _bookPublisherAppService.AddBookPublisherAsync(itemDomain);

            return _mapper.Map<Domain.Aggregates.BookPublisher.Entities.BookPublisher, BookPublisherDto>(item);
        }

        public async Task<bool> DeleteBookPublisherAsync(string id)
        {
            return await _bookPublisherAppService.DeleteBookPublisherAsync(id);
        }

        public async Task<BookPublisherDto> GetBookPublisherAsync(string id)
        {
            var item = await _bookPublisherAppService.GetBookPublisherAsync(id);

            return _mapper.Map<Domain.Aggregates.BookPublisher.Entities.BookPublisher, BookPublisherDto>(item);
        }

        public async Task<List<BookPublisherDto>> ListBookPublisherAsync()
        {
            var item = await _bookPublisherAppService.ListBookPublisherAsync();

            return _mapper.Map<List<Domain.Aggregates.BookPublisher.Entities.BookPublisher>, List<BookPublisherDto>>(item);
        }

        public async Task<BookPublisherDto> UpdateBookPublisherAsync(string id, BookPublisherDto BookPublisherDto)
        {
            var itemDomain = _mapper.Map<BookPublisherDto, Domain.Aggregates.BookPublisher.Entities.BookPublisher>(BookPublisherDto);

            var itemUpdated = await _bookPublisherAppService.UpdateBookPublisherAsync(id, itemDomain);

            return _mapper.Map<Domain.Aggregates.BookPublisher.Entities.BookPublisher, BookPublisherDto>(itemUpdated);
        }
    }
}