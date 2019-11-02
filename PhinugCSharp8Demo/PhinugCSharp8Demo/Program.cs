using System;

namespace PhinugCSharp8Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Static Local Functions
            //Read more at https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions
            static string LocalFunc()
            {
                return "Hi I'm local!";
            }

            Console.WriteLine($"The local func said: {LocalFunc()}");
            Console.WriteLine("=============");
            Console.WriteLine();

            //2. Indices and Ranges
            //Read more at https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0

            Console.WriteLine("Ranges");
            Console.WriteLine($"words[0]: {words[0]}");
            Console.WriteLine($"words[^5]: {words[^5]}");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("All words:");
            Array.ForEach(words, w => Console.Write($"{w} "));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("words[1..7]");
            Array.ForEach(words[1..7], w => Console.Write($"{w} "));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("words[..5]");
            Array.ForEach(words[..5], w => Console.Write($"{w} "));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("words[..^2]");
            Array.ForEach(words[..^2], w => Console.Write($"{w} "));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=============");

            //3. Default interface methods
            //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#default-interface-methods
            ISayALittlePrayer defaultPrayer = new SayALittlePrayerDefault();
            ISayALittlePrayer implementedPrayer = new SayALittlePrayerImplement();
            Console.WriteLine($"Default: {defaultPrayer.SayALittlePrayer()}");
            Console.WriteLine($"Implemented: {implementedPrayer.SayALittlePrayer()}");
            Console.WriteLine();
            Console.WriteLine("=============");
        }
    }
}
