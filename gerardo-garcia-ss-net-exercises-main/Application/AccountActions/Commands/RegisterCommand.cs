using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CQRS;
using MediatR;

namespace Application.AccountActions.Commands
{
    public class RegisterCommand : IRequest<string>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}