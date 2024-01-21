using Micro_RabbitMQ.MVC.Models.DTOs;

namespace Micro_RabbitMQ.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDTO transferDto);
    }
}
