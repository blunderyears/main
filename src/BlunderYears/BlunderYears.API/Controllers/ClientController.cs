namespace BlunderYears.API.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Azure;
    using Microsoft.AspNetCore.StaticFiles;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Azure.Functions.Worker.Http;
    using Microsoft.Net.Http.Headers;

    public class ClientController
    {
        [Function("ZClient")]
        public static async Task<HttpResponseData> ZClient(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{*urlPath}")] HttpRequestData request,
            string urlPath)
        {
            /*var contentFolder = Path.Combine(Directory.GetCurrentDirectory(), "angular");
            var response2 = request.CreateResponse(System.Net.HttpStatusCode.OK);
            response2.WriteAsJsonAsync(Directory.EnumerateDirectories(Directory.GetCurrentDirectory()).ToList());
            return response2;*/

            var contentFolder = Path.Combine(System.Environment.GetEnvironmentVariable("FUNCTIONS_APPLICATION_DIRECTORY"), "angular");

            if (!string.IsNullOrWhiteSpace(urlPath))
            {
                var folder = contentFolder;
                var pathSegments = urlPath.Split('/');
                for (var i = 0; i < pathSegments.Length - 1; i++)
                {
                    var pathSegment = pathSegments[i];
                    folder = Path.Combine(folder, pathSegment);
                }

                var fileSegment = pathSegments.Last();
                var file = Path.Combine(folder, fileSegment);

                if (!File.Exists(file))
                {
                    return await Index(contentFolder, request);
                }

                new FileExtensionContentTypeProvider().TryGetContentType(urlPath, out var contentType);

                var response = request.CreateResponse(System.Net.HttpStatusCode.OK);
                response.Headers.TryAddWithoutValidation("Content-Type", contentType);
                await response.WriteBytesAsync(await File.ReadAllBytesAsync(file));
                return response;
            }
            else
            {
                return await Index(contentFolder, request);
            }
        }

        private static async Task<HttpResponseData> Index(string contentFolder, HttpRequestData request)
        {
            var response = request.CreateResponse(System.Net.HttpStatusCode.OK);

            // Prevent the caching of the index file as it could potentially link to old cached js files
            response.Headers.TryAddWithoutValidation(HeaderNames.CacheControl, "no-cache, no-store, must-revalidate");
            response.Headers.TryAddWithoutValidation(HeaderNames.Expires, "0");
            response.Headers.TryAddWithoutValidation(HeaderNames.Pragma, "no-cache");

            response.Headers.TryAddWithoutValidation("Content-Type", "text/html");

            await response.WriteBytesAsync(await File.ReadAllBytesAsync(Path.Combine(contentFolder, "index.html")));
            return response;
        }
    }
}
