using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloApp.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloApp
{
    public class Startup
    {
        IWebHostEnvironment _env;
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
            }

            //// добавляем возможности маршрутизации
            //app.UseRouting();

            //// устанавливаем адреса, которые будут обрабатываться
            //app.UseEndpoints(endpoints =>
            //{
            //    // обработка запроса - получаем констекст запроса в виде объекта context
            //    endpoints.MapGet("/", async context =>
            //    {
            //        // отправка ответа в виде строки "Hello World!"
            //        await context.Response.WriteAsync($"Application Name: {_env.ApplicationName}");
            //    });
            //});


            //int x = 2;
            //app.Run(async (context) =>
            //{
            //    x = x * 2;
            //    await context.Response.WriteAsync($"Result: {x}");
            //});


            //app.Run(async (context) => 
            //{
            //    await context.Response.WriteAsync($"Hello World!");
            //});


            //int x = 5;
            //int y = 8;
            //int z = 0;

            //app.Use(async (context, next) =>
            //{
            //    z = x * y;
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"x * y = {z}");
            //});


            //int x = 2;
            //app.Use(async (context, next) =>
            //{
            //    x = x * 2;      // 2 * 2 = 4
            //    await next.Invoke();    // вызов app.Run
            //    x = x * 2;      // 8 * 2 = 16
            //    await context.Response.WriteAsync($"Result: {x}");
            //});

            //app.Run(async (context) =>
            //{
            //    x = x * 2;  //  4 * 2 = 8
            //    await Task.FromResult(0);
            //});


            //app.Map("/home", home =>
            //{
            //    home.Map("/index", Index);
            //    home.Map("/about", About);
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Page Not Found");
            //});


            //app.MapWhen(context => {

            //    return context.Request.Query.ContainsKey("id") &&
            //            context.Request.Query["id"] == "5";
            //}, HandleId);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Good bye, World...");
            //});


            //app.UseMiddleware<TokenMiddleware>();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});


            //app.UseToken("55555");

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});


            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<RoutingMiddleware>();

        }

        //private static void Index(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Index");
        //    });
        //}
        //private static void About(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("About");
        //    });
        //}


        //private static void HandleId(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("id is equal to 5");
        //    });
        //}

    }
}
