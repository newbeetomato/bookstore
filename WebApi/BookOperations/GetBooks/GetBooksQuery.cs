
using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle(string? ShortType) //bundan dönecekşey list booksviewmodel
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList();

            if (ShortType is not null)
            {
                if (ShortType == "a-z")//A dan Z ye listeleme işlemi
                {
                    bookList = _dbContext.Books.OrderBy(x => x.Title).ToList();
                }
                if (ShortType == "z-a")//Z den A ye listeleme işlemi
                {
                    bookList = _dbContext.Books.OrderByDescending(x => x.Title).ToList();
                }
            }
            //book Listi göndermek istemiyorum bazı güvenlik cart curt neyse
            //vm adında bi model oluşturduk mapperla booklist içindekileri ona eşitldik
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);

            return vm;
        }

    }
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }

}