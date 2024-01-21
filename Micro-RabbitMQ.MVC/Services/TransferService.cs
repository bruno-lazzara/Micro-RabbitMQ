using Micro_RabbitMQ.MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace Micro_RabbitMQ.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;
        public TransferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Transfer(TransferDTO transferDto)
        {
            var uri = "https://localhost:7177/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
