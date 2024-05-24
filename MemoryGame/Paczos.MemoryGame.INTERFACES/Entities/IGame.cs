using System;
using System.Collections.Generic;

namespace Paczos.MemoryGame.INTERFACES.Entities
{
    public interface IGame
    {
        int Id { get; set; }
        int UserId { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        TimeSpan Duration { get; }
    }
}
