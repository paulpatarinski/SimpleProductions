using System.Linq;
using Core.Services;
using FluentAssertions;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture, Ignore("DB Call")]
    public class LoggingServiceTest
    {
      [Test]
      public void GetExceptionsByMethodName_ShouldReturnExceptions_ThatMatchTheMethodName()
      {
        var loggingService = new LoggingService();

        const string methodName = "AddCoverImage";
        var result = loggingService.GetExceptionsByMethodName(methodName).ToList();

        result.Should().NotBeEmpty();
        result.Count().Should().Be(80);
      }

      /// <summary>
      /// Use this method to delete exceptions you have already resolved
      /// </summary>
      [Test]
      public void DeleteByMethodName_ShouldDeleteExceptions_ThatMatchTheMethodName()
      {
        var loggingService = new LoggingService();

        const string methodName = "LoadPlaylistAsync";
        
        loggingService.DeleteByMethodName(methodName);

        var result = loggingService.GetExceptionsByMethodName(methodName).ToList();

        result.Should().BeEmpty();
      }

      [Test]
      public void GetAllExceptions()
      {
        var loggingService = new LoggingService();

        var exceptions = loggingService.GetExceptions();

        var exceptionsByCountDesc = (from exception in exceptions
          group exception by exception.MethodName
          into g
          select new {MethodName = g.Key, ExceptionCount = g.Select(x => x).Count()}).OrderByDescending(x => x.ExceptionCount).ToList();

        Assert.IsEmpty(exceptionsByCountDesc);
      }
    }
}