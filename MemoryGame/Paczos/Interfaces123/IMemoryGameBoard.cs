public interface IMemoryGameBoard
{
    ImageState GetState(int row, int column);
    void SetState(int row, int column, ImageState state);
    void ResetBoard();
}