using AutoMapper;
using KBM.Application.DTOs;
using KBM.Domain.Entities;

namespace KBM.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Function, FunctionDto>();
            CreateMap<CreateFunctionDto, Function>();
            CreateMap<UpdateFunctionDto, Function>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();

            CreateMap<Industry, IndustryDto>();
            CreateMap<CreateIndustryDto, Industry>();
            CreateMap<UpdateIndustryDto, Industry>();

            CreateMap<Lesson, LessonDto>();
            CreateMap<CreateLessonDto, Lesson>();
            CreateMap<UpdateLessonDto, Lesson>();

            CreateMap<DepartmentFunction, DepartmentFunctionDto>()
                .ForMember(d => d.FunctionName, opt => opt.MapFrom(s => s.Function.Name))
                .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Department.Name));
            CreateMap<CreateDepartmentFunctionDto, DepartmentFunction>();
        }
    }
}