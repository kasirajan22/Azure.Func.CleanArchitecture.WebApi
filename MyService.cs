namespace Azure.Func.CleanArchitecture.WebApi;

public interface IMyService
{
    string DoSomething();
}

public class MyService : IMyService
{
    public string DoSomething()
    {
        return "Hello, Azure!";
    }
}