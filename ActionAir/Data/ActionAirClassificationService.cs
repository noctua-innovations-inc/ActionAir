using ActionAir.Models;
using System.Text.Json;

namespace ActionAir.Data;

public class ActionAirClassificationService
{
    public ActionAirClassificationService(ILogger<ActionAirClassificationService> logger)
    {
        Logger = logger;
    }

    protected ILogger<ActionAirClassificationService> Logger { get; set; }

    public async Task<Classification[]> GetClassificationsAsync(string division)
    {
        var result = Array.Empty<Classification>();

        try
        {
            using var file = File.OpenRead($"wwwroot/data/Classification{division}.json");
            result = await JsonSerializer.DeserializeAsync<Classification[]>(file) ?? Array.Empty<Classification>();
        }
        catch (Exception ex)
        {
            Logger.LogCritical("GetClassificationsAsync(\"{division}\") threw exception {@exception}", division, ex);
        }

        return result;
    }
}