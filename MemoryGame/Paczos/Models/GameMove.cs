using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paczos.Models
{
    public class GameMove
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public Paczos.Interfaces.ImageState PreviousState { get; private set; }
        public Paczos.Interfaces.ImageState NewState { get; private set; }

        public GameMove(int row, int column, Paczos.Interfaces.ImageState previousState, Paczos.Interfaces.ImageState newState)
        {
            Row = row;
            Column = column;
            PreviousState = previousState;
            NewState = newState;
        }
    }
}
