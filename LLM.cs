using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class LLM
{
    private string apiKey = "AIzaSyB8LosE6sbiuyxCSZw9_31oxMDrbzqGAw8";

    public async Task<string> Ask(string input)
    {
        var client = new HttpClient();

        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = input }
                    }
                }
            }
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        var response = await client.PostAsync(
            $"https://generativelanguage.googleapis.com/v1/models/gemini-2.5-flash:generateContent?key={apiKey}",
            content
        );

        var responseString = await response.Content.ReadAsStringAsync();

        var json = JsonDocument.Parse(responseString);

// Check if error exists
if (json.RootElement.TryGetProperty("error", out var error))
{
    return "LLM Error: " + error.ToString();
}

// Check if candidates exist
if (json.RootElement.TryGetProperty("candidates", out var candidates))
{
    var text = candidates[0]
        .GetProperty("content")
        .GetProperty("parts")[0]
        .GetProperty("text")
        .GetString();

    return text ?? "No response from LLM";
}

return "Unexpected response from LLM";
    }
}