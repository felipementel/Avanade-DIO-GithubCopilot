using Asp.Versioning;
using Avanade.DIO.BookStore.Application.Dtos.BookPublisher;
using Avanade.DIO.BookStore.Application.Interfaces.BookPublisher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1", Deprecated = false)]
    [ApiExplorerSettings(GroupName = "v1")]
    public class BookPublisherController : ControllerBase
    {
        private readonly IBookPublisherAppService _bookPublisherAppService;

        public BookPublisherController(
            IBookPublisherAppService BookPublisherAppService)
        {
            _bookPublisherAppService = BookPublisherAppService;
        }

        [HttpGet("")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookPublisherDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var item = await _bookPublisherAppService.ListBookPublisherAsync();

            if (!item.Any())
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookPublisherDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _bookPublisherAppService.GetBookPublisherAsync(id);

            if (item == null)
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpPost("")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookPublisherDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BookPublisher(
            [FromBody] BookPublisherDto BookPublisherDto)
        {
            var item = await _bookPublisherAppService.AddBookPublisherAsync(BookPublisherDto);

            if (item.Errors.Any())
            {
                return UnprocessableEntity(string.Join('\n', item.Errors));
            }

            return CreatedAtAction(nameof(GetById), new
            {
                apiVersion = new ApiVersion(
                        1,
                        0),
                id = item.Identificador
            }, item);
        }

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookPublisherDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BookPublisher(
            string id,
            [FromBody] BookPublisherDto BookPublisherDto)
        {
            var item = await _bookPublisherAppService.UpdateBookPublisherAsync(id, BookPublisherDto);

            if (item.Errors.Any())
            {
                return UnprocessableEntity(string.Join('\n', item.Errors));
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(BookPublisherDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BookPublisher(string id)
        {
            var item = await _bookPublisherAppService.DeleteBookPublisherAsync(id);

            if (!item)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}