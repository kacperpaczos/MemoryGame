using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos.Models
{
    internal class MemoryGameUsers
    {
        private List<MemoryGameUser> userList = new List<MemoryGameUser>();

        public void AddUser(MemoryGameUser user)
        {
            userList.Add(user);
        }

        public List<MemoryGameUser> GetAllUsers()
        {
            return userList;
        }
    }
}
