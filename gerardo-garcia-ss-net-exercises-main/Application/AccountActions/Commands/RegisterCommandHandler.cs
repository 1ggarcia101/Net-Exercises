using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CQRS;
using Common.Exceptions;
using Common.Persistence;
using Application.Identity;
using Application.Identity.Jwt;

namespace Application.AccountActions.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly ISender _sender;
        private readonly IRepository _repository;
        private readonly IJwtCommand _jwtHandler;
        private readonly IAuthRepository _authRepository;

        public RegisterCommandHandler(ISender sender, IRepository Repository, IJwtCommand jwtHandler, IAuthRepository authRepository)
        {
            _sender = sender;
            _repository = Repository;
            _jwtHandler = jwtHandler;
            _authRepository = authRepository;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Create a new user
            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                UserType = UserType.Registered,
            };

            await _authRepository.Add(newUser);
            await _authRepository.SaveChangesAsync();

            var token = _jwtHandler.GenerateToken(newUser);

            return token;
        }
    }


}