using FurnitureStore.API.DTOs.EmailDTO;

namespace FurnitureStore.API.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
