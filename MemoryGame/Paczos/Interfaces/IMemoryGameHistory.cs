using System;
using System.Collections.Generic;
using Paczos.Models;

namespace Paczos.Interfaces
{

    public interface IMemoryGameHistory
    {
        void RecordMove(int row, int column, ImageState previousState, ImageState newState);
        List<GameMove> GetHistory();
        void ClearHistory();
    }
}