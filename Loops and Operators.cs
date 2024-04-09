namespace ConsoleApp1;

public class Loops_and_Operators
{
    public void q1a()
    {
        for (int i = 1; i <= 100; i++)
        {
            if(i%3==0 && i%5==0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            
        }
    }

    public void q1b()
    {
        int max = 500;
        for (byte i = 0; i < max; i++)
        {
            Console.WriteLine(i);
        }
    }

    

    public void q2()
    {
        int rows = 5; 

       
        for (int i = 0; i < rows; i++)
        {
            
            for (int j = 0; j < rows - i - 1; j++)
            {
                Console.Write(" ");
            }

            
            for (int k = 0; k < 2 * i + 1; k++)
            {
                Console.Write("*");
            }

            Console.WriteLine(); // Move to the next line
        }
    }

    public void q3()
    {
        int randomNumber = new Random().Next(3) + 1;
        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int userGuess))
        {
            if (userGuess < 1 || userGuess > 3)
            {
                Console.WriteLine("Your guess is outside the valid range (1-3).");
            }
            else
            {
                if (userGuess < randomNumber)
                {
                    Console.WriteLine("Your guess is too low.");
                }
                else if (userGuess > randomNumber)
                {
                    Console.WriteLine("Your guess is too high.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed the correct number.");
                }
            }
        }else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public void q4()
    {
        DateTime birthDate = new DateTime(1990, 5, 15);
        TimeSpan daysSinceBirth = DateTime.Today - birthDate;

        Console.WriteLine($"The person is {daysSinceBirth.Days} days old.");
        int daysToNextAnniversary = 10000 - (daysSinceBirth.Days % 1000);
        
    }

    public void q5()
    {
        DateTime currentTime = DateTime.Now;
        int hour = currentTime.Hour;
        if (hour >= 5 && hour < 12)
        {
            Console.WriteLine("Good Morning!");
        }
        if (hour >= 12 && hour < 17)
        {
            Console.WriteLine("Good Afternoon!");
        }
        if (hour >= 17 && hour < 21)
        {
            Console.WriteLine("Good Evening!");
        }
        if (hour >= 21 || hour < 5)
        {
            Console.WriteLine("Good Night!");
        }
    }

    public void q6()
    {
        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine($"Counting by {i}s:");
            
            for (int j = 0; j <= 24; j += i)
            {
                Console.Write($"{j} ");
            }

            Console.WriteLine(); 
        }
    }
}