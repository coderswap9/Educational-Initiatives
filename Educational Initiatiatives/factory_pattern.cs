// Product (Abstract)
public abstract class ClassroomBase
{
    public abstract void DisplayClassType();
}

// Concrete Product 1
public class VirtualClassroom : ClassroomBase
{
    public override void DisplayClassType()
    {
        Console.WriteLine("This is a Virtual Classroom.");
    }
}

// Concrete Product 2
public class PhysicalClassroom : ClassroomBase
{
    public override void DisplayClassType()
    {
        Console.WriteLine("This is a Physical Classroom.");
    }
}

// Factory
public static class ClassroomFactory
{
    public static ClassroomBase CreateClassroom(string type)
    {
        if (type == "virtual")
            return new VirtualClassroom();
        else if (type == "physical")
            return new PhysicalClassroom();
        else
            throw new ArgumentException("Unknown classroom type");
    }
}
