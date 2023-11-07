/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
        const int ArraySize = 10;
        const int RandomMinValue = -10;
        const int RandomMaxValue = 10;

        static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            // feel free to add your code

            var firstTask = Task.Factory.StartNew(() =>
            {
                var array = new int[ArraySize];
                var random = new Random();

                for (int i = 0; i < ArraySize; i++)
                {
                    array[i] = random.Next(RandomMinValue, RandomMaxValue);
                }

                Console.WriteLine("1st: ");
                OutputArray(array);

                return array;
            });

            var secondTask = firstTask.ContinueWith(previousTask =>
            {
                var array = previousTask.Result;

                var random = new Random();
                var coeff = random.Next(RandomMinValue, RandomMaxValue);

                Console.WriteLine("2nd: multiply by " + coeff);
                var multipliedArray = array.Select(x => x * coeff).ToArray();

                OutputArray(multipliedArray);
                return multipliedArray;
            });

            var thirdTask = secondTask.ContinueWith(previousTask =>
            {
                var array = previousTask.Result;

                Console.WriteLine("3rd:");
                var resultArray = array.OrderBy(x => x).ToArray();

                OutputArray(resultArray);
                return resultArray;
            });

            var fourthTask = thirdTask.ContinueWith(previousTask =>
            {
                var array = previousTask.Result;

                Console.WriteLine("4th:");
                Console.WriteLine("Average: " + array.Average(x => x));
            });

            fourthTask.Wait();

            Console.ReadLine();
        }

        static void OutputArray(int[] array)
        {
            Console.WriteLine(string.Join("\t", array));
        }
    }
}
