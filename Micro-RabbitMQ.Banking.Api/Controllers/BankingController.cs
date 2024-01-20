using Micro_RabbitMQ.Banking.Application.Interfaces;
using Micro_RabbitMQ.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Micro_RabbitMQ.Banking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }
    }
}
