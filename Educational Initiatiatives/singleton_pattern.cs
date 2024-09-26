public class ClassroomManager
{
    private static ClassroomManager _instance;

    private ClassroomManager() { }

    public static ClassroomManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ClassroomManager();
        }
        return _instance;
    }

    public void ManageClassroom(string className)
    {
        Console.WriteLine($"Managing classroom: {className}");
    }
}
