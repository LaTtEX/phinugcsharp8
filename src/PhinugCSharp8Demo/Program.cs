﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhinugCSharp8Demo.Pattern_Matching;

namespace PhinugCSharp8Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static Local Functions
            StaticLocalFunction();
            End_Feature();

            //Asynchronous Streams
            AsynchronousStreams(); //await is ommited by design
            Thread.Sleep(3300);
            End_Feature();

            //Indices and Ranges
            IndicesAndRanges();
            End_Feature();

            //Default interface methods
            DefaultInterfaceMethods();
            End_Feature();

            //Null coallescing assignment
            NullCoallescingAssignment();
            End_Feature();

            //Using Declarations
            UsingDeclarations();
            End_Feature();

            //Enhancement of Interpolated Verbatim Strings
            InterPolatedVerbatimStrings();
            End_Feature();

            //Pattern Matching - Switch Expressions
            PatternMatchingSwitchExpressions();
            End_Feature();
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

        private static async Task AsynchronousStreams()
        {
            Console.WriteLine("Asynchronous Streams");

            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }

            static async IAsyncEnumerable<int> GenerateSequence()
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(300);
                    yield return i;
                }
            }
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
                "jumps",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0

            Console.Write("All words: ");
            Array.ForEach(words, w => Console.Write($"{w} "));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Ranges:");
            Console.WriteLine($"words[0]: {words[0]}");
            Console.WriteLine($"words[^5]: {words[^5]}");
            Console.WriteLine();

            Console.Write("words[1..7]: ");
            Array.ForEach(words[1..7], w => Console.Write($"{w} "));
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("words[..5]: ");
            Array.ForEach(words[..5], w => Console.Write($"{w} "));
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("words[..^2]: ");
            Array.ForEach(words[..^2], w => Console.Write($"{w} "));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Group every three words using variables:");
            var groupBy = 3;
            for (var counter = 0; counter < words.Length; counter += groupBy)
            {
                Console.Write($"Group {(counter / groupBy) + 1}: ");
                Array.ForEach(words[counter..(counter + groupBy)], w => Console.Write($"{w} "));
                Console.WriteLine(); 
            };
        }

        private static void DefaultInterfaceMethods()
        {
            Console.WriteLine("Default Interface Implementation");

            ISayALittlePrayer defaultPrayer = new SayALittlePrayerDefault();
            ISayALittlePrayer implementedPrayer = new SayALittlePrayerImplement();
            Console.WriteLine($"Default: {defaultPrayer.SayALittlePrayer()}");
            Console.WriteLine($"Implemented: {implementedPrayer.SayALittlePrayer()}");
        }

        private static void NullCoallescingAssignment()
        {
            Console.WriteLine("Null-Coallescing Assignment (??=)");

            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine($"The numbers in the list are {string.Join(" ", numbers)}.");
            Console.WriteLine($"The value of i is {i}.");
        }

        private static void UsingDeclarations()
        {
            Console.WriteLine("Using Declarations");
            Console.WriteLine($"The number of even numbers in the Dispositor class is {CountEvens()}.");

            static int CountEvens()
            {
                using var dispositor = new Dispositor();
                int evens = 0;
                foreach (var number in dispositor.Numbers)
                {
                    evens += number % 2;
                }

                return evens;
            }
        }

        private static void InterPolatedVerbatimStrings()
        {
            Console.WriteLine("Enhancement of Interpolated Verbatim Strings");
            Console.WriteLine($@"This one works with $@. \n <== will not generate new line.");
            Console.WriteLine(@$"This one works with @$. \n <== will not generate new line.");
        }

        private static void PatternMatchingSwitchExpressions()
        {
            Console.WriteLine("Pattern Matching - Switch Expressions");

            static double ComputeArea_SwitchWithConditionals(object shape) 
            {
                switch (shape)
                {
                    case Square s when s.Side == 0:
                    case Circle c when c.Radius == 0:
                    case Triangle t when t.Base == 0 || t.Height == 0:
                    case Rectangle r when r.Length == 0 || r.Height == 0:
                        return 0;
                    case Square s:
                        return s.Side * s.Side;
                    case Circle c:
                        return c.Radius * c.Radius * Math.PI;
                    case Triangle t:
                        return t.Base * t.Height / 2;
                    case Rectangle r:
                        return r.Length * r.Height;
                    default:
                        throw new ArgumentException(
                            message: "shape is not a recognized shape",
                            paramName: nameof(shape));
                }
            }
        }

        private static void End_Feature()
        {
            Console.WriteLine();
            Console.WriteLine("=============");
            Console.WriteLine();
        }
    }
}
