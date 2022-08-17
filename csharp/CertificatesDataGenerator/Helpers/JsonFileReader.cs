using System.Text.Json;

namespace CertificatesDataGenerator.Helpers
{
    internal static class JsonFileReader
    {
        public static async Task<T?> ReadAsync<T>(string filePath)
        {

            using FileStream? stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public static async Task WriteAsync<T>(string filePath, T content)
        {
            await using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, content);
        }
    }
}
