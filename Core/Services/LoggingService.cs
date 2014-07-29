using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Core.Services
{
  public class LoggingService : IDisposable, ILoggingService
  {
    private string connectionString = System.Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGOLAB_URI");
    private MongoServer mongoServer = null;
    private bool disposed = false;
    private string dbName = "MongoLab-97";
    private string collectionName = "Exceptions";

    public void LogError(CustomException exception)
    {
      var collection = GetExceptionsCollection();
      collection.Insert(exception);
    }


    public IEnumerable<CustomException> GetExceptions()
    {
      try
      {
        var collection = GetExceptionsCollection();
        return collection.FindAll();
      }
      catch (MongoConnectionException)
      {
        return new List<CustomException>();
      }
    }

    private MongoCollection<CustomException> GetExceptionsCollection()
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