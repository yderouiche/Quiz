using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Paramore.Brighter;
using Quiz.API.Factories;
using Quiz.Application.Ports.Commands;
using Quiz.Application.Ports.Handlers;
using Quiz.Application.Ports.Repositories;
using Quiz.Database;
using Quiz.Domain.Repositories;
using System;

namespace Quiz.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public static IConfiguration Configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

               .AddEnvironmentVariables("Quiz.API.")
               .AddEnvironmentVariables($"{env.EnvironmentName}.Quiz.API.");
            Configuration = builder.Build();
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices( IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionString"];

            services.AddDbContext<QuizDbContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAmAHandlerFactory, SimpleHandlerFactory>();

            //Create & regiter the command processor
            var serviceProvider = services.BuildServiceProvider();

            var registry = new SubscriberRegistry();
            registry.Register<AddQuestionCommand, AddQuestionCommandHandler>();

            var commandProcessor = CreateCommandProcesor(registry, serviceProvider);
            services.AddSingleton(commandProcessor);
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registry"></param>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        private static CommandProcessor CreateCommandProcesor(SubscriberRegistry registry, IServiceProvider serviceProvider)
        {
            var factory = (IAmAHandlerFactory)serviceProvider.GetService(typeof(IAmAHandlerFactory));

            var builder = CommandProcessorBuilder.With()
                .Handlers(new HandlerConfiguration(
                     subscriberRegistry: registry,
                     handlerFactory: factory
                    ))
                .DefaultPolicy()
                .NoTaskQueues()
                .RequestContextFactory(new InMemoryRequestContextFactory());

            return builder.Build();
        }


    }
}
