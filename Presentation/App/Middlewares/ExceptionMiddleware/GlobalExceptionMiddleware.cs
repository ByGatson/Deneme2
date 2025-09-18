using Application.Result;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Net;
using System.Text.Json;

namespace App.Middlewares.ExceptionMiddleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMongoCollection<BsonDocument> _logCollection;

        public GlobalExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;

            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("LogsDb");
            _logCollection = database.GetCollection<BsonDocument>("ExceptionLogs");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await LogExceptionToMongoAsync(context, ex);

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = Result<string>.Failure(exception.Message);

            var json = JsonSerializer.Serialize(result);

            return context.Response.WriteAsync(json);
        }

        private async Task LogExceptionToMongoAsync(HttpContext context, Exception exception)
        {
            var log = new BsonDocument
            {
                { "Message", exception.Message },
                { "StackTrace", exception.StackTrace ?? "" },
                { "Method", context.Request.Method },
                { "QueryString", context.Request.QueryString.ToString() },
                { "Timestamp", DateTime.UtcNow }
            };

            await _logCollection.InsertOneAsync(log);
        }
    }
}
