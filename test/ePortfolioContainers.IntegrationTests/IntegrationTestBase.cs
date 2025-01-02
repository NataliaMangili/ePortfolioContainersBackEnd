using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ePortfolioContainers.IntegrationTests;

public abstract class IntegrationTestBase
{
    public static IFormFile CreateFormFile(string fileContent, string fileName, string contentType = "application/octet-stream")
    {
        MemoryStream stream = new (Encoding.UTF8.GetBytes(fileContent));

        return new FormFile(baseStream: stream, baseStreamOffset: 0, length: stream.Length, name: "file", fileName: fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = contentType
        };
    }
}