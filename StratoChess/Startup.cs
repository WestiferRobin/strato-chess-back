using Microsoft.OpenApi.Models;
using StratoChess.Data;
using StratoChess.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.EntityFrameworkCore;
using StratoChess.Services.Board;
using StratoChess.Services.Game;
using StratoChess.Models.Player.User;
using StratoChess.Enums;
using StratoChess.Models.Player.Prism;

namespace StratoChess
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IGameService, GameService>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StratoChessDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();

            DefineServices(services);

            // Enable CORS if needed
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", builder =>
                {
                    builder.WithOrigins("http://localhost:3000") // Adjust this to your React app's URL
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Configure Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "StratoChess API",
                    Version = "v1",
                });

                // Include XML comments from your controllers and models (if available)
                // Specify the path to your XML documentation file
                // options.IncludeXmlComments(PathToXmlDocumentationFile);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<StratoChessDbContext>();
                dbContext.Database.EnsureCreated();
                if (!dbContext.Users.Any())
                {
                    dbContext.Users.Add(new UserModel()
                    {
                        Name = "Wesley",
                        Username = "Wes",
                        Email = "w.webb0919@gmail.com",
                        Password = "Password123"
                    });
                    dbContext.SaveChanges();
                }
                if (!dbContext.Prisms.Any())
                {
                    foreach (var template in Enum.GetValues(typeof(PrismTemplate)))
                    {
                        dbContext.Prisms.Add(new PrismModel()
                        {
                            Template = (PrismTemplate)template
                        });
                    }
                    dbContext.SaveChanges();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Enable Swagger and Swagger UI in development environment
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "StratoChess API v1");
                    options.DocExpansion(DocExpansion.List);
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseRouting();

            // Enable CORS middleware
            app.UseCors("AllowReactApp");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
