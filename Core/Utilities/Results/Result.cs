namespace Core.Utilities.Results;

public class Result : IResult
{
    public bool Success { get; } //readonly yapılar constructor'da setlenebilir
    public string Message { get; }

    public Result(bool success, string message):this(success) //bu class'ın sadece success parametresini alan constructor'ını da çalıştır demek.
    {
        Message = message;
    }

    public Result(bool success)
    {
        Success = success;
    }
}
