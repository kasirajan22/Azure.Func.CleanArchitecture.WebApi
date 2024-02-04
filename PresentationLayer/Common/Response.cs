using System.Text.Json;
using System.Text.Json.Serialization;

namespace PresentationLayer;


public class Response
{
    public Response() { }

    public static Response Success(string? message = null) => new(true, message ?? Constants.Success);

    public static Response Failure(string? message = null) => new(false, message ?? Constants.Failed);

    public static Response Failure(string message, object data) => new(false, message, data);

    public static Response Success(object data) => new(data);

    public static Response Success(string message, object data) => new(message, data);

    public static Response Success(object data, OutputParameters pagination) => new(data, pagination);

    public static Response Success(bool ok, string message, object data) => new(ok, message, data);

    public Response(bool ok, string message) => (Ok, Message) = (ok, message);

    public Response(object data) => (Ok, Message, Data) = (true, Constants.Success, data);

    public Response(string message, object data) => (Ok, Message, Data) = (true, message, data);

    public Response(bool ok, string message, object data) => (Ok, Message, Data) = (ok, message, data);

    public Response(object data, OutputParameters pagination)
        => (Ok, Message, Data, Pagination) = (true, Constants.Success, data, pagination);

    public bool Ok { get; set; }

    public string Message { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Data { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OutputParameters? Pagination { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ErrorId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, List<string>>? Errors { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });
}
