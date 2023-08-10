
namespace BuildingManagementSystem.Base;

using System.Text.Json;

public partial class ResponseMessage
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public ResponseMessage(string message = null)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            Success = true;
        }

        else
        {
            Success = false;
            Message = message;
        }
    }

    public bool Success { get; set; }
    public string Message { get; set; }
}

public partial class ResponseMessage<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Response { get; set; }

    public ResponseMessage(bool isSuccess)
    {
        Success = isSuccess;
        Response = default;
        Message = isSuccess ? "Success" : "Error";
    }
    public ResponseMessage(T data)
    {
        Success = true;
        Response = data;
        Message = "Success";
    }

    public ResponseMessage(string message)
    {
        Success = false;
        Response = default;
        Message = message;
    }

}



