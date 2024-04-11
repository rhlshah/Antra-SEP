namespace ConsoleApp2;

using System;
using System.Collections.Generic;


public interface IPersonService
{
    int CalculateAge(DateTime birthDate);
    decimal CalculateSalary(decimal baseSalary);
}


public interface IStudentService : IPersonService
{
    double CalculateGPA(List<string> grades);
}


public interface IInstructorService : IPersonService
{
    int CalculateExperience(DateTime joinDate);
}


public class Course
{
    public List<Student> Students { get; set; }
}


public class Department
{
    public Instructor Head { get; set; }
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Course> Courses { get; set; }
}


public abstract class Person
{
    private List<string> addresses;

    public DateTime BirthDate { get; set; }

    public List<string> Addresses
    {
        get { return addresses; }
        set { addresses = value; }
    }

    public abstract int CalculateAge(DateTime birthDate);

    public abstract decimal CalculateSalary(decimal baseSalary);
}


public class Instructor : Person, IInstructorService
{
    public Department Department { get; set; }
    public DateTime JoinDate { get; set; }
    public decimal BonusSalary { get; set; }

    public override int CalculateAge(DateTime birthDate)
    {
       
        return DateTime.Now.Year - birthDate.Year;
    }

    public override decimal CalculateSalary(decimal baseSalary)
    {
       
        if (baseSalary < 0)
        {
            throw new ArgumentException("Base salary cannot be negative.");
        }

        
        return baseSalary + BonusSalary;
    }

    public int CalculateExperience(DateTime joinDate)
    {
        
        return DateTime.Now.Year - joinDate.Year;
    }
}


public class Student : Person, IStudentService
{
    public List<Course> Courses { get; set; }

    public override int CalculateAge(DateTime birthDate)
    {
        return DateTime.Now.Year - birthDate.Year;
    }

    public override decimal CalculateSalary(decimal baseSalary)
    {
        
        return 0;
    }

    public double CalculateGPA(List<string> grades)
    {
        
        return 0.0;
    }
}

public class OOP_q1
{
    static void Main(string[] args)
    {
        DateTime birthDate = new DateTime(1990, 1, 1);
        DateTime joinDate = new DateTime(2015, 1, 1);
        decimal baseSalary = 50000;

        Instructor instructor = new Instructor
        {
            BirthDate = birthDate,
            JoinDate = joinDate,
            BonusSalary = 10000
        };

        Console.WriteLine("Instructor Age: " + instructor.CalculateAge(instructor.BirthDate));
        Console.WriteLine("Instructor Experience: " + instructor.CalculateExperience(instructor.JoinDate));
        Console.WriteLine("Instructor Salary: " + instructor.CalculateSalary(baseSalary));
    }
}
