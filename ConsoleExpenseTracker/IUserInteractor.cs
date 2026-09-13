namespace ConsoleExpenseTracker
{
    public interface IUserInteractor
    {
        string? GetUserInput();
        void DisplayMessage(string message);
        void DisplayMessageOnSameLine(string message);
    }
}