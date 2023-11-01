using System.Collections.Generic;
using System;
using System.Linq;

namespace AsyncSocketChat.ChatServer
{
    public class Program
    {
        private static bool UseAsyncMode = true;

        private static List<string> ChatHistory = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Leave an empty input and press ENTER to run in SYNC mode, " +
                "or type something and press ENTER to run in ASYNC mode...");
            var mode = Console.ReadLine();
            UseAsyncMode = mode.Any();
            Console.WriteLine($"Server mode: {(UseAsyncMode ? "ASYNC" : "SYNC")}");
        }
    }
}
