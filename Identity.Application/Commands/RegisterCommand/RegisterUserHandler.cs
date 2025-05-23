using AutoMapper;
using FluentValidation;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Commands.RegisterCommand
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IValidator<RegisterUserCommand> _validator;

        public RegisterUserHandler(UserManager<AppUser> userManager, IMapper mapper, IValidator<RegisterUserCommand> validator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);
            return result.Succeeded;
        }
    }
}
