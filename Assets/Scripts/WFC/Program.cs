using System;
using UnityEngine;

public class Program : MonoBehaviour
{
        void Start()
        {
            Console.WriteLine("WFC Generator");
            
            Generator gen = new Generator(50, 20);
            gen.PerformWFC();
        }
    }
