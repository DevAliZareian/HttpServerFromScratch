using System;

namespace HttpServer.Utils
{
    public static class Logger
    {
        private static readonly object _lock = new object();

        public static void Info(string message)
        {
            Log("INFO", message, ConsoleColor.White);
        }

        public static void Debug(string message)
        {
            Log("DEBUG", message, ConsoleColor.Gray);
        }

        public static void Warning(string message, string? clientIp = null)
        {
            Log(clientIp != null ? clientIp : "WARN", message, ConsoleColor.Yellow);
        }

        public static void Error(string message, string? clientIp = null)
        {
            Log(clientIp != null ? clientIp : "ERROR", message, ConsoleColor.Red);
        }

        private static void Log(string level, string message, ConsoleColor color)
        {
            lock (_lock)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}");
                Console.ResetColor();
            }
        }
    }
}