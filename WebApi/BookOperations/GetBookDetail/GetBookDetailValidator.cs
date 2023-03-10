using FluentValidation;
using System.Data;
using WebApi.GetBookDetail.GetBookDetail;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailValidator:AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailValidator() 
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
