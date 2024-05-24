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

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();

        public int WinCount => Games?.Count(g => g.EndTime != null) ?? 0;
        public TimeSpan AverageGameTime => Games?.Where(g => g.EndTime != null).Any() == true 
            ? TimeSpan.FromTicks((long)Games.Where(g => g.EndTime != null).Average(g => g.Duration.Ticks)) 
            : TimeSpan.Zero;
    }
}
