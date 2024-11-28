using System.Reflection;
using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Domain.Wrapper;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting.Server;
using DataAccess.Repositories;

namespace project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CharityDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IChatRepository, ChatRepository>();
            builder.Services.AddScoped<IChatService, ChatService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API äëÿ áëàãîòâîðèòåëüíîé ïëàòôîðìû",
                    Description = "Îïèñàíèå API äëÿ óïðàâëåíèÿ êóðñàìè, ïîëüçîâàòåëÿìè è ïîñòàìè",
                    Contact = new OpenApiContact
                    {
                        Name = "Êîíòàêòíàÿ èíôîðìàöèÿ",
                        Url = new Uri("https://example.com/contact")
                    }
                    ,
                    License = new OpenApiLicense
                    {
                        Name = "Ïðèìåð ëèöåíçèè",
                        Url = new Uri("https://example.com/license")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CharityDBContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.

                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
