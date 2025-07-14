using AutoMapper;
using FluentValidation;
using MassTransit;
using MediatR;
using Order.Application.DTOs;
using Order.Application.Events;
using Order.Domain.Entities;
using Order.Domain.Interfaces;

namespace Order.Application.Commands.CreateCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrderCommand> _validator;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IValidator<CreateOrderCommand> validator, IPublishEndpoint publishEndpoint)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _validator = validator;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<OrderModel>(request);
            order.TotalAmount = request.Items.Sum(i => i.Quantity * i.UnitPrice);
            var savedOrder = await _orderRepository.AddAsync(order);

            // Publish OrderPlacedEvent
            var orderPlacedEvent = new OrderPlacedEvent
            {
                OrderId = savedOrder.Id,
                UserId = savedOrder.UserId,
                Items = savedOrder.Items.Select(i => new OrderItemEvent
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };
            await _publishEndpoint.Publish(orderPlacedEvent);

            return _mapper.Map<OrderDto>(savedOrder);
        }
    }
}
