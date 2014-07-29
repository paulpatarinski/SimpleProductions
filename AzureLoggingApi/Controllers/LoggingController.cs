using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Services;

namespace AzureLoggingApi.Controllers
{
    public class LoggingController : ApiController, IDisposable
    {
      private readonly ILoggingService _loggingService;
      private bool disposed =false;

      public LoggingController() : this(new LoggingService())
      {
        
      }

      public LoggingController(ILoggingService loggingService)
      {
        _loggingService = loggingService;
      }

      public IEnumerable<CustomException> Get()
      {
        return _loggingService.GetExceptions();
      }

      // POST: api/Logging
        public void Post([FromBody]string value)
        {
          _loggingService.LogError(new CustomException
          {
            ExceptionMessage = "Test error message"
          });
        }

        new protected void Dispose()
        {
          this.Dispose(true);
          GC.SuppressFinalize(this);
        }

        new protected virtual void Dispose(bool disposing)
        {
          if (!this.disposed)
          {
            if (disposing)
            {
              this._loggingService.Dispose();
            }
          }

          this.disposed = true;
        }
    }
}
