using Microsoft.AspNetCore.Mvc;
using StorageAccount.Repository;
namespace StorageAccount.Controllers;

[ApiController]
[Route("[controller]")]
public class FileStorageController:ControllerBase
{
    [HttpPost("CreateFile")]
    public async Task CreateFile(string fileName)
    {
        await FileStorage.CreateFile(fileName);
    }
    [HttpPost("CreateDirectory")]
    public async Task CreateDirectory(string directoryName,string fileName)
    {
        await FileStorage.CreateDirectory(directoryName,fileName);
    }
    [HttpPut("UploadFile")]
    public async Task UploadFile(IFormFile file,string directoryName,string fileShareName)
    {
        await FileStorage.UploadFile(file,directoryName,fileShareName);
    }
    [HttpDelete("DeleteDirectory")]
    public async Task DeleteDirectory(string directoryName,string fileShareName)
    {
        await FileStorage.DeleteDirectory(directoryName,fileShareName);
    }
    [HttpDelete("DeleteFile")]
    public async Task DeleteFile(string directoryName,string fileShareName,string fileName)
    {
        await FileStorage.DeleteFile(directoryName,fileShareName,fileName);
    }
    [HttpDelete("DeleteFileFolder")]
    public async Task DeleteFileFolder(string fileName)
    {
        await StorageAccount.Repository.FileStorage.DeleteFileFolder(fileName);
    }
    [HttpGet("GetAllFiles")]
    public async Task<List<string>>GetAllFiles(string directoryName,string fileShareName)
    {
        var data=await FileStorage.GetAllFiles(directoryName,fileShareName);
        return data;
    }
    [HttpGet("DownloadFile")]
    public async Task DownloadFile(string directoryName,string fileShareName,string fileName)
    {
        await FileStorage.DownloadFile(directoryName,fileShareName,fileName);
    }
}
