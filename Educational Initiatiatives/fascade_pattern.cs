public class ClassroomFacade
{
    private ClassroomManager _manager = ClassroomManager.GetInstance();
    private List<Student> _students = new List<Student>();

    public void EnrollStudent(string studentId, string className)
    {
        _manager.ManageClassroom(className);
        _students.Add(new Student(studentId));
        Console.WriteLine($"Student {studentId} enrolled in {className}");
    }
}
