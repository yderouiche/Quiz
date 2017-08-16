namespace Quiz.Application.Ports.Commands
{
    public interface ICanBeValidated
    {
        bool IsValid();
    }
}
