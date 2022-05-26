using LiteDB;
using Microsoft.EntityFrameworkCore;

namespace CryptoServer.DBContexts;

public class FilesDb : DbContext
{
    private readonly string _connectionString;
    
    public FilesDb(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task SaveFileForChat(string id, string filename, Stream file)
    {
        using var db = new LiteDatabase(_connectionString);

        await Task.Run(() => db.FileStorage.Upload(id, filename, file));
    }

    public async Task<LiteFileInfo<string>> GetFileForChat(string id)
    {
        using var db = new LiteDatabase(_connectionString);
        
        var stream = new MemoryStream();
        
        return await Task.Run(() => db.FileStorage.Download(id,stream));
    }
}