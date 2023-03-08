using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.GetBookDetail.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }


        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
    {
        var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
        if (book == null)
        {
            throw new InvalidOperationException("Kitap Bulunamadı!");
        }
        BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

        //vm.Title=book.Title;
        //vm.PageCount=book.PageCount;
        //vm.PublishDate=book.PublishDate.ToString("dd/MM/yyyy");
        //vm.Genre=((GenreEnum)book.GenreId).ToString();
        return vm;
    }
    }
     public class BookDetailViewModel 
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}