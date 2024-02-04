namespace ApplicationLayer;

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
