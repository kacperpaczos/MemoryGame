using Paczos.MemoryGame.DAO.Entities;
using Paczos.MemoryGame.INTERFACES.DO;
using Paczos.MemoryGame.INTERFACES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos.MemoryGame.DAO.DO
{
    public class UserRepository : IUserRepository
    {
        private readonly DAOContext _context;

        public UserRepository(DAOContext context)
        {
            _context = context;
        }

        public void TestUsers()
        {
            Create("TestUser1", "Adam", "Nowak");
            Create("TestUser2", "Ewa", "Kowalska");
            Create("TestUser3", "Marek", "Wiśniewski");
        }

        public IUser Create(IUser user)
        {
            var newUser = user as User;
            if (newUser == null)
            {
                throw new ArgumentException("Invalid user type");
            }

            newUser.Id = _context.Users.Any() ? _context.Users.Max(u => u.Id) + 1 : 1; // Nadanie unikatowego Id
            newUser.CreationDate = DateTime.Now; // Nadanie daty utworzenia

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public IUser Create(string nick = null, string firstName = null, string lastName = null, DateTime? creationDate = null)
        {
            var newUser = new User
            {
                Id = _context.Users.Any() ? _context.Users.Max(u => u.Id) + 1 : 1, // Nadanie unikatowego Id
                Nick = nick ?? "None",
                FirstName = firstName ?? "None",
                LastName = lastName ?? "None",
                CreationDate = creationDate ?? DateTime.Now // Nadanie daty utworzenia
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public IUser Read(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId) as IUser;
        }

        public List<IUser> ReadAll()
        {
            return _context.Users.ToList().Cast<IUser>().ToList();
        }

        public IUser Update(IUser user)
        {
            // Rzutowanie interfejsu na konkretny typ, aby umożliwić aktualizację.
            var userToUpdate = user as User;
            if (userToUpdate == null)
            {
                return null; // lub obsłuż błąd, jeśli rzutowanie nie powiedzie się
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Id == userToUpdate.Id);
            if (existingUser != null)
            {
                existingUser.Nick = userToUpdate.Nick;
                existingUser.FirstName = userToUpdate.FirstName;
                existingUser.LastName = userToUpdate.LastName;
                existingUser.CreationDate = userToUpdate.CreationDate;
                _context.SaveChanges();
                return existingUser as IUser; // Jawne rzutowanie na IUser
            }
            return null;
        }

        public bool Delete(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}