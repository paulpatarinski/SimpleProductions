using System.Linq;
using Core.Services;
using FluentAssertions;
using NUnit.Framework;

namespace Core.Test
{
    [TestFixture]
    public class LoggingServiceTest
    {
      [Test, Ignore("DB Call")]
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
      [Test, Ignore("DB Call")]
      public void DeleteByMethodName_ShouldDeleteExceptions_ThatMatchTheMethodName()
      {
        var loggingService = new LoggingService();

        const string methodName = "AddCoverImage";
        
        loggingService.DeleteByMethodName(methodName);

        var result = loggingService.GetExceptionsByMethodName(methodName).ToList();

        result.Should().BeEmpty();
      }
    }
}