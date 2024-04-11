namespace ConsoleApp2;

using System;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    public Color(int red, int green, int blue, int alpha = 255)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }

    public int Red
    {
        get { return red; }
        set { red = value; }
    }

    public int Green
    {
        get { return green; }
        set { green = value; }
    }

    public int Blue
    {
        get { return blue; }
        set { blue = value; }
    }

    public int Alpha
    {
        get { return alpha; }
        set { alpha = value; }
    }

    public int GetGrayscale()
    {
        return (red + green + blue) / 3;
    }
}

public class Ball
{
    private int size;
    private Color color;
    private int throwCount;

    public Ball(int size, Color color)
    {
        this.size = size;
        this.color = color;
        throwCount = 0;
    }

    public void Pop()
    {
        size = 0;
    }

    public void Throw()
    {
        if (size > 0)
        {
            throwCount++;
        }
    }

    public int GetThrowCount()
    {
        return throwCount;
    }
}

class OOP_q7
{
    static void Main(string[] args)
    {
        // Create a few balls with different colors
        Color redColor = new Color(255, 0, 0);
        Color greenColor = new Color(0, 255, 0);
        Color blueColor = new Color(0, 0, 255);

        Ball redBall = new Ball(10, redColor);
        Ball greenBall = new Ball(15, greenColor);
        Ball blueBall = new Ball(20, blueColor);

        // Throw balls around a few times
        redBall.Throw();
        redBall.Throw();
        greenBall.Throw();
        blueBall.Throw();
        blueBall.Throw();
        blueBall.Throw();

        // Pop a few balls
        greenBall.Pop();
        blueBall.Pop();

        // Try to throw popped balls
        greenBall.Throw();
        blueBall.Throw();

        // Print out the number of times each ball has been thrown
        Console.WriteLine("Red Ball Thrown Count: " + redBall.GetThrowCount());
        Console.WriteLine("Green Ball Thrown Count: " + greenBall.GetThrowCount());
        Console.WriteLine("Blue Ball Thrown Count: " + blueBall.GetThrowCount());
    }
}
