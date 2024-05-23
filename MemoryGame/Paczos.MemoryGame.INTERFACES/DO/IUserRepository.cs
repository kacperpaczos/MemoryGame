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
    }
}
