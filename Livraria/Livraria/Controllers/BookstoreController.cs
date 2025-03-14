using Livraria.Communication.Request;
using Livraria.Entities.books;
using Livraria.Entities.GeneratorId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookstoreController : BaseController
{
    private static DictionaryOfBooks _dictionaryBooks = new DictionaryOfBooks();

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult CreateBook([FromBody] RequestBooksJson request)
    {

        var generateId = new GenerateId();

        var id = generateId.Generator();

        var dictionaryBooks = new DictionaryOfBooks();

        _dictionaryBooks.Shelf.Add(id, new RequestBooksJson
        {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Value = request.Value,
            Amount = request.Amount
        });

        return Ok(_dictionaryBooks.Shelf);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {   
        return Ok(_dictionaryBooks.Shelf);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] string id)
    {

        return Ok(_dictionaryBooks.Shelf[id]);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateBook([FromRoute] string id, [FromBody] RequestBooksJson request)
    {
        var dictionaryBooks = new DictionaryOfBooks();

        _dictionaryBooks.Shelf[id] = new RequestBooksJson
        {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Value = request.Value,
            Amount = request.Amount
        };

        return Ok(_dictionaryBooks.Shelf[id]);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteBook([FromRoute] string id)
    {
        var dictionaryBooks = new DictionaryOfBooks();

        _dictionaryBooks.Shelf.Remove(id);

        return Ok(_dictionaryBooks.Shelf);
    }
}
