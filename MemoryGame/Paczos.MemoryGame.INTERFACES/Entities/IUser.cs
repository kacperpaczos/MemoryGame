using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos.MemoryGame.INTERFACES.Entities
{
    public interface IUser
    {
        int Id { get; set; }
        string Nick { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime CreationDate { get; set; }
    }
}
