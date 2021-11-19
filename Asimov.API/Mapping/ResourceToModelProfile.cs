using Asimov.API.Domain.Models;
using Asimov.API.Resources;
using AutoMapper;

namespace Asimov.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveDirectorResource, Director>();
            CreateMap<SaveAnnouncementResource, Announcement>();
            CreateMap<SaveTeacherResource, Teacher>();
            CreateMap<SaveCourseResource, Course>();
            CreateMap<SaveItemResource, Item>();
            CreateMap<SaveCompetenceResource, Competence>();
        }
    }
}