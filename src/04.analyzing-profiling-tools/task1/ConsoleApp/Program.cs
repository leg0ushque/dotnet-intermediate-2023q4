using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp
{
    internal class Program
    {
        public const int IterationsAmount = 10000;

        static void Main(string[] args)
        {
            var passwords = new List<string>
            {
                "123",
                $"{Guid.NewGuid()}",
                $"{Guid.NewGuid()}{Guid.NewGuid()}"
            };

            var salt = Guid.NewGuid().ToString();
            var saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);

            foreach(var pw in passwords)
            {
                Console.WriteLine($"Password: {pw}");
                Console.WriteLine($"O {RunOriginalPasswordGeneration(pw, saltBytes)}");
                Console.WriteLine($"M {RunModifiedPasswordGeneration(pw, saltBytes)}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static TimeSpan RunOriginalPasswordGeneration(string password, byte[] saltBytes)
        {
            var sw = new Stopwatch();
            sw.Start();
            var originalResult = GeneratePasswordHashUsingSalt(password, saltBytes);
            sw.Stop();
            return sw.Elapsed;
        }

        public static TimeSpan RunModifiedPasswordGeneration(string password, byte[] saltBytes)
        {
            var sw = new Stopwatch();

            sw.Start();
            var originalResult = GeneratePasswordHashUsingSaltModified(password, saltBytes);
            sw.Stop();
            return sw.Elapsed;
        }

        public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, IterationsAmount);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            var passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }

        public static string GeneratePasswordHashUsingSaltModified(string passwordText, byte[] salt)
        {
            byte[] hash;

            using(var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, IterationsAmount))
            {
                hash = pbkdf2.GetBytes(20);
            }

            var hashStringBuilder = new StringBuilder();
            hashStringBuilder.Append(Convert.ToBase64String(salt));
            hashStringBuilder.Append(Convert.ToBase64String(hash));

            return hashStringBuilder.ToString();
        }
    }
}