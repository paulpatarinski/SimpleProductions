using AutoMapper;
using Core.DTOs;
using Web.Models;

namespace Web.App_Start
{
  public class AutomapperConfiguration
  {
    public static void Configure()
    {
      Mapper.CreateMap<CustomException, ExceptionModel>()
        .ForMember(dest => dest.ExceptionDate, opt => opt.MapFrom(src => src.ExceptionDate.ToString("d")));
    }
  }
}