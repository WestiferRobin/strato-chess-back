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
using StratoChess.Models;
using StratoChess.Converter;
using StratoChess.Models.Player;

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

        private static void AddWes(StratoChessDbContext dbContext)
        {
            var userModel = new UserModel()
            {
                Name = "Wesley",
                Username = "Westifer",
                Email = "w.webb0919@gmail.com",
                Password = "Password123"
            };
            var userTheme = new PlayerTheme()
            {
                PrimaryColor = "#fff",
                SecondaryColor = "#f00"
            };
            dbContext.PlayerThemes.Add(userTheme);
            dbContext.SaveChanges();

            dbContext.Users.Add(userModel);
            dbContext.SaveChanges();

            var userPlayer = new UserPlayer()
            {
                UserId = userModel.Id,
                Name = userModel.Username,
                PlayerRank = 800,
                ThemeId = userTheme.Id
            };
            dbContext.Players.Add(userPlayer);
            dbContext.SaveChanges();
        }

        private static void AddEmma(StratoChessDbContext dbContext)
        {
            var userModel = new UserModel()
            {
                Name = "Emma",
                Username = "Eburr",
                Email = "ee@gmail.com",
                Password = "Password321"
            };
            var userTheme = new PlayerTheme()
            {
                PrimaryColor = "#000",
                SecondaryColor = "#0ff"
            };
            dbContext.PlayerThemes.Add(userTheme);
            dbContext.SaveChanges();

            dbContext.Users.Add(userModel);
            dbContext.SaveChanges();

            var userPlayer = new UserPlayer()
            {
                UserId = userModel.Id,
                Name = userModel.Username,
                PlayerRank = 800,
                ThemeId = userTheme.Id
            };
            dbContext.Players.Add(userPlayer);
            dbContext.SaveChanges();
        }

        private static void AddDatabaseData(StratoChessDbContext dbContext)
        {
            if (!dbContext.Prisms.Any())
            {
                foreach (var templateObj in Enum.GetValues(typeof(PrismTemplate)))
                {
                    var template = (PrismTemplate)templateObj;
                    var prismModel = new PrismModel()
                    {
                        Template = template
                    };
                    var primaryColor = ThemeConverter.ConvertColor(template);
                    var secondaryColor = template != PrismTemplate.Omega
                        ? "#000" : "#fff";
                    var prismTheme = new PlayerTheme()
                    {
                        PrimaryColor = primaryColor,
                        SecondaryColor = secondaryColor
                    };
                    dbContext.Prisms.Add(prismModel);
                    dbContext.SaveChanges();
                    dbContext.PlayerThemes.Add(prismTheme);
                    dbContext.SaveChanges();

                    var prismName = Enum.GetName(typeof(PrismTemplate), template);
                    var prismPlayer = new PrismPlayer()
                    {
                        PrismId = prismModel.Id,
                        Name = prismName!,
                        PlayerRank = 800,
                        ThemeId = prismTheme.Id
                    };
                    dbContext.Players.Add(prismPlayer);
                    dbContext.SaveChanges();
                }
            }
            if (!dbContext.Users.Any())
            {
                if (!dbContext.Users.Where(user => user.Email == "ww@gmail.com").Any())
                {
                    AddWes(dbContext);
                }
                if (!dbContext.Users.Where(user => user.Email == "ee@gmail.com").Any())
                {
                    AddEmma(dbContext);
                }
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<StratoChessDbContext>();
                dbContext.Database.EnsureCreated();
                AddDatabaseData(dbContext);
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
