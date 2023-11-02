//using Application.Identity.Jwt;
//using Common.Persistence;
//using Domain.Enums;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.AccountActions.Commands
//{
//    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
//    {
//        private readonly ISender _sender;
//        private readonly IRepository _repository;
//        private readonly IJwtCommand _jwtHandler;

//        public LoginCommandHandler(ISender sender, IRepository Repository, IJwtCommand jwtHandler)
//        {
//            _sender = sender;
//            _repository = Repository;
//            _jwtHandler = jwtHandler;
//        }

//        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
//        {
//            var user = await _repository.Find(request.Email, request.Password);

//            if (user == null)
//            {
//                return "Login failed";
//            }

//            var token = _jwtHandler.GenerateToken(user);

//            return token;
//        }
//    }
//}
