using AutoMapper;
using AutoMapper;
using System;

namespace WebApi.MapperOgrenme
{
    public class MapperOgrenme
    {
       
            static void Main(string[] args)
            {
                // Örnek kaynak nesnesi
                var customer = new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com"
                };

                // AutoMapper konfigürasyonu
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Customer, CustomerDto>()
                        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
                });

                // IMapper nesnesini oluştur
                IMapper mapper = config.CreateMapper();

                // Eşleme işlemini gerçekleştir
                var customerDto = mapper.Map<CustomerDto>(customer);

                // Sonucu ekrana yazdır
                Console.WriteLine("Id: " + customerDto.Id);
                Console.WriteLine("Full Name: " + customerDto.FullName);
                Console.WriteLine("Email: " + customerDto.Email);
            }
        }

        // Örnek kaynak sınıfı
        public class Customer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        // Örnek hedef sınıfı
        public class CustomerDto
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
        }
}


/*
    Bu kod örneği, bir Customer sınıfı ve bir CustomerDto sınıfı arasında 
    veri eşlemesi yapmaktadır. Customer sınıfı, bir müşterinin bilgilerini içermektedir
    ve CustomerDto sınıfı, müşterinin bazı bilgilerini içermektedir.

    MapperConfiguration nesnesi, AutoMapper'ın konfigürasyonunu yapmak için kullanılır. 

    Bu örnekte,CreateMap yöntemi, Customer sınıfının CustomerDto sınıfına nasıl eşleneceğini belirlemektedir.

    ForMember yöntemi, özelleştirilmiş bir ayar yapmak için kullanılmaktadır.

    opt.MapFrom yöntemi, FirstName ve LastName özelliklerini birleştirerek FullName özelliğine dönüştürmektedir.

    config.CreateMapper() yöntemi, IMapper nesnesini oluşturmak için kullanılır. 
    Bu nesne, veri eşlemesi işlemini gerçekleştirmek için kullanılır.

    mapper.Map<CustomerDto>(customer) yöntemi, Customer nesnesini CustomerDto nesnesine eşlemektedir.
    Sonuç olarak, bu kod örneği, AutoMapper kütüphanesi kullanılarak iki farklı sınıf arasında veri eşlemesi yapmanın nasıl yapıldığını göstermektedir.
 */