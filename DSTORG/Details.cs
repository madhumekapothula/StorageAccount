using Azure.Data.Tables;

namespace StorageAccount.DSTORG
{
    public class Details:ITableEntity
    {
        public string Id{get;set;}
        public string Name{get;set;}
        public string Department{get;set;}
        public string PartitionKey{get;set;}
        public string RowKey{get;set;}
        public DateTimeOffset? Timestamp {get;set;}
        public Azure.ETag ETag{get;set;}
    }
}