namespace Framework.OutboxProcessor.DataStore
{
    public interface ICursorManager
    {
        long GetCurrentPosition();
        void Move(long position);
    }
}