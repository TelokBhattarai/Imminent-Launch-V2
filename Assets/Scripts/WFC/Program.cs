using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WFC Generator");
            
            Generator gen = new Generator(50, 20);
            gen.PeformWFC();
        }
    }
