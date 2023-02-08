using System;
using UnityEngine;

internal class Program : MonoBehaviour
{
        static void Main(string[] args)
        {
            Console.WriteLine("WFC Generator");
            
            Generator gen = new Generator(50, 20);
            gen.PeformWFC();
        }
    }
