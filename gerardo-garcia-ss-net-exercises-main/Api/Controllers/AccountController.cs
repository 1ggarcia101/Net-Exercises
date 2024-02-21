using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.AccountActions.Commands;
using Api;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;
using Domain.Entities;
using Persistence;
using Common.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Application.Identity;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IAuthRepository _accountRepository;

        public AccountController(ISender sender, IAuthRepository accountRepository)
        {
            _sender = sender;
            _accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterCommand command)
        {
            var token = await _sender.Send(command);
            return Ok(new { Success = true, Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginCommand command)
        {
            var token = await _sender.Send(command);
            return Ok(new { Success = true, Token = token });
        }
    }

}