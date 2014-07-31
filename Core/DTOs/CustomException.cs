using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.DTOs
{
 
  [BsonIgnoreExtraElements]
  public class CustomException
  {
    public string Message { get; set; }
    public string MethodName { get; set; }
    public DateTime ExceptionDate { get; set; }
  }
}