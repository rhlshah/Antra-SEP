namespace ConsoleApp1;
using System.Text.RegularExpressions;
using System.Linq;
public class Strings
{
    public void q1()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversedString1 = new string(charArray);
        Console.WriteLine($"Reversed string (Method 1): {reversedString1}");
        string reversedString2 = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversedString2 += input[i];
        }
        Console.WriteLine($"Reversed string (Method 2): {reversedString2}");
    }

    public void q2()
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();
        
        char[] separators = { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
        
        string[] words = Regex.Split(sentence, @"(?<=[.,:;=()&\[\]""'\\\/!? ])");
        Array.Reverse(words);
        string reversedSentence = string.Join("", words);

        Console.WriteLine($"Reversed sentence: {reversedSentence}");
    }
    static bool IsPalindrome(string word)
    {
        return word.SequenceEqual(word.Reverse());
    }

    public void q3()
    {
        Console.WriteLine("Enter a text:");
        string text = Console.ReadLine();
        string pattern = @"\b(?<word>\w+)\b";
        MatchCollection matches = Regex.Matches(text, pattern);

       
        var palindromes = matches
            .Cast<Match>()
            .Select(m => m.Groups["word"].Value)
            .Where(IsPalindrome)
            .Distinct()
            .OrderBy(p => p);
        
        Console.WriteLine("Palindromes: " + string.Join(", ", palindromes));
    }

    public void q4()
    {
        Console.WriteLine("Enter the URL:");
        string url = Console.ReadLine();
        string protocol = "";
        string server = "";
        string resource = "";

        int protocolSeparatorIndex = url.IndexOf("://");
        if (protocolSeparatorIndex != -1)
        {
            protocol = url.Substring(0, protocolSeparatorIndex);
            url = url.Substring(protocolSeparatorIndex + 3);
        }

        int resourceSeparatorIndex = url.IndexOf("/");
        if (resourceSeparatorIndex != -1)
        {
            server = url.Substring(0, resourceSeparatorIndex);
            resource = url.Substring(resourceSeparatorIndex + 1);
        }
        else
        {
            server = url;
        }
        Console.WriteLine($"Protocol: {protocol}");
        Console.WriteLine($"Server: {server}");
        Console.WriteLine($"Resource: {resource}");
    }
    
}