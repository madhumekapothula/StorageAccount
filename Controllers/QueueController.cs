using Azure.Storage.Queues.Models;
using Microsoft.AspNetCore.Mvc;
using System;
namespace StorageAccount.Controllers;

[ApiController]
[Route("[controller]")]
public class QueueController:ControllerBase
{
    [HttpPost]
    [Route("AddQueue")]
    public async Task<string> AddQueue(string queueName)
    {
        await StorageAccount.Repository.Queue.CreateQueue(queueName);
        return null;
    }
    [HttpPut("InsertMessage")]
    public async Task<string> InsertMessage(string queueName,string msg)
    {
        await StorageAccount.Repository.Queue.InsertMessage(queueName,msg);
        return null;
    }
    [HttpGet("PeekMessage")]
    public async Task<PeekedMessage[]>PeekMessage(string queueName)
    {
        var data= await StorageAccount.Repository.Queue.PeekMessage(queueName);
        return data;
    }
    [HttpPut("UpdateMessage")]
    public async Task<string> UpdateMessage(string queueName,string msg)
    {
        await StorageAccount.Repository.Queue.UpdateMessage(queueName,msg);
        return null;
    }
    [HttpPut("DequeueMessage")]
    public async Task<string> DequeueMessage(string queueName)
    {
        await StorageAccount.Repository.Queue.DequeueMessage(queueName);
        return null;
    }
    [HttpDelete("DeleteQueue")]
    public async Task<string> DeleteQueue(string queueName)
    {
        await StorageAccount.Repository.Queue.DeleteQueue(queueName);
        return null;
    }
}

