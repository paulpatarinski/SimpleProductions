using System;
using MongoDB.Driver;

namespace Core.Services
{
  public class LoggingService : IDisposable, ILoggingService
  {
    public LoggingService()
    {
      
    }

    private string connectionString = System.Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGOLAB_URI");
    private MongoServer mongoServer = null;
    private bool disposed = false;
    private string dbName = "MongoLab-97";
    private string collectionName = "Exceptions";

    public void LogError(CustomException exception)
    {
      var collection = GetExceptionsCollectionForEdit();
      collection.Insert(exception);
    }

    private MongoCollection<CustomException> GetExceptionsCollectionForEdit()
    {
      var url = new MongoUrl(connectionString);

      MongoClient client = new MongoClient(url);
      mongoServer = client.GetServer();
      MongoDatabase database = mongoServer.GetDatabase(dbName);
      var exceptionsCollection = database.GetCollection<CustomException>(collectionName);
      return exceptionsCollection;
    }

    public void Dispose()
    {
      this.Dispose();
      GC.SuppressFinalize(this);
    }
  }

  public class CustomException
  {
    public string ExceptionMessage { get; set; }
  }
}