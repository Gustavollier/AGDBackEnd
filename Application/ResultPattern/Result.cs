namespace Application.ResultPattern;
public class Result
{
    public Result(Object data, bool isSuccess)
    {
        Data = data;
        IsSuccess = isSuccess;
    }

    public Object Data { get; set; }
    public bool IsSuccess { get; set; }
}
