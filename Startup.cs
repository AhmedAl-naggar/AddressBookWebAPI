using AddressBookWebAPI.Models;
using AddressBookWebAPI.Models.DataManager;
using AddressBookWebAPI.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AddressBookWebAPI
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

            services.AddDbContext<AddressBookDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AddressBookDB")));

            services.AddScoped<IDataRepository<User>, UserDataManager>();
            services.AddScoped<IDataRepository<Friend>, FriendDataManager>();
            services.AddScoped<IDataRepository<Parent>, ParentDataManager>();
            services.AddScoped<IDataRepository<Phone>, PhoneDataManager>();

            services.AddControllers().AddNewtonsoftJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
