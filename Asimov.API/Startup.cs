using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asimov.API.Announcements.Domain.Repositories;
using Asimov.API.Announcements.Domain.Services;
using Asimov.API.Announcements.Persistence.Repositories;
using Asimov.API.Announcements.Services;
using Asimov.API.Competences.Domain.Repositories;
using Asimov.API.Competences.Domain.Services;
using Asimov.API.Competences.Persistence.Repositories;
using Asimov.API.Competences.Services;
using Asimov.API.Courses.Domain.Repositories;
using Asimov.API.Courses.Domain.Services;
using Asimov.API.Courses.Persistence.Repositories;
using Asimov.API.Courses.Services;
using Asimov.API.Directors.Domain.Repositories;
using Asimov.API.Directors.Domain.Services;
using Asimov.API.Directors.Persistence.Repositories;
using Asimov.API.Directors.Services;
using Asimov.API.Items.Domain.Repositories;
using Asimov.API.Items.Domain.Services;
using Asimov.API.Items.Persistence.Repositories;
using Asimov.API.Items.Services;
using Asimov.API.Shared.Domain.Repositories;
using Asimov.API.Shared.Persistence.Contexts;
using Asimov.API.Shared.Persistence.Repositories;
using Asimov.API.Teachers.Domain.Repositories;
using Asimov.API.Teachers.Domain.Services;
using Asimov.API.Teachers.Persistence.Repositories;
using Asimov.API.Teachers.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Asimov.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Asimov.API", Version = "v1"});
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("asimov-api-in-memory");
            });

            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICompetenceRepository, CompetenceRepository>();
            services.AddScoped<ICompetenceService, CompetenceService>();
            services.AddScoped<ITeacherCourseRepository, TeacherCourseRepository>();
            services.AddScoped<ITeacherCourseService, TeacherCourseService>();
            services.AddScoped<ICourseCompetenceRepository, CourseCompetenceRepository>();
            services.AddScoped<ICourseCompetenceService, CourseCompetenceService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asimov.API v1"));
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection(); 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}