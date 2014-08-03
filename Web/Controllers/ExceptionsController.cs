using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Core.DTOs;
using Core.Services;
using Web.Models;

namespace AzureLoggingApi.Controllers
{
  public class ExceptionsController : ApiController
  {
    private readonly ILoggingService _loggingService;

    public ExceptionsController(ILoggingService loggingService)
    {
      _loggingService = loggingService;
    }

    public IEnumerable<ExceptionModel> Get()
    {
      return _loggingService.GetExceptions().Select(Mapper.Map<CustomException, ExceptionModel>);
    }

    //POST: api/Logging
    public HttpResponseMessage Post([FromBody] CustomException customException)
    {
      _loggingService.LogError(customException);

      return Request.CreateResponse(HttpStatusCode.OK);
    }

  }
}