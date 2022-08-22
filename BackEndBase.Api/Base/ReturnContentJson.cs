namespace BackEndBase.Api.Base;

public class ReturnContentJson<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public dynamic Errors { get; set; }

    public ReturnContentJson()
    {
    }

    public ReturnContentJson(bool success, T data, dynamic errors = null)
    {
        Success = success;
        Data = data;
        Errors = errors;
    }
}