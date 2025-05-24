using Identity.Application.DTOs;
using MediatR;

namespace Identity.Application.Commands.LoginCommand
{
    public class LoginUserCommand:IRequest<LoginResponseDto>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
