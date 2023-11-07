using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using AsyncSocketChat.ChatLibrary;

namespace AsyncSocketChat.ChatServer
{
    public class Program
    {
        private static bool UseAsyncMode = true;

        private static Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static Dictionary<Socket, string> ClientSockets = new Dictionary<Socket, string>();

        private static List<string> ChatHistory = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Leave an empty input and press ENTER to run in SYNC mode, " +
                "or type something and press ENTER to run in ASYNC mode...");
            var mode = Console.ReadLine();
            UseAsyncMode = mode.Any();
            Console.WriteLine($"Server mode: {(UseAsyncMode ? "ASYNC" : "SYNC")}");

            Console.Title = "Chat Server";
            SetupServer();
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadLine();
            CloseConnections();
        }

        private static void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            ServerSocket.Bind(new IPEndPoint(IPAddress.Parse(Constants.IP), Constants.PORT));
            ServerSocket.Listen(Constants.MAX_CLIENT_CONNECTIONS);

            if (UseAsyncMode)
            {
                ServerSocket.BeginAccept(new AsyncCallback(AcceptCallbackAsync), null);
            }
            else
            {
                AcceptCallbackSync();
            }

            Console.WriteLine("Server is set up and running");
        }

        private static void AcceptCallbackAsync(IAsyncResult ar)
        {
            var socket = ServerSocket.EndAccept(ar);
            ServerSocket.BeginAccept(new AsyncCallback(AcceptCallbackAsync), null);

            var state = new SocketState(socket, new byte[Constants.DEFAULT_BUFFER_ARRAY_SIZE]);

            socket.BeginReceive(state.Buffer,
                Constants.DEFAULT_OFFSET,
                Constants.DEFAULT_BYTES_SIZE,
                SocketFlags.None,
                new AsyncCallback(ReceiveCallbackAsync),
                state);
        }

        private static void AcceptCallbackSync()
        {
            while (true)
            {
                var socket = ServerSocket.Accept();
                var receiveThread = new Thread(() => ReceiveCallbackSync(socket));
                receiveThread.Start();
            }
        }

        private static void ReceiveCallbackAsync(IAsyncResult ar)
        {
            var state = ar.AsyncState as SocketState;
            var socket = state.Socket;
            int received;

            try
            {
                received = socket.EndReceive(ar);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Client forcefully disconnected");
                Console.WriteLine(ex.Message);

                if (ClientSockets.ContainsKey(socket))
                {
                    ClientSockets.Remove(socket);
                }
                socket.Close();
                return;
            }

            if (received == 0)
            {
                Console.WriteLine("Client disconnected");
                if (ClientSockets.ContainsKey(socket))
                {
                    ClientSockets.Remove(socket);
                }
                socket.Close();
                return;
            }

            var buffer = new byte[received];

            Array.Copy(state.Buffer, buffer, received);

            HandleClientMessage(socket, received, buffer);
            socket.BeginReceive(state.Buffer,
                Constants.DEFAULT_OFFSET,
                Constants.DEFAULT_BYTES_SIZE,
                SocketFlags.None,
                new AsyncCallback(ReceiveCallbackAsync),
                state);
        }

        private static void ReceiveCallbackSync(Socket socket)
        {
            var buffer = new byte[1024];
            int received;

            try
            {
                received = socket.Receive(buffer);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client forcefully disconnected");
                if (ClientSockets.ContainsKey(socket))
                {
                    ClientSockets.Remove(socket);
                }
                socket.Close();
                return;
            }

            if (received == 0)
            {
                Console.WriteLine("Client disconnected");
                if (ClientSockets.ContainsKey(socket))
                {
                    ClientSockets.Remove(socket);
                }
                socket.Close();
                return;
            }

            HandleClientMessage(socket, received, buffer);
        }

        private static void HandleClientMessage(Socket socket, int received, byte[] buffer)
        {
            var dataBuf = new byte[received];
            Array.Copy(buffer, dataBuf, received);
            var text = Encoding.ASCII.GetString(dataBuf);

            if (!ClientSockets.ContainsKey(socket))
            {
                ClientSockets[socket] = text;
                Console.WriteLine($"+{text}");
                SendChatHistory(socket);
            }
            else
            {
                Console.WriteLine("Received " + text);
                AddMessageToHistory($"[{ClientSockets[socket]}]: {text}");
                BroadcastToClients(text, socket);
            }
        }

        private static void SendChatHistory(Socket socket)
        {
            foreach (string message in ChatHistory)
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                socket.BeginSend(data,
                    Constants.DEFAULT_OFFSET,
                    data.Length,
                    SocketFlags.None,
                    new AsyncCallback(SendCallback),
                    socket);
            }
        }

        private static void BroadcastToClients(string message, Socket fromSocket)
        {
            var fromUser = ClientSockets[fromSocket] ?? "UnknownUser";

            foreach (var client in ClientSockets)
            {
                if (client.Key != fromSocket)
                {
                    string data = $"{fromUser}: {message}\n";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    client.Key.BeginSend(buffer,
                        Constants.DEFAULT_OFFSET,
                        buffer.Length,
                        SocketFlags.None,
                        new AsyncCallback(SendCallback),
                        client.Key);
                }
            }
        }

        private static void SendCallback(IAsyncResult asyncResult)
        {
            var socket = (Socket) asyncResult.AsyncState;
            socket.EndSend(asyncResult);
        }

        private static void AddMessageToHistory(string message)
        {
            if (ChatHistory.Count >= Constants.STORED_MESSAGES_MAX_AMOUNT)
            {
                ChatHistory.RemoveAt(Constants.FIRST_MESSAGE_INDEX);
            }

            ChatHistory.Add(message);
        }

        private static void CloseConnections()
        {
            Console.WriteLine("Closing connections...");

            foreach (var socket in ClientSockets.Keys)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            ServerSocket.Close();

            Console.WriteLine("Connections closed. Exiting.");
        }
    }
}
