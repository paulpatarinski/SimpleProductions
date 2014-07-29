using System.Collections.Generic;
using Core.DTOs;

namespace Core.Services
{
  public interface ILoggingService
  {
    void LogError(CustomException exception);
    IEnumerable<CustomException> GetExceptions();
  }
}