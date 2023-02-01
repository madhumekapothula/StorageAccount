using System;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using StorageAccount.DSTORG;

namespace StorageAccount.Controllers;
[ApiController]
[Route("[controller]")]
public class TableController:ControllerBase
{
   [HttpPost("AddTable")]
   public async Task<string> AddTable(string tableName)
   {
     await StorageAccount.Repository.TableStorage.AddTable(tableName);
     return null;
   }
   [HttpPut("UpdateTable")]
   public async Task<Details> UpdateTable(Details employee,string tableName)
   {
      var data=await StorageAccount.Repository.TableStorage.UpdateTable(employee,tableName);
      return data;
   }
   [HttpGet("GetTableData")]
   public async Task<Details> GetTableData(string tableName,string partitionKey,string rowKey)
   {
     var data=await StorageAccount.Repository.TableStorage.GetTableData(tableName,partitionKey,rowKey);
     return data;
   }
   [HttpGet("GetTable")]
   public async Task<TableClient> GetTable(string tableName)
   {
     var data=await StorageAccount.Repository.TableStorage.GetTable(tableName);
     return data;
   }
   [HttpDelete("DeleteTableData")]
   public async Task DeleteTableData(string tableName,string partitionKey,string rowKey)
   {
     await StorageAccount.Repository.TableStorage.DeleteTableData(tableName,partitionKey,rowKey);
     return;
   }
   [HttpDelete("DeleteTable")]
   public async Task DeleteTable(string tableName)
   {
        await StorageAccount.Repository.TableStorage.DeleteTable(tableName);
        return;
   }
}