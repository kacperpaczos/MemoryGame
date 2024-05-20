public class MemoryGameHistory : IMemoryGameHistory
{
    private List<GameMove> moves;

    public MemoryGameHistory()
    {
        moves = new List<GameMove>();
    }

    public void RecordMove(int row, int column, ImageState previousState, ImageState newState)
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
    }
}