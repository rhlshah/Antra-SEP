namespace ConsoleApp1;

public class Arrays
{

    public void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
    
    public void q1()
    {
        int[] arr = {1,2,3,4,5,6,7,8,9,10};
        PrintArray(arr);

        int[] arr_copy = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr_copy[i] = arr[i];
        }
        PrintArray(arr_copy);
        
        
    }

    public void q2()
    {
        List<string> list = new List<string>();

        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid command. Please try again.");
                continue;
            }

            char command = input[0];
            string item = input.Substring(1).Trim();

            switch (command)
            {
                case '+':
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        list.Add(item);
                    }

                    break;
                case '-':
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        list.Remove(item);
                    }

                    break;
                case '_':
                    list.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }

            Console.WriteLine("\nCurrent List:");
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem);
            }

            Console.WriteLine();
        }
    }
    
    public static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();

        for (int num = startNum; num <= endNum; num++)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
        }

        return primes.ToArray();
    }

    public static bool IsPrime(int num)
    {
        if (num <= 1)
        {
            return false;
        }

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }
    
    public void q4(int[] numbers, int k)
    {
        int n = numbers.Length;
        int[] sum = new int[n];

        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                rotatedArray[(i + r) % n] = numbers[i];
            }

            Console.WriteLine($"Array after rotation {r}: {string.Join(" ", rotatedArray)}");

            for (int i = 0; i < n; i++)
            {
                sum[i] += rotatedArray[i];
            }
        }

        Console.WriteLine($"Sum after {k} rotations: {string.Join(" ", sum)}");
    }

    public void q5()
    {
        Console.WriteLine("Enter the array of integers separated by space:");
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int start = 0;
        int length = 1;
        int maxLength = 1;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                length++;
                if (length > maxLength)
                {
                    maxLength = length;
                    start = i - length + 1;
                }
            }
            else
            {
                length = 1;
            }
        }

        int[] longestSequence = new int[maxLength];
        Array.Copy(numbers, start, longestSequence, 0, maxLength);

        Console.WriteLine($"Longest sequence of equal elements: {string.Join(" ", longestSequence)}");
    }

    public void q7()
    {
        Console.WriteLine("Enter the sequence of numbers separated by space:");
        int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (!frequencyMap.ContainsKey(number))
            {
                frequencyMap[number] = 0;
            }

            frequencyMap[number]++;
        }

        int mostFrequentNumber = numbers[0];
        int maxFrequency = frequencyMap[numbers[0]];

        foreach (var kvp in frequencyMap)
        {
            if (kvp.Value > maxFrequency || (kvp.Value == maxFrequency && Array.IndexOf(numbers, kvp.Key) < Array.IndexOf(numbers, mostFrequentNumber)))
            {
                mostFrequentNumber = kvp.Key;
                maxFrequency = kvp.Value;
            }
        }

        Console.WriteLine($"Most frequent number: {mostFrequentNumber}");
    }
    
    
    
}

