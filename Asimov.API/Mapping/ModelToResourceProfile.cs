using Asimov.API.Domain.Models;
using Asimov.API.Resources;
using AutoMapper;

namespace Asimov.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Director, DirectorResource>();
            CreateMap<Announcement, AnnouncementResource>();
            CreateMap<Teacher, TeacherResource>();
        }
    }
}