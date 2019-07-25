using System;
using System.Collections;
using System.Collections.Generic;

namespace _003.ArrayStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Stack<int>();
            s.Pop();
            var stack = new ArrayStack<int>();
            for (int i = 0; i < 25; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(stack.Peek());
            }

            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(stack.Pop());
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
