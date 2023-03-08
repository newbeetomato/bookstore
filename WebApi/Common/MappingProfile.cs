using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.GetBookDetail.GetBookDetail;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    // kalıtımlaartık automapper tarafından bu bir config dosyası olarak görülcek
    {
        //biraz karışık gelicek ama modelleri başka bir modele dönüştürmeye yarıyor yada
        //başka bir model için a modeli gbi çalış demek gibi birşey  
        public MappingProfile() 
        {
            CreateMap<CreateBookModel, Book>();
            //sol source sağ taraf target 
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            // Formember yeni bişi üreticek sol taraf yeni bişi sağ taraf yeni bişineyden üreteceiği
            
        
        }
    }
}
