using CoreSample.GraphQL.GrgphTypes;
using CoreSample.GraphQL.IRepositories;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace CoreSample.GraphQL.Middlewares
{
    public class ClassGraphQLMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IClassRepostory _classRepostory;

        public ClassGraphQLMiddleware(RequestDelegate next, IClassRepostory classRepostory)
        {
            _next = next;
            _classRepostory = classRepostory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (string.Equals(context.Request.Method.ToLower(), "post") && context.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var stream = new StreamReader(context.Request.Body))
                {
                    var strRequestBody = await stream.ReadToEndAsync();
                    if (!string.IsNullOrWhiteSpace(strRequestBody))
                    {
                        var schema = new Schema { Query = new ClassQuery(_classRepostory) };
                        var resultdoc = await new DocumentExecuter()
                            .ExecuteAsync(options =>
                            {
                                options.Query = strRequestBody;
                                options.Schema = schema;
                            });
                        await WriteResultAsync(context, resultdoc);
                    }
                }
            }
            else
            {
                await _next(context);
            }
        }

        private async Task WriteResultAsync(HttpContext context, ExecutionResult executionResult)
        {
            var resultdoc = new DocumentWriter(indent: true).Write(executionResult);
            //context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(resultdoc);
        }
    }
}