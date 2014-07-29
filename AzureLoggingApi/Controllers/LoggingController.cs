using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.DTOs;
using Core.Services;

namespace AzureLoggingApi.Controllers
{
    public class LoggingController : ApiController
    {
      private readonly ILoggingService _loggingService;
      private bool disposed =false;

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

    }
}
