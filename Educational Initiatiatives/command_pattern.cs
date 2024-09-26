// Command interface
public interface ICommand
{
    void Execute();
    void Undo();
}

// Concrete Command (Submit Assignment)
public class SubmitAssignmentCommand : ICommand
{
    private string _assignment;
    private Student _student;

    public SubmitAssignmentCommand(Student student, string assignment)
    {
        _student = student;
        _assignment = assignment;
    }

    public void Execute()
    {
        Console.WriteLine($"{_student.StudentID} submitted: {_assignment}");
    }

    public void Undo()
    {
        Console.WriteLine($"{_student.StudentID} has undone the submission of: {_assignment}");
    }
}

// Invoker
public class CommandInvoker
{
    private Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoCommand()
    {
        if (_commandHistory.Count > 0)
        {
            var command = _commandHistory.Pop();
            command.Undo();
        }
    }
}
