using AutoMapper;
using BookOperations.UpdateBook;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;
using WebApi.GetBookDetail.GetBookDetail;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;



        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks([FromQuery] string? ShortType) //Get işlemi
        {
            try
            {
                GetBooksQuery query = new GetBooksQuery(_context,_mapper);
                var result = query.Handle(ShortType);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) //from route id ile get işlemi
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId = id;
                result = query.Handle();

            }
            catch (Exception ex)
            {
                    return BadRequest(ex.Message);
            }
                return Ok(result);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Created("201", newBook); // 201 kodu

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook) //İd ye göre değişitirlen kısımları Update 
        {

            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.BookId = id;  
                command.Model= updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex);
            }
            return Ok(updatedBook); //200

        }
        [HttpPatch("{id}")]
        public IActionResult UpdateBookPatch(int id, [FromBody] JsonPatchDocument<Book> updatedBookPatch)
        {
            try
            {
                
                var book = _context.Books.SingleOrDefault(x => x.Id == id);
                if (book == null)
                { return NotFound(); }
                updatedBookPatch.ApplyTo(book, ModelState);
                _context.SaveChanges();

                return Ok(book);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }



        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
             DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId= id;
                command.Handle();
                return Ok(); //200 durum kodu
            }
            catch (Exception ex)
            {

                return StatusCode(400,ex.Message);

            }

        }
    }
}