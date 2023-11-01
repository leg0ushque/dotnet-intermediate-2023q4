using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace AsyncSocketChat.ChatClient
{
    internal class Program
    {
        private static Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static string UserName;

        private static List<string> Messages = new List<string>
        {
            "Hello, everyone!",
            "I am a newbie here, is there anyone who can help?",
            "I have a wonderful weather today, what about you all?",
            "How's it going, bros? Hope you're all ok",
            "The early bird catches the worm.",
            "Actions speak louder than words.",
            "A picture is worth a thousand words.",
            "A stitch in time saves nine.",
            "Beauty is in the eye of the beholder.",
            "Birds of a feather flock together.",
            "Don't count your chickens before they hatch.",
            "Fortune favors the bold.",
            "Great minds think alike.",
            "Rome wasn't built in a day.",
        };

        static void Main(string[] args)
        {
            Console.WriteLine("What is your client name?");
            UserName = Console.ReadLine();
        }
    }
}
