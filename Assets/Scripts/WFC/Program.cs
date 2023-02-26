using System;
using UnityEngine;

public class Program : MonoBehaviour
{
        void Start()
        {
            Debug.Log("WFC Generator");
            
            Generator gen = new Generator(10, 10);
            gen.PerformWFC();
        }
    }
