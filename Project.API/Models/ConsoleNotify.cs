using Project.Interface;

public class ConsoleNotify : INotify
{
    public void Notify(string message)
    {
        Console.WriteLine(message);
    }
}
