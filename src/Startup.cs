using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CloudCollective
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                if(ctx.Request.Method.ToLower() == "get")
                {
                    var appName = Environment.GetEnvironmentVariable("AppName");
                    await ctx.Response.WriteAsync($"Greetggings from '{appName}'");
                }
            });
        }
    }
}
