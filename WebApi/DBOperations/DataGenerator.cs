
using Microsoft.EntityFrameworkCore;
namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())//hiç veri yoksa dön
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        
                        Title = "Lean Startup",
                        GenreId = 1, //kişisel gelişim personal growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                new Book
                {
                    
                    Title = "Herland",
                    GenreId = 2,
                    PageCount = 200,
                    PublishDate = new DateTime(2012, 08, 08)
                },
                new Book
                {
                    
                    Title = "Dune",
                    GenreId = 2,//science fiction
                    PageCount = 200,
                    PublishDate = new DateTime(2023, 12, 12)
                }
                );
                context.SaveChanges();

            }
        }
    }
}