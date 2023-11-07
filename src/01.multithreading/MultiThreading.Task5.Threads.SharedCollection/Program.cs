/*
 * 5. Write a program which creates two threads and a shared collection:
 * the first one should add 10 elements into the collection and the second should print all elements
 * in the collection after each adding.
 * Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Task5.Threads.SharedCollection
{
    class Program
    {
        static object Locker = new object();

        const int ItemsAmount = 10;

        static List<int> items = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("5. Write a program which creates two threads and a shared collection:");
            Console.WriteLine("the first one should add 10 elements into the collection and the second should print all elements in the collection after each adding.");
            Console.WriteLine("Use Thread, ThreadPool or Task classes for thread creation and any kind of synchronization constructions.");
            Console.WriteLine();

            var addingTask = Task.Run(() => AddElements());
            var printingTask = Task.Run(() => PrintList());

            Task.WaitAll(addingTask, printingTask);

            Console.ReadLine();
        }

        public static void AddElements()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (Locker)
                {
                    items.Add(i);
                    Monitor.Pulse(Locker);
                }

                Thread.Sleep(500);
            }
        }

        public static void PrintList()
        {
            while (items.Count < ItemsAmount)
            {
                lock (Locker)
                {
                    Monitor.Wait(Locker);

                    Console.WriteLine(string.Join(", ", items));
                }
            }
        }
    }
}
