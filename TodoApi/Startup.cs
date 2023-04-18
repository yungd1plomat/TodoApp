using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using TodoApi.Abstractions;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<TodoList>("TodoList")
                .EntityType
                .HasMany(x => x.Items)
                .CascadeOnDelete();

            builder.EntitySet<TodoItem>("TodoItem");
            return builder.GetEdmModel();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddOData(options => options.AddRouteComponents("odata", GetEdmModel())
                                            .Select()
                                            .Filter()
                                            .OrderBy()
                                            .SetMaxTop(20)
                                            .Count()
                                            .Expand());

            var connectionString = Configuration["TODO_CONNECTION"] ?? throw new InvalidOperationException("connection string not found");

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27))));
            services.AddScoped<ITodoRepo, TodoRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseODataRouteDebug();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
