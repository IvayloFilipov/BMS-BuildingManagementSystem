namespace BuildingManagementSystem.Web
{
    using System;
    using System.Reflection;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Common;
    using BuildingManagementSystem.Data.Common.Repositories;
    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Data.Repositories;
    using BuildingManagementSystem.Data.Seeding;
    using BuildingManagementSystem.Services.Data.Contacts;
    using BuildingManagementSystem.Services.Data.Debts;
    using BuildingManagementSystem.Services.Data.DeleteOwners;
    using BuildingManagementSystem.Services.Data.Edits;
    using BuildingManagementSystem.Services.Data.Expenses;
    using BuildingManagementSystem.Services.Data.Incomes;
    using BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterAddress;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterCompanyOwner;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterOwner;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterProperty;
    using BuildingManagementSystem.Services.Data.Registrations.Tenants;
    using BuildingManagementSystem.Services.Data.Reports;
    using BuildingManagementSystem.Services.Mapping;
    using BuildingManagementSystem.Services.Messaging;
    using BuildingManagementSystem.Web.ViewModels;
    using Hangfire;
    using Hangfire.SqlServer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddHangfire(
                config => config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer().UseRecommendedSerializerSettings().UseSqlServerStorage(
                        this.configuration.GetConnectionString("DefaultConnection"),
                        new SqlServerStorageOptions
                        {
                            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                            QueuePollInterval = TimeSpan.Zero,
                            UseRecommendedIsolationLevel = true,
                            UsePageLocksOnDequeue = true,
                            DisableGlobalLocks = true,
                        }));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            // Confirm account by e-meil when register, code below
            // services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false);
            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();

            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            // services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(this.configuration["SendGrid:ApiKey"]));
            services.AddTransient<IIncomeService, IncomeService>();
            services.AddTransient<IFeeService, FeeService>();
            services.AddTransient<IGenerateDebtService, GenerateDebtService>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IInitialRegisterService, InitialRegisterService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICompanyOwnerService, CompanyOwnerService>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IEditPropertyService, EditPropertyService>();
            services.AddTransient<IDeleteOwnerService, DeleteOwnerService>();
            services.AddTransient<IContactService, ContactService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecurringJobManager recurringJobManager)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                dbContext.Database.Migrate();

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();

                this.SeedHangfireJobs(recurringJobManager/*, dbContext*/);
            }

            app.UseHangfireServer(new BackgroundJobServerOptions { WorkerCount = 1 });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }

        private void SeedHangfireJobs(IRecurringJobManager recurringJobManager/*, ApplicationDbContext dbContext*/)
        {
#if DEBUG
            // var cron = Cron.Minutely();
            var cron = Cron.Monthly();

            recurringJobManager.RemoveIfExists(nameof(GenerateNewDebtsJob));
#else
            var cron = Cron.Monthly();
#endif
            recurringJobManager.AddOrUpdate<GenerateNewDebtsJob>(nameof(GenerateNewDebtsJob), x => x.Work(), cron);
        }
    }
}
