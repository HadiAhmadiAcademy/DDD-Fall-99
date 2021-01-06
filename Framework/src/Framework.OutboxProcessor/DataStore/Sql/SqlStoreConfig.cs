namespace Framework.OutboxProcessor.DataStore.Sql
{
    public class SqlStoreConfig
    {
        public string TableName { get; set; }
        public int PullingInterval { get; set; }
    }
}