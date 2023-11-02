namespace AsyncSocketChat.ChatLibrary
{
    public static class Constants
    {
        public const string IP = "127.0.0.1";
        public const int PORT = 5000;

        public const int MAX_CLIENT_CONNECTIONS = 10;

        public const int STORED_MESSAGES_MAX_AMOUNT = 10;

        //An array of Byte that is the storage location for the received data
        public const int DEFAULT_BUFFER_ARRAY_SIZE = 1024;

        // The number of bytes to send/receive
        public const int DEFAULT_BYTES_SIZE = 1024;

        // The location in buffer to store the received data
        public const int DEFAULT_OFFSET = 0;

        public const int FIRST_MESSAGE_INDEX = 0;
    }
}
