using FurnitureStore.API.DTOs.UserDTOs;
using FurnitureStore.API.Entities;

namespace FurnitureStore.API.Services.Interfaces
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetUsers();
        public IEnumerable<User> GetUsersWithoutOrders();
        public User? GetUser(int idUser);
        void AddUser(User newUser);
        void DeleteUser(User user);
        bool EmailExists(string email);
        bool UserNameExists(string name);
        bool SaveChanges();
        User? ValidateCredentials(UserLoginDto authParams);
        //User? GetUserWithoutOrder(int idUser);
        void Update(User user);
    }
}
