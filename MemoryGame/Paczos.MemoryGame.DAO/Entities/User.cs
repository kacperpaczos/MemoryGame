using System;
using System.ComponentModel.DataAnnotations;
using Paczos.MemoryGame.INTERFACES.Entities;

namespace Paczos.MemoryGame.DAO.Entities
{
    public class User : IUser
    {
        [Key]
        public int Id { get; set; }
        public string Nick { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
