namespace ConsoleApp2;

public class Methods_q1
{
    public static void Main()
    {
        int[] numbers = GenerateNumbers(10); // Generate array of 10 numbers
        Console.WriteLine("Original array:");
        PrintNumbers(numbers); // Print original array

        Reverse(numbers); // Reverse the array
        Console.WriteLine("\nReversed array:");
        PrintNumbers(numbers); // Print reversed array
    }

    public static int[] GenerateNumbers(int length)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = i + 1; // Assign numbers 1 to length
        }
        return numbers;
    }

    public static void PrintNumbers(int[] numbers)
    {
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    public static void Reverse(int[] numbers)
    {
        for (int i = 0; i < numbers.Length / 2; i++)
        {
            int temp = numbers[i]; // Swap numbers
            numbers[i] = numbers[numbers.Length - i - 1];
            numbers[numbers.Length - i - 1] = temp;
        }
    }
}