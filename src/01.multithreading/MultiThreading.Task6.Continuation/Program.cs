/*
*  Create a Task and attach continuations to it according to the following criteria:
   a.    Continuation task should be executed regardless of the result of the parent task.
   b.    Continuation task should be executed when the parent task finished without success.
   c.    Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation
   d.    Continuation task should be executed outside of the thread pool when the parent task would be cancelled
   Demonstrate the work of the each case with console utility.
*/
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Task6.Continuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a Task and attach continuations to it according to the following criteria:");
            Console.WriteLine("a.    Continuation task should be executed regardless of the result of the parent task.");
            Console.WriteLine("b.    Continuation task should be executed when the parent task finished without success.");
            Console.WriteLine("c.    Continuation task should be executed when the parent task would be finished with fail and parent task thread should be reused for continuation.");
            Console.WriteLine("d.    Continuation task should be executed outside of the thread pool when the parent task would be cancelled.");
            Console.WriteLine("Demonstrate the work of the each case with console utility.");
            Console.WriteLine();

            Console.WriteLine("Please, choose what the parent task should do:");
            Console.WriteLine("1. Run to completion");
            Console.WriteLine("2. Fail with an exception");
            Console.WriteLine("3. Cancel during execution");
            var option = Console.ReadLine();

            var cts = new CancellationTokenSource();

            Task parentTask = Task.Run(() =>
            {
                Console.WriteLine("Parent task started");

                if (option == "2")
                {
                    throw new InvalidOperationException("Parent task failed");
                }

                Thread.Sleep(1000);

                if (option == "3")
                {
                    cts.Cancel();
                    Console.WriteLine("Cancellation token used!");
                }

                cts.Token.ThrowIfCancellationRequested();

                Console.WriteLine("Parent task completed");
            }, cts.Token);

            parentTask.ContinueWith(task => Console.WriteLine("Continuation task A executed"));

            // b. Continuation task should be executed when the parent task finished without success.
            parentTask.ContinueWith(
                task => Console.WriteLine("Continuation task B executed (no fail & no cancellation)"),
                TaskContinuationOptions.OnlyOnRanToCompletion
            );

            // c. Continuation task should be executed when the parent task would be finished
            // with fail and parent task thread should be reused for continuation
            parentTask.ContinueWith(
                task => Console.WriteLine("Continuation task C executed (on fail)"),
                TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously
            );

            // d. Continuation task should be executed outside of the thread pool when the parent task would be cancelled
            parentTask.ContinueWith(
                task => { Console.WriteLine("Continuation task D executed (on cancel)"); },
                TaskContinuationOptions.OnlyOnCanceled | TaskContinuationOptions.LongRunning
            );

            try
            {
                parentTask.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("There is an exception thrown during parent task execution: " + ex.InnerException?.Message);
            }

            Console.ReadLine();
        }
    }
}
