namespace ConsoleApp2;

public class Methods_q2
{
    public static void Main()
    {
        // Loop through the first 10 Fibonacci numbers and print them
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Fibonacci({i}) = {Fibonacci(i)}");
        }
    }

    public static int Fibonacci(int n)
    {
        // Base case: first two numbers in the Fibonacci sequence are 1
        if (n == 1 || n == 2)
        {
            return 1;
        }
        // Recursive case: sum of previous two Fibonacci numbers
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}