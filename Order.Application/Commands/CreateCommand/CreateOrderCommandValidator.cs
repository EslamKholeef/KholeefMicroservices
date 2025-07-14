using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Commands.CreateCommand
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty()
                .WithMessage("UserId is required.");

            RuleFor(command => command.Items)
                .NotEmpty()
                .WithMessage("Order must contain at least one item.")
                .Must(items => items != null && items.Count > 0)
                .WithMessage("Order must contain at least one item.");

            RuleForEach(command => command.Items)
                .SetValidator(new OrderItemRequestValidator());
        }
    }

    public class OrderItemRequestValidator : AbstractValidator<OrderItemRequest>
    {
        public OrderItemRequestValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty()
                .WithMessage("ProductId is required for each item.");

            RuleFor(item => item.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0 for each item.");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0)
                .WithMessage("UnitPrice must be greater than 0 for each item.");
        }
    }
}
