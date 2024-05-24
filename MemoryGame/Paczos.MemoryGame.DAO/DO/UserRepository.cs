using Paczos.MemoryGame.DAO.Entities;
using Paczos.MemoryGame.INTERFACES.DO;
using Paczos.MemoryGame.INTERFACES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            var user1 = Create("TestUser1", "Adam", "Nowak");
            var user2 = Create("TestUser2", "Ewa", "Kowalska");
            var user3 = Create("TestUser3", "Marek", "Wiśniewski");

            var currentTime = DateTime.Now;
            var game1 = new Game { UserId = user1.Id, StartTime = currentTime.AddSeconds(-30), EndTime = currentTime };
            var game2 = new Game { UserId = user2.Id, StartTime = currentTime.AddSeconds(-30), EndTime = currentTime };
            var game3 = new Game { UserId = user2.Id, StartTime = currentTime.AddSeconds(-30), EndTime = currentTime };
            var game4 = new Game { UserId = user2.Id, StartTime = currentTime.AddSeconds(-30), EndTime = currentTime };
            var game5 = new Game { UserId = user3.Id, StartTime = currentTime.AddSeconds(-30), EndTime = currentTime };

            _context.Games.AddRange(game1, game2, game3, game4, game5);
            _context.SaveChanges();
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
                existingUser.Games = userToUpdate.Games; // Aktualizacja listy gier
                //_context.SaveChanges();
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

        public IGame StartGame(int userId)
        {
            var game = new Game
            {
                UserId = userId,
                StartTime = DateTime.Now
            };
            _context.Games.Add(game);
            _context.SaveChanges();
            return game as IGame; // Rzutowanie na IGame
        }

        public IGame EndGame(int gameId)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                game.EndTime = DateTime.Now;
                _context.SaveChanges();
            }
            return game as IGame; // Rzutowanie na IGame
        }

        public List<IGame> GetUserGames(int userId)
        {
            return _context.Games.Where(g => g.UserId == userId).Cast<IGame>().ToList();
        }

        public IUser GetUserWithGames(int userId)
        {
            return _context.Users.Include(u => u.Games).FirstOrDefault(u => u.Id == userId) as IUser;
        }

        public void AddGameToUserStats(int userId, IGame game)
        {
            //throw new Exception("Użytko mnie. Parametry wywołania: userId = " + userId + ", game = " + game);
            var user = _context.Users.Include(u => u.Games).FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var gameEntity = game as Game;
                if (gameEntity == null)
                {
                    throw new ArgumentException("Invalid game type");
                }

                user.Games.Add(gameEntity);
                //_context.SaveChanges();

                //int gameCount = user.Games.Count;
                //throw new Exception($"User has {gameCount} games after adding the new game.");
            }
            else
            {
                throw new ArgumentException("User not found");
            }
        }


        public List<User> GetAllUsers()
        {
            // Implementacja metody, która zwraca listę wszystkich użytkowników
            return _context.Users.ToList();
        }
    }
}