namespace Application.ResultPattern;
public class Result
{
    public Result(string data, bool isSuccess)
    {
        Data = data;
        IsSuccess = isSuccess;
    }

    public string Data { get; set; }
    public bool IsSuccess { get; set; }
}
