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

        public RegisterCommandHandler(ISender sender, IRepository Repository, IJwtCommand jwtHandler)
        {
            _sender = sender;
            _repository = Repository;
            _jwtHandler = jwtHandler;
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

             _repository.Add(newUser);
            await _repository.SaveChangesAsync();

            var token = _jwtHandler.GenerateToken(newUser);

            return token;
        }
    }


}