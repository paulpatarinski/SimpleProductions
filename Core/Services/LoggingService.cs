using System;
using System.Collections.Generic;
using System.Linq;
using Core.DTOs;
using MongoDB.Driver;

namespace Core.Services
{
  public class LoggingService : ILoggingService
  {
    public LoggingService()
    {
      var connectionString = Environment.GetEnvironmentVariable("CUSTOMCONNSTR_MONGOLAB_URI");

      _connectionString = string.IsNullOrEmpty(connectionString)
        ? "mongodb://MongoLab-97:IhPr2iNlJrhG4TBpQ2XXddT.Wmncpqm3rLs7HOdYYIU-@ds050087.mongolab.com:50087/MongoLab-97"
        : connectionString;
    }

    private readonly string _connectionString; 

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
        
        return collection.FindAll().ToList<CustomException>();
      }
      catch (MongoConnectionException)
      {
        return new List<CustomException>();
      }
    }

    private MongoCollection<CustomException> GetExceptionsCollection()
    {
      var url = new MongoUrl(_connectionString);

      var client = new MongoClient(url);
      mongoServer = client.GetServer();
      var database = mongoServer.GetDatabase(dbName);
      var exceptionsCollection = database.GetCollection<CustomException>(collectionName);
      return exceptionsCollection;
    }

   
  }
}