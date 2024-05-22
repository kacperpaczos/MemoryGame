using Paczos.Interfaces;
using Paczos.Models;
using System.Collections.Generic;
using System.Windows.Forms;

public class MemoryGameHistory : IMemoryGameHistory
{
    private List<GameMove> moves;
    private char currentMoveLabel = 'A';

    public MemoryGameHistory()
    {
        moves = new List<GameMove>();
    }

    public void RecordMove(int row, int column, Paczos.Interfaces.ImageState previousState, Paczos.Interfaces.ImageState newState)
    {
        moves.Add(new GameMove(row, column, previousState, newState));
    }

    public List<GameMove> GetHistory()
    {
        return new List<GameMove>(moves);
    }

    public void ClearHistory()
    {
        moves.Clear();
        currentMoveLabel = 'A'; // Resetowanie etykiety ruchu
    }

    public void DrawMoves(ListView listView)
    {
        listView.Items.Clear();
        foreach (var move in moves)
        {
            string moveDescription = $"{currentMoveLabel}: Rząd {move.Row}, Kolumna {move.Column}, {move.PreviousState} -> {move.NewState}";
            listView.Items.Add(moveDescription);
            if (currentMoveLabel < 'Z') currentMoveLabel++;
        }
    }
}