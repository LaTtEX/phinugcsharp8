using System;
using System.Collections.Generic;

namespace PhinugCSharp8Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static Local Functions
            //Read more at https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions
            
            StaticLocalFunction();
            End_Feature();

            //Indices and Ranges
            //Read more at https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges
            IndicesAndRanges();
            End_Feature();

            //Default interface methods
            //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#default-interface-methods
            DefaultInterfaceMethods();
            End_Feature();

            //Null coallescing assignment
            //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#null-coalescing-assignment
            NullCoallescingAssignment();
            End_Feature();
        }

        private static void NullCoallescingAssignment()
        {
            Console.WriteLine("Null Coallescing Assignment (??=)");

            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17
        }

        private static void DefaultInterfaceMethods()
        {
            Console.WriteLine("Default Interface Implementation");

            ISayALittlePrayer defaultPrayer = new SayALittlePrayerDefault();
            ISayALittlePrayer implementedPrayer = new SayALittlePrayerImplement();
            Console.WriteLine($"Default: {defaultPrayer.SayALittlePrayer()}");
            Console.WriteLine($"Implemented: {implementedPrayer.SayALittlePrayer()}");
        }

        private static void IndicesAndRanges()
        {
            Console.WriteLine("Indices and Ranges");

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
        }

        private static void StaticLocalFunction()
        {
            Console.WriteLine("Static Local Functions");

            static string LocalFunc()
            {
                return "Hi I'm local!";
            }

            Console.WriteLine($"The local func said: {LocalFunc()}");
        }

        private static void End_Feature()
        {
            Console.WriteLine();
            Console.WriteLine("=============");
            Console.WriteLine();
        }
    }
}
