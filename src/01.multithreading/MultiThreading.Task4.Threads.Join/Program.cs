/*
 * 4.	Write a program which recursively creates 10 threads.
 * Each thread should be with the same body and receive a state with integer number, decrement it,
 * print and pass as a state into the newly created thread.
 * Use Thread class for this task and Join for waiting threads.
 *
 * Implement all of the following options:
 * - a) Use Thread class for this task and Join for waiting threads.
 * - b) ThreadPool class for this task and Semaphore for waiting threads.
 */

using System;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join
{
    class Program
    {
        static readonly Semaphore Semaphore = new Semaphore(0, 1);

        static void Main(string[] args)
        {
            Console.WriteLine("4.	Write a program which recursively creates 10 threads.");
            Console.WriteLine("Each thread should be with the same body and receive a state with integer number, decrement it, print and pass as a state into the newly created thread.");
            Console.WriteLine("Implement all of the following options:");
            Console.WriteLine();


            Console.WriteLine("- a) Use Thread class for this task and Join for waiting threads.");

            int initialState = 10;
            Thread thread = new Thread(ThreadBody);
            thread.Start(initialState);
            thread.Join();

            Console.WriteLine();
            Console.WriteLine("- b) ThreadPool class for this task and Semaphore for waiting threads.");

            initialState = 10;
            ThreadPool.QueueUserWorkItem(ThreadBody, initialState);

            Console.ReadLine();
        }

        static void ThreadBody(object state)
        {
            int currentState = (int)state;
            Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}. Current state: " + currentState);

            currentState--;

            if (currentState > 0)
            {
                Thread newThread = new Thread(ThreadBody);
                newThread.Start(currentState);
                newThread.Join();
            }
        }

        static void SemaphoreThreadBody(object state)
        {
            Semaphore.WaitOne();

            int currentState = (int)state;
            Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}. Current state: " + currentState);

            currentState--;

            if (currentState > 0)
            {
                ThreadPool.QueueUserWorkItem(SemaphoreThreadBody, currentState);
            }

            Semaphore.Release();
        }
    }
}
