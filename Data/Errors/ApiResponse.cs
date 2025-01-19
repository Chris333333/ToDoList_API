namespace Data.Errors;
/// <summary>
/// Class that returns error messages in a detailed and customized format to the user via the api response. Used in a api middleware.
/// </summary>
public class ApiResponse
{
    public ApiResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
    }
    /// <summary>
    /// Number of a html response status error code
    /// </summary>
    public int StatusCode { get; set; }
    /// <summary>
    /// Message that should be passed to the user
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// This function returns custom messages for each status codes that are personalized when there is no message passed. 
    /// </summary>
    /// <param name="statusCode"> We pass here a status code of an error that happened</param>
    /// <returns>Custom error message</returns>
    private string? GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "A bad request, you have made",
            401 => "Authorized, you are not",
            404 => "Opps! 404 Error Not Found",
            500 => "500 Internal server error",
            _ => null
        };
    }
}
