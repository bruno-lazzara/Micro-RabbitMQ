using Micro_RabbitMQ.MVC.Models;
using Micro_RabbitMQ.MVC.Models.DTOs;
using Micro_RabbitMQ.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Micro_RabbitMQ.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransferService _transferService;
        public HomeController(ILogger<HomeController> logger, ITransferService transferService)
        {
            _logger = logger;
            _transferService = transferService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            //TODO - use AutoMapper
            TransferDTO transferDto = new()
            {
                FromAccount = model.FromAccount,
                ToAccount = model.ToAccount,
                TransferAmount = model.TransferAmount
            };

            await _transferService.Transfer(transferDto);

            return View("Index");
        }
    }
}
