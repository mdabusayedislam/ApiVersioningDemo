using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Controllers.v2
{

    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = Data.Books.Select(x => x.Title);
            return Ok(books);
        }
    }
}
