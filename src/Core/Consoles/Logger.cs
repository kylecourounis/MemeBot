namespace MemeBot.Core.Consoles
{
    using System;
    using System.Diagnostics;

    internal static class Logger
    {
        /// <summary>
        /// Logs the specified informative message.
        /// </summary>
        public static void Info(Type type, object message)
        {
            Logger.Log(type, message, LogType.Info);
        }

        /// <summary>
        /// Logs the specified debug message.
        /// </summary>
        [Conditional("DEBUG")]
        public static void Debug(Type type, object message)
        {
            Logger.Log(type, message, LogType.Debug);
        }

        /// <summary>
        /// Logs the specified warning message.
        /// </summary>
        [Conditional("DEBUG")]
        public static void Warning(Type type, object message)
        {
            Logger.Log(type, message, LogType.Warning);
        }

        /// <summary>
        /// Logs the specified error message.
        /// </summary>
        public static void Error(Type type, object message)
        {
            Logger.Log(type, message, LogType.Error);
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        private static void Log(Type type, object message, LogType logType)
        {
            string prefix = string.Empty;

            switch (logType)
            {
                case LogType.Info:
                {
                    prefix = "[ INFO  ]";
                    break;
                }
                default:
                {
                    prefix = $"[{logType.ToString().ToUpper().Pad(7)}]";
                    break;
                }
            }
            
            System.Diagnostics.Debug.WriteLine($"{prefix} {type.Name.Pad()} : {message}");
        }

        private enum LogType
        {
            Info,
            Debug,
            Warning,
            Error
        }
    }
}
