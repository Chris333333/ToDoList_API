namespace Data.Errors;

/// <summary>
/// Class that expands the api response with details of happened error.
/// </summary>
public class ApiException(int statusCode, string? message = null, string? details = null) : ApiResponse(statusCode, message)
{
    public string? Details { get; set; } = details;

}
