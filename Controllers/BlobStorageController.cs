using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace StorageAccount.Controllers;

[ApiController]
[Route("[controller]")]
public class BlobsController:ControllerBase
{
    [HttpPost("AddBlob")]
    public async Task<string>AddBlob (string blobName)
    {
        await StorageAccount.Repository.BlobStorage.CreateBlob(blobName);
        return null;
    }
    [HttpDelete("DeleteBlob")]
    public async Task<string> DeleteBlob(string blobName)
    {
        await StorageAccount.Repository.BlobStorage.DeleteBlob(blobName);
        return null;
    }
    [HttpDelete("DeleteBlobContent")]
    public async Task<string> DeleteBlobContent(string blobName,string file)
    {
        await StorageAccount.Repository.BlobStorage.DeleteBlobContent(blobName,file);
        return null;
    }
    [HttpPut("UpdateBlobContent")]
    public async Task<BlobProperties> UpdateBlobContent(string blobName,string file)
    {
        await StorageAccount.Repository.BlobStorage.UpdateBlobContent(blobName,file);
        return null;
    }
    [HttpGet("GetBlobContent")]
    public async Task<BlobProperties> GetBlobContent(string blobName,string file)
    {
        var data=await StorageAccount.Repository.BlobStorage.getBlobContent(blobName,file);
        return data;
    }
    [HttpGet("GetBlob")]
    public async Task<List<string>> GetBlob(string blobName,string file)
    {
        var data=await StorageAccount.Repository.BlobStorage.GetBlob(blobName,file);
        return data;
    }
    [HttpGet("DownloadBlobContent")]
    public async Task<BlobProperties> DownloadBlob(string blobName,string file)
    {
        var data=await StorageAccount.Repository.BlobStorage.DownloadBlob(blobName,file);
        return data;
    }
}
