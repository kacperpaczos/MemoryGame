using Paczos.Interfaces;
using System;

namespace Paczos.Models
{
public class MemoryGameBoard : IMemoryGameBoard
{
    private int rows;
    private int columns;
    private ImageState[,] boardStates;
    private MemoryGameHistory history;

    public MemoryGameBoard(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        boardStates = new ImageState[rows, columns];
        history = new MemoryGameHistory();
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                boardStates[i, j] = ImageState.Hidden;
            }
        }
    }

    public Paczos.Interfaces.ImageState GetState(int row, int column)
    {
        if (row < 0 || column < 0 || row >= rows || column >= columns)
        {
            throw new IndexOutOfRangeException("Indeksy przekraczają dopuszczalny zakres.");
        }
        return (Paczos.Interfaces.ImageState)boardStates[row, column];
    }

    public void SetState(int row, int column, Paczos.Interfaces.ImageState state)
    {
        if (row < 0 || column < 0 || row >= rows || column >= columns)
        {
            throw new IndexOutOfRangeException("Indeksy przekraczają dopuszczalny zakres.");
        }
        Paczos.Interfaces.ImageState previousState = (Paczos.Interfaces.ImageState)boardStates[row, column];
        boardStates[row, column] = (Paczos.Interfaces.ImageState)state; // Rzutowanie, jeśli jest bezpieczne
        history.RecordMove(row, column, previousState, state);
    }

    public void ResetBoard()
    {
        InitializeBoard();
    }
}
}