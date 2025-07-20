using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
namespace HeThongQuanLyTrungTamTiengAnh.Middlewares
{
    public class CustomLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomLoggingMiddleware> _logger;


        public CustomLoggingMiddleware(RequestDelegate next, ILogger<CustomLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        // Invoke hoặc InvokeAsync là phương thức mà ASP.NET Core sẽ gọi
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                // Ghi log trước khi request được xử lý bởi các middleware tiếp theo
                _logger.LogInformation($"Request started: {httpContext.Request.Method} {httpContext.Request.Path } finished with status {httpContext.Response.StatusCode} in {stopWatch.ElapsedMilliseconds}ms");

                await this._next(httpContext);

                stopWatch.Stop();

                _logger.LogInformation($"Request finished: {httpContext.Request.Method} {httpContext.Request.Path} in {stopWatch.ElapsedMilliseconds}ms with status {httpContext.Response.StatusCode}");
            }
            catch (Exception ex) 
            {
                this._logger.LogError($"Something went wrong: {ex}");
                throw;
            }

        }
    }
}
