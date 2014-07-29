using MongoDB.Bson.Serialization.Attributes;

namespace Core.DTOs
{
 
  [BsonIgnoreExtraElements]
  public class CustomException
  {
    public string ExceptionMessage { get; set; }
  }
}