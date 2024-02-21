using Application.Identity;
using Application.Identity.Jwt;
using Common.Persistence;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountActions.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly ISender _sender;
        private readonly IRepository _repository;
        private readonly IJwtCommand _jwtHandler;
        private readonly IAuthRepository _authRepository;

        public LoginCommandHandler(ISender sender, IRepository Repository, IJwtCommand jwtHandler, IAuthRepository authRepository)
        {
            _sender = sender;
            _repository = Repository;
            _jwtHandler = jwtHandler;
            _authRepository = authRepository;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _authRepository.FindUser(request.Email, request.Password);

            if (user == null)
            {
                return "Login failed";
            }

            var token = _jwtHandler.GenerateToken(user);

            return token;
        }

    }
}
