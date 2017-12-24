// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer.Host.Data;
using IdentityServer.Host.Models;
using IdentityServer.Services;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;


// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Certificates
/// https://stackoverflow.com/questions/42351274/identityserver4-hosting-in-iis
// the certificate has to be installed on the server.
// 1. To test this on localhost first, make sure you are using "AddSigningCredential" not "AddTemporarySigningCredential".
//    services.AddIdentityServer()
//            .AddSigningCredential(new X509Certificate2(Path.Combine(_environment.ContentRootPath, "certs", "IdentityServer4Auth.pfx")));
//            //.AddTemporarySigningCredential();
//
// 2. Create the certificate in your project(create certs folder), running this in visual studio command:
//
// "C:\Program Files (x86)\Windows Kits\8.1\bin\x64\makecert" -n "CN=IdentityServer4Auth" -a sha256 -sv IdentityServer4Auth.pvk -r IdentityServer4Auth.cer -b 01/01/2017 -e 01/01/2025 
// "C:\Program Files (x86)\Windows Kits\8.1\bin\x64\pvk2pfx" -pvk IdentityServer4Auth.pvk -spc IdentityServer4Auth.cer -pfx IdentityServer4Auth.pfx
//
// 3. Test on localhost
//    If successful, deploy to iis server, install the certificate on the server by double clicking on it, and test. 
//    Make sure the application pool "load user profile" is set to true :
//
// 4. Go to IIS Manager
//    Go to the application pool instance
//    Click advanced settings
//    Under Process model, set Load User Profile to true
//    Restart IIS
//
// 5. If this fails with a 500, like with me (and there is no logs to help you out), try this. 
//    To fix this recreate the certificate on the server the same way as in step 2 in the certs folder . double click the cert to install. 
//    You might have to install the developer kit if you dont have visual studio installed: https://developer.microsoft.com/en-us/windows/downloads/windows-8-1-sdk 
// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace IdentityServer
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        private IOptions<AppSettings> _appSettingsAccessor;

        private AppSettings _appSettings
        {
            get { return _appSettingsAccessor.Value; }
        }

        private string _appRootPath = "";
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            _appRootPath = env.ContentRootPath;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddMvc();

            // net core ef
            // ref: https://app.pluralsight.com/player?course=play-by-play-ef-core-1-0-first-look-julie-lerman&author=julie-lerman&name=play-by-play-ef-core-1-0-first-look-julie-lerman-m3&clip=2&mode=live
            // Add ASP.NET Identity entity framework database.
            var aspNetIdentityConnectionString = Configuration.GetConnectionString("AspNetIdentityConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(aspNetIdentityConnectionString));

            // This is my little trial of password history.
            services.AddDbContext<PasswordHistoryDbContext>(options => options.UseSqlServer(aspNetIdentityConnectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 7;
            })
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            // Add Identity Server //
            var connectionString = Configuration.GetConnectionString("IdentityServerConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            // Signing certificate related.
            var certPath = Path.Combine("", "Certs", "IdentityServer4.1.pfx");
            X509Certificate2 cert = new X509Certificate2(certPath, "", X509KeyStorageFlags.MachineKeySet);

            // configure identity server with in-memory users, but EF stores for clients and scopes
            services.AddIdentityServer()
                .AddSigningCredential(cert)
                //.AddTemporarySigningCredential()

                .AddConfigurationStore(builder =>   // client config and claims related //
                    builder.UseSqlServer(connectionString, options =>
                        options.MigrationsAssembly(migrationsAssembly)))

                .AddOperationalStore(builder =>     // persistant grant related // 
                    builder.UseSqlServer(connectionString, options =>
                        options.MigrationsAssembly(migrationsAssembly)))
                .AddAspNetIdentity<ApplicationUser>();// ASP NET IDENTITY USERS // 
                                                      //.AddTemporarySigningCredential() // for testing
                                                      //.AddTestUsers(Config.GetUsers()); // for testing

            // Custom Password Validation
            services.AddTransient<IResourceOwnerPasswordValidator, AspNetIdentityResourceOwnerPasswordValidator>();
            // Custom Password Validation Service that IdentitySErver and Aspnet Identity UserManager will use.
            services.AddTransient<ICustomPasswordValidator, CustomPasswordValidator>();

        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IOptions<AppSettings> appSettingsAccessor,
            ILoggerFactory loggerFactory)
        {
            try
            {
                // We have configured the appsettings so now lets use them.
                _appSettingsAccessor = appSettingsAccessor;

                // Issue: with a load balancer introduced the the url being https://identity.bi.com the issuer in the discovery was still being set to http://identity.bi.com.
                // This is a way in the .net core pipeline to set from the app.settings the sheme and host we need for identityserver function property.
                // ref: https://github.com/IdentityServer/IdentityServer4/issues/213
                if (!env.IsDevelopment()) // We are in dev then just do the local host specified in the launchSettings.json.
                {
                    //Uri uriAddress = new Uri(_appSettings.IdentityServer);
                    //HostString httpsHostString = new HostString(uriAddress.Host + uriAddress.PathAndQuery);
                    app.Use(async (context, next) =>
                    {
                        context.Request.Scheme = "https";
                        //context.Request.Scheme = uriAddress.Scheme;
                        //context.Request.Host = httpsHostString; // Jasons suggestion to just change scheme.
                        await next.Invoke();
                    });
                }
                // This will need to be investigated and tested for a possible solution the load balancer issue.
                //if (baseForwardOptions.Value.ForwardedHeaders == ForwardedHeaders.None)
                //{
                //    Log.Debug("---- Identity Server Configuration for ForwardHeaders ----");
                //    var options = new ForwardedHeadersOptions
                //    {
                //        ForwardedHeaders = ForwardedHeaders.All,
                //        RequireHeaderSymmetry = false
                //    };
                //    app.UseForwardedHeaders(options);
                //}

                // Logging
                InitializeLogging(Configuration, loggerFactory);

                Log.Information("---- Starting Identity Server (" + env.EnvironmentName + ") ----");

                // initial DB 
                Log.Debug("---- Initialize Database ----");
                InitializeDatabase(app);


                Log.Debug("---- Use Developer Exception Page ----");
                app.UseDeveloperExceptionPage();


                Log.Debug("---- Use ASP.NET Identity ----");
                app.UseIdentity();
                Log.Debug("---- Use Identity Server ----");
                app.UseIdentityServer();

                app.UseStaticFiles();

                // We will eventually need to setup our cors policy.
                //Log.Debug("---- Use Cors ----");
                //app.UseCors(policy =>
                //{
                //    //policy.WithOrigins(_appSettings.CORSOrigin);
                //    policy.WithOrigins("http://localhost:28895",
                //                       "http://localhost:7017");
                //});

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });

            }
            catch (Exception ex)
            {
                Log.Debug("---- Identity Server Exception ---- " + ex.Message + " -- " + ex.InnerException);
            }
        }
        private void InitializeLogging(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            // Serilog configuration.
            var logger = new LoggerConfiguration()
              .ReadFrom.Configuration(configuration)
              .CreateLogger();

            // Microsofts .net core logging framework / serilog extension method.
            loggerFactory.AddSerilog(logger);

            // Serilog.Log 
            Log.Logger = logger;
        }
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                //scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                // If is better to get and error earlier probably.
                var pwcontext = scope.ServiceProvider.GetRequiredService<PasswordHistoryDbContext>();
                //pwcontext.Database.Migrate();

                var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                //context.Database.Migrate();

                //if (!context.Clients.Any())
                //{
                //    foreach (var client in Config.GetClients())
                //    {
                //        context.Clients.Add(client.ToEntity());
                //    }
                //    context.SaveChanges();
                //}

                //if (!context.IdentityResources.Any())
                //{
                //    foreach (var resource in Config.GetIdentityResources())
                //    {
                //        context.IdentityResources.Add(resource.ToEntity());
                //    }
                //    context.SaveChanges();
                //}

                //if (!context.ApiResources.Any())
                //{
                //    foreach (var resource in Config.GetApiResources())
                //    {
                //        context.ApiResources.Add(resource.ToEntity());
                //    }
                //    context.SaveChanges();
                //}
            }
        }
    }

    public class AppSettings
    {
        public AppSettings()
        {
            PasswordHistoryCheckLimit = 5;
        }
        public string TotalAccessMachineKey { get; set; }
        public string IdentityServer { get; set; }
        public int PasswordHistoryCheckLimit { get; set; }
    }
}