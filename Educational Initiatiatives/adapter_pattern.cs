// Target interface
public interface IStudentDatabase
{
    void AddStudent(string studentId);
}

// Adaptee (External system)
public class ExternalStudentDatabase
{
    public void Register(string studentId)
    {
        Console.WriteLine($"Student {studentId} registered in external database.");
    }
}

// Adapter
public class StudentDatabaseAdapter : IStudentDatabase
{
    private ExternalStudentDatabase _externalDatabase = new ExternalStudentDatabase();

    public void AddStudent(string studentId)
    {
        _externalDatabase.Register(studentId);
    }
}
