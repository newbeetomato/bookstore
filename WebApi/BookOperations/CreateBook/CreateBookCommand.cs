using AutoMapper;
using WebApi.DBOperations;
namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get;set;}
        private readonly BookStoreDbContext _dbContext;
        /*BookStoreDbContext tipinde bir örnekleme değişkeni oluşturulduğunu belirtiyor.
        BookStoreDbContext, bir Entity Framework DbContext sınıfıdır ve veritabanı işlemlerini
        yönetmek için kullanılır. _dbContext, örnekleme sırasında bir DbContext örneğine 
        atandığından,bu örnekleme değişkeni kullanılarak BookStoreDbContext'teki verilerin 
        değiştirilmesi veya okunması için kullanılır.*/
        private readonly IMapper _mapper;


        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book != null)
            { throw new InvalidOperationException("Kitap zaten mevcut"); }
            book = _mapper.Map<Book>(Model); //aşşağısı yerine mapperla hallettik
            /*book=new Book();
            book.Title=Model.Title;
            book.PageCount=Model.PageCount;
            book.PublishDate=Model.PublishDate;
            book.GenreId=Model.GenreId;*/
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}