public interface IMemoryGameHistory
{
    void RecordMove(int row, int column, ImageState previousState, ImageState newState);
    List<GameMove> GetHistory();
    void ClearHistory();
}