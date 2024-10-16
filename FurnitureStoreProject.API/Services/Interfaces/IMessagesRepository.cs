using FurnitureStoreProject.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreProject.API.Services.Interfaces
{
    public interface IMessagesRepository
    {
        void AddMessage(Message message);
        IEnumerable<Message> GetMessagesByUserId(int userId);
        IEnumerable<Message> GetMessages();
        bool MessageExists(int id);
        void SaveChanges();
        IEnumerable<Message> GetUnreadMessages(int userId);
    }
}
