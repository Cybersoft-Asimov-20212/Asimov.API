using Asimov.API.Announcements.Domain.Models;
using Asimov.API.Announcements.Resources;
using Asimov.API.Competences.Domain.Models;
using Asimov.API.Competences.Resources;
using Asimov.API.Courses.Domain.Models;
using Asimov.API.Courses.Resources;
using Asimov.API.Directors.Domain.Models;
using Asimov.API.Directors.Resources;
using Asimov.API.Items.Domain.Models;
using Asimov.API.Items.Resources;
using Asimov.API.Teachers.Domain.Models;
using Asimov.API.Teachers.Resources;
using AutoMapper;

namespace Asimov.API.Shared.Mapping
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