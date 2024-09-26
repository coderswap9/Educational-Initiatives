using System;
using System.Collections.Generic;

public class Classroom
{
    public string Name { get; private set; }
    private List<Student> students = new List<Student>();
    private List<string> assignments = new List<string>();

    public Classroom(string name)
    {
        Name = name;
    }

    public void AddStudent(string studentId)
    {
        students.Add(new Student(studentId));
        Console.WriteLine($"Student {studentId} has been enrolled in {Name}.");
    }

    public void ScheduleAssignment(string assignmentDetails)
    {
        assignments.Add(assignmentDetails);
        Console.WriteLine($"Assignment for {Name} has been scheduled.");
    }

    public void SubmitAssignment(string studentId, string assignmentDetails)
    {
        var student = students.Find(s => s.StudentID == studentId);
        if (student != null)
        {
            student.SubmitAssignment(assignmentDetails);
            Console.WriteLine($"Assignment submitted by Student {studentId} in {Name}.");
        }
        else
        {
            Console.WriteLine($"Student {studentId} not found in {Name}.");
        }
    }

    public List<Student> GetStudents()
    {
        return students;
    }
}

public class Student
{
    public string StudentID { get; private set; }
    private List<string> submittedAssignments = new List<string>();

    public Student(string id)
    {
        StudentID = id;
    }

    public void SubmitAssignment(string assignmentDetails)
    {
        submittedAssignments.Add(assignmentDetails);
    }
}

public class ClassroomManager
{
    private List<Classroom> classrooms = new List<Classroom>();

    public void AddClassroom(string className)
    {
        classrooms.Add(new Classroom(className));
        Console.WriteLine($"Classroom {className} has been created.");
    }

    public Classroom GetClassroom(string className)
    {
        return classrooms.Find(c => c.Name == className);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClassroomManager manager = new ClassroomManager();

        while (true)
        {
            Console.WriteLine("Enter a command:");
            string input = Console.ReadLine();
            var inputs = input.Split(' ');

            switch (inputs[0])
            {
                case "add_classroom":
                    manager.AddClassroom(inputs[1]);
                    break;
                case "add_student":
                    var classroom = manager.GetClassroom(inputs[2]);
                    classroom?.AddStudent(inputs[1]);
                    break;
                case "schedule_assignment":
                    classroom = manager.GetClassroom(inputs[1]);
                    classroom?.ScheduleAssignment(inputs[2]);
                    break;
                case "submit_assignment":
                    classroom = manager.GetClassroom(inputs[2]);
                    classroom?.SubmitAssignment(inputs[1], inputs[3]);
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
