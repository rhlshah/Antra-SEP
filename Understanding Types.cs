namespace ConsoleApp1;

public class Understanding_Types
{
    public void Main1()
    {
        Console.WriteLine("Data Type\tBytes\t\tMin Value\t\tMax Value");
        Console.WriteLine("---------------------------------------------------------------");

        Console.WriteLine($"sbyte\t\t{sizeof(sbyte)}\t\t{sbyte.MinValue}\t\t{sbyte.MaxValue}");
        Console.WriteLine($"byte\t\t{sizeof(byte)}\t\t{byte.MinValue}\t\t{byte.MaxValue}");
        Console.WriteLine($"short\t\t{sizeof(short)}\t\t{short.MinValue}\t\t{short.MaxValue}");
        Console.WriteLine($"ushort\t\t{sizeof(ushort)}\t\t{ushort.MinValue}\t\t{ushort.MaxValue}");
        Console.WriteLine($"int\t\t{sizeof(int)}\t\t{int.MinValue}\t\t{int.MaxValue}");
        Console.WriteLine($"uint\t\t{sizeof(uint)}\t\t{uint.MinValue}\t\t{uint.MaxValue}");
        Console.WriteLine($"long\t\t{sizeof(long)}\t\t{long.MinValue}\t{long.MaxValue}");
        Console.WriteLine($"ulong\t\t{sizeof(ulong)}\t\t{ulong.MinValue}\t\t{ulong.MaxValue}");
        Console.WriteLine($"float\t\t{sizeof(float)}\t\t{float.MinValue}\t\t{float.MaxValue}");
        Console.WriteLine($"double\t\t{sizeof(double)}\t\t{double.MinValue}\t{double.MaxValue}");
        Console.WriteLine($"decimal\t\t{sizeof(decimal)}\t\t{decimal.MinValue}\t{decimal.MaxValue}");

        Console.ReadLine();
    }

    public void Main2()
    {
        Console.WriteLine("Enter number of centuries");
        int centuries = int.Parse(Console.ReadLine());
        long years = centuries * 100;
        long days = years * 365;
        long hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        long nanoseconds = microseconds * 1000;
        
        Console.WriteLine($"Years : {years}");
        Console.WriteLine($"Days: {days}");
        Console.WriteLine($"Hours: {hours}");
        Console.WriteLine($"Minutes: {minutes}");
        Console.WriteLine($"Seconds: {seconds}");
        Console.WriteLine($"Milliseconds: {milliseconds}");
        Console.WriteLine($"Microseconds: {microseconds}");
        Console.WriteLine($"Nanoseconds: {nanoseconds}");

        Console.ReadLine();

    }
}