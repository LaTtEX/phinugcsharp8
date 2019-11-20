using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhinugCSharp8Demo.Default_Interface_Implementation;
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

            //Pattern Matching - Property Patterns
            PatternMatchingPropertyPatterns();
            End_Feature();

            //Pattern Matching - Tuple Patterns
            PatternMatchingTuplePatterns();
            End_Feature();

            //Pattern Matching - Positional Patterns
            PatternMatchingPositionalPatterns();
            End_Feature();
            
            //Nullable Reference Types
            NullableReferenceTypes();
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
            
            var square = new Square(3); //side = 3
            var circle = new Circle(1.0); //radius = 1
            var triangle = new Triangle(5.0, 4.0); //base = 5, height = 4
            var rectangle = new Rectangle(3.0, 4.0); //base = 3, height = 4
            var shapeArray = new object[]{square, circle, triangle, rectangle};
            Array.ForEach(
                shapeArray, shape => 
                Console.WriteLine($"Type: {shape.GetType().Name}, Area: {ComputeArea_SwitchWithConditionals(shape)}"));

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

        private static void PatternMatchingPropertyPatterns()
        {
            Console.WriteLine("Pattern Matching - Property Patterns");

            var wongKarWai = new ChineseName("Wong", "Kar", "Wai");
            var georgeBush = new AmericanName("George", "Bush", "Walker");
            var tomCruise = new AmericanName("Tom", "Cruise");
            var antonioBanderas = 
                new SpanishName("Jose", "Antonio", "Bandera", "Dominguez");
            var johnLloyd = new FilipinoName("John", "Cruz",  secondName: "Lloyd", mothersSurname: "Espidol");
            var duterte = new FilipinoName("Rodrigo", "Duterte", mothersSurname: "Roa");
            var robinPadilla = new FilipinoName("Robin", "Padilla");
            var nameList = new List<Name> { wongKarWai, georgeBush, tomCruise, antonioBanderas, johnLloyd, duterte, robinPadilla };

            nameList.ForEach(name => Console.WriteLine(GetFullName(name)));

            static string GetFullName(Name name) =>
                name switch
                {
                    SpanishName sname 
                        => $"{name.FirstName} {name.SecondName} {name.FathersSurname} {sname.MothersSurname}",
                    ChineseName cname 
                        => $"{name.FathersSurname} {name.FirstName} {name.SecondName}",
                    AmericanName aname when aname.SecondName is null 
                        => $"{name.FirstName} {name.FathersSurname}",
                    AmericanName aname
                        => $"{name.FirstName} {name.SecondName.Substring(0, 1)}. {name.FathersSurname}",
                    FilipinoName fname when fname.SecondName is null && fname.MothersSurname is null
                        => $"{name.FirstName} {name.FathersSurname}",
                    FilipinoName fname when fname.SecondName is null && !(fname.MothersSurname is null)
                        => $"{name.FirstName} {name.MothersSurname.Substring(0,1)}. {name.FathersSurname}",
                    FilipinoName fname
                        => $"{name.FirstName} {name.SecondName} {name.MothersSurname.Substring(0, 1)}. {name.FathersSurname}",
                    _ => $"no match"
                };
        }

        private static void PatternMatchingTuplePatterns()
        {
            Console.WriteLine("Pattern Matching - Tuple Patterns");

            Console.WriteLine($"rock, paper: {RockPaperScissorsTuplePatterns("rock", "paper")}");
            Console.WriteLine($"rock, rock: {RockPaperScissorsTuplePatterns("rock", "rock")}");
            Console.WriteLine($"rock, scissors: {RockPaperScissorsTuplePatterns("rock", "scissors")}");
            Console.WriteLine($"scissors, paper: {RockPaperScissorsTuplePatterns("scissors", "paper")}");
            Console.WriteLine($"bato, papel: {RockPaperScissorsTuplePatterns("bato", "papel")}");

            static string RockPaperScissorsTuplePatterns(string first, string second)
                => (first, second) switch
                {
                    ("rock", "paper") => "rock is covered by paper. Paper wins.",
                    ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                    ("paper", "rock") => "paper covers rock. Paper wins.",
                    ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                    ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                    ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                    (_, _) when first != second => "no match",
                    (_, _) => "tie"
                };
        }

        private static void PatternMatchingPositionalPatterns()
        {
            Console.WriteLine("Pattern Matching - Positional Patterns");

            Console.WriteLine($"Point (0, 0): {GetQuadrant(new Point(0, 0))}");
            Console.WriteLine($"Point (1, 1): {GetQuadrant(new Point(1, 1))}");
            Console.WriteLine($"Point (1, -1): {GetQuadrant(new Point(1, -1))}");
            Console.WriteLine($"Point (-1, 1): {GetQuadrant(new Point(-1, 1))}");
            Console.WriteLine($"Point (-1, -1): {GetQuadrant(new Point(-1, -1))}");
            Console.WriteLine($"Point (0, 1): {GetQuadrant(new Point(0, 1))}");
            Console.WriteLine($"Point (1, 0): {GetQuadrant(new Point(1, 0))}");

            static Quadrant GetQuadrant(Point point) => 
                point switch
                {
                    (0, 0) => Quadrant.Origin,
                    var (x, y) when x > 0 && y > 0 => Quadrant.One,
                    var (x, y) when x < 0 && y > 0 => Quadrant.Two,
                    var (x, y) when x < 0 && y < 0 => Quadrant.Three,
                    var (x, y) when x > 0 && y < 0 => Quadrant.Four,
                    (_,_) => Quadrant.OnBorder,
                    _ => Quadrant.Unknown
                };
        }

        public static void NullableReferenceTypes()
        {
            Console.WriteLine("Nullable Reference Types");

            Customer newCustomer = new Customer("non nullable", null);
            Console.WriteLine($"Firstname: {newCustomer.FirstName}");
            Console.WriteLine($"LastName: {newCustomer.LastName}");
        }

        private static void End_Feature()
        {
            Console.WriteLine();
            Console.WriteLine("=============");
            Console.WriteLine();
        }
    }
}
