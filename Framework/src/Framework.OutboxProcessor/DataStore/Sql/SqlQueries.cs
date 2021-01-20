using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Framework.Persistence;

namespace Framework.OutboxProcessor.DataStore.Sql
{
    public static class SqlQueries
    {
        public static long GetOutboxCursorPosition(this IDbConnection connection, string tableName)
        {
            return connection.Query<long>($"SELECT Position from {tableName}").First();
        }
        public static void MovePosition(this IDbConnection connection, long position, string tableName)
        {
            connection.Execute($"UPDATE {tableName} SET Position={position}");
        }

        public static List<OutboxItem> GetOutboxItemsFromPosition(this IDbConnection connection, long position,
            string tableName)
        {
            return connection.Query<OutboxItem>($"SELECT * from {tableName} WHERE Id > {position}").ToList();
        }
    }
}