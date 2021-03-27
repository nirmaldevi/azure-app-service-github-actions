using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CloudCollective
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            const string HEADER_NAME = "Azure-Frontdoor-Header";

            app.Use(async (ctx, next) =>
            {
                if(ctx.Request.Method.ToLower() == "get")
                {
                    if(ctx.Request.Headers.ContainsKey(HEADER_NAME))
                    {
                        var header = ctx.Request.Headers[HEADER_NAME];
                        await ctx.Response.WriteAsync($"Found Azure Frontdoor Header with value: '{header}'");
                        return;
                    }

                    await ctx.Response.WriteAsync($"Unable to find HTTP Header: '{HEADER_NAME}'");
                }
            });
        }
    }
}
