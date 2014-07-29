using System.Collections.Generic;

namespace Core.Services
{
  public interface ILoggingService
  {
    void LogError(CustomException exception);
    void Dispose();
    IEnumerable<CustomException> GetExceptions();
  }
}