namespace Framework.OutboxProcessor.DataStore.Sql
{
    public class SqlStoreConfig
    {
        public string CursorTable { get; set; }
        public string OutboxTable { get; set; }
        public int PullingInterval { get; set; }
        public string ConnectionString { get; set; }
    }
}