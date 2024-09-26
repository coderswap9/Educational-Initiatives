using System;
using System.Collections.Generic;

// Observer interface
public interface IObserver
{
    void Update(string message);
}

// Concrete Observer (Student)
public class Student : IObserver
{
    public string StudentID { get; private set; }
    
    public Student(string id)
    {
        StudentID = id;
    }

    public void Update(string message)
    {
        Console.WriteLine($"Student {StudentID} notified: {message}");
    }
}

// Subject (Classroom)
public class Classroom
{
    private List<IObserver> students = new List<IObserver>();

    public void AddStudent(IObserver student)
    {
        students.Add(student);
        Console.WriteLine($"Student added.");
    }

    public void NotifyStudents(string assignment)
    {
        foreach (var student in students)
        {
            student.Update($"New Assignment: {assignment}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Classroom classroom = new Classroom();

        IObserver student1 = new Student("001");
        IObserver student2 = new Student("002");

        classroom.AddStudent(student1);
        classroom.AddStudent(student2);

        classroom.NotifyStudents("Math Homework");
    }
}
