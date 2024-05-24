using Paczos.MemoryGame.INTERFACES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paczos.MemoryGame.INTERFACES.DO
{
    public interface IUserRepository
    {
        IUser Create(IUser user);
        IUser Read(int userId);
        List<IUser> ReadAll();
        IUser Update(IUser user);
        bool Delete(int userId);
        IGame StartGame(int userId);
        IGame EndGame(int gameId);
        List<IGame> GetUserGames(int userId);
        IUser GetUserWithGames(int userId);
        void AddGameToUserStats(int userId, IGame game);
    }
}
