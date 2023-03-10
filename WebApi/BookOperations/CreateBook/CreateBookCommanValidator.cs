using FluentValidation;

namespace WebApi.BookOperations.CreateBook

{
    public class CreateBookCommanValidator:AbstractValidator<CreateBookCommand >
    {
        public CreateBookCommanValidator() 
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);

        }
    }
}
