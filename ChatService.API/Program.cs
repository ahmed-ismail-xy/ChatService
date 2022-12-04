using CloudChatService.API.Hubs;
using CloudChatService.API.Middlewares;
using CloudChatService.API.ProgramFactory;
using CloudChatService.Core.IDBServices;
using CloudChatService.Core.Services;
using CloudChatService.Infrastructure.Data;
using CloudChatService.Infrastructure.DBRepository;
using CloudChatService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ChatService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateBootstrapLogger();

            Log.Information("Starting up");

            try
            {
                var builder = WebApplication.CreateBuilder(args);


                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CloudChatService.API"));
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                });
                builder.Services.AddAuth(builder.Configuration);
                builder.Services.AddSignalR(options =>
                {
                    options.EnableDetailedErrors = true;
                });

                builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console()
                .ReadFrom.Configuration(ctx.Configuration));
                builder.Services.AddSingleton<RequestResponseLoggingMiddleware>();

                builder.Services.AddScoped<IUserAuthService, UserAuthRepository>();
                builder.Services.AddScoped<IUserProfileService, UserProfileRepository>();
                builder.Services.AddScoped<IChatService, ChatRepository>();
                builder.Services.AddScoped<IMessageService, MessageRepository>();
                builder.Services.AddScoped<IDBChatService, DBChatRepository>();
                builder.Services.AddScoped<IDBMessageService, DBMessageRepository>();
                builder.Services.AddScoped<IDBUserService, DBUserRepository>();

                builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                builder.Services.AddCustomJson();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                //builder.Services.AddCors(options =>
                //{
                //    options.AddPolicy("CorsPolicy",
                //        builder =>
                //        {
                //            builder.AllowAnyOrigin()
                //                .AllowAnyMethod()
                //                .AllowAnyHeader();
                //        });
                //});

                var app = builder.Build();
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseCors("CorsPolicy");

                app.UseStaticFiles();

                app.UseHttpsRedirection();

                app.UseSerilogRequestLogging();

                app.UseMiddleware<RequestResponseLoggingMiddleware>();

                app.UseAuthentication();

                app.UseAuthorization();

                app.MapHub<ChatHub>("/chathub");

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }
            finally
            {
                Log.Information("Shut down complete");
                Log.CloseAndFlush();
            }

        }
    }
}