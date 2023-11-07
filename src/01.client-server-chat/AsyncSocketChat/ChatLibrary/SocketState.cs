using System.Net.Sockets;

namespace AsyncSocketChat.ChatLibrary
{
    public class SocketState
    {
        public SocketState(Socket socket, byte[] buffer)
        {
            Socket = socket;
            Buffer = buffer;
        }

        public Socket Socket { get; set; }
        public byte[] Buffer { get; set; }
    }
}
