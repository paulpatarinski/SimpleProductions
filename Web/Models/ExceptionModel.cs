using System;

namespace Web.Models
{
  public class ExceptionModel
  {
    public string Message { get; set; }
    public string MethodName { get; set; }
    public string ExceptionDate { get; set; }
    public string AppVersion { get; set; }
  }
}