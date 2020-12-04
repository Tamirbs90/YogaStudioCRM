using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YogaStudio.Data;
using Microsoft.EntityFrameworkCore;
using YogaStudio.Repositories;
using YogaStudio.Services;
using YogaStudio.Mapper;
using AutoMapper;

namespace YogaStudio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContextPool<PersonContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PersonDbConnection")));
            ConfigureServices(services);
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDbConnection")));
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<PersonContext>(options => options.UseMySql(Configuration.GetConnectionString("YogaDbConnection")));
            ConfigureServices(services);
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(typeof(MapperProfiles));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IMonthRepository, MonthRepository>();
            services.AddScoped<IClassesRepository, ClassesRepository>();
            services.AddScoped<IRepositoriesManager,RepositoriesManager>();
            services.AddScoped<IYogaLessonService, YogaLessonService>();
            //services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IWeekService, WeekService>();
            services.AddCors(opt =>
            {
                opt.AddPolicy("corsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("corsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "FallBack");
            });
        }
    }
}
