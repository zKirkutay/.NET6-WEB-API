using CustomerOrder.Core.DTOs;
using FluentValidation;

namespace CustomerOrder.Service.Validations
{
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {
        public OrderDTOValidator()
        {
            RuleFor(p => p.OrderDate).NotEmpty();
            RuleFor(x => x.OrderNumber).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.CustomerId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
