using FurnitureStore.API.DBContext;
using FurnitureStore.API.DTOs.UserDTOs;
using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.API.Services.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FurnitureStoreContext _context;
        public UsersRepository(FurnitureStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }


        public User? GetUser(int idUser)
        {
            return _context.Users.FirstOrDefault(u => u.Id == idUser);
        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public bool EmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool UserNameExists(string name)
        {
            return _context.Users.Any(u => u.UserName == name);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public User? ValidateCredentials(UserLoginDto authParams)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == authParams.Email);

            return user;
        }

    }
}