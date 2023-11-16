namespace Common.Models
{
    public class MessagePartialContent
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public int ChunkSize { get; set; }

        public int Position { get; set; }

        public MessagePartialContent(string filename, byte[] content, int chunkSize, int position)
        {
            FileName = filename;
            Content = content;
            ChunkSize = chunkSize;
            Position = position;
        }
    }
}
