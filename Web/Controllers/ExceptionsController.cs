using System.Collections.Generic;
using System.Web.Http;
using Core.DTOs;
using Core.Services;

namespace AzureLoggingApi.Controllers
{
  public class ExceptionsController : ApiController
  {
    private readonly ILoggingService _loggingService;

    public ExceptionsController(ILoggingService loggingService)
    {
      _loggingService = loggingService;
    }

    public IEnumerable<CustomException> Get()
    {
      return _loggingService.GetExceptions();
    }

    //POST: api/Logging
    public void Post([FromBody] CustomException customException)
    {
      _loggingService.LogError(customException);
    }

  }
}