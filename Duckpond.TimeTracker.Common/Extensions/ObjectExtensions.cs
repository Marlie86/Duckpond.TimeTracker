using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Duckpond.TimeTracker.Common.Extensions;

public static class ObjectExtensions
{
    public static T? Clone<T>(this T obj)
    {
        var serialized = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
        return JsonSerializer.Deserialize<T>(serialized);
    }
}