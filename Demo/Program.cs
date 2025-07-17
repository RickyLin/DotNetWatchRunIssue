using Serilog;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSerilog(loggerCfg =>
            {
                 loggerCfg.ReadFrom.Configuration(builder.Configuration)
                     .Enrich.FromLogContext()
                     .Enrich.With<ExceptionDataEnricher>();

                loggerCfg.WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3} {SourceContext} {Scope}] {Message:lj}{NewLine}{Exception}{ExceptionData}");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
