using AsyncSocketChat.ChatLibrary;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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

            LoopConnect();

            try
            {
                SendLoop();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Loop stopped");
                Console.WriteLine(ex);
            }
        }

        public static void LoopConnect()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    ClientSocket.Connect(Constants.IP, Constants.PORT);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Connection attempts: " + attempts);
                }
            }

            Console.Clear();
            Console.WriteLine("Connected as " + UserName);
        }

        public static void SendLoop()
        {
            ClientSocket.Send(Encoding.ASCII.GetBytes(UserName));

            int sentMessages = 0;

            while (sentMessages < 6)
            {
                var random = new Random();
                var msg = Messages[random.Next(Messages.Count)];

                ReceiveMessages();

                // SEND
                var buffer = Encoding.ASCII.GetBytes(msg);
                Console.WriteLine($">> {msg}");
                ClientSocket.Send(buffer);
                sentMessages++;
                Thread.Sleep(2000);
            }

            Console.WriteLine("Disconnected");
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }

        private static void ReceiveMessages()
        {
            var receivedBuf = new byte[Constants.DEFAULT_BYTES_SIZE];
            int rec = ClientSocket.Receive(receivedBuf);
            byte[] data = new byte[rec];
            Array.Copy(receivedBuf, data, rec);
            Console.WriteLine("<< " + Encoding.ASCII.GetString(data));
        }
    }
}
