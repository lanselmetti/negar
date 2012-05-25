using System;

namespace DotNetRemoting
{
    static class Program
    {
        public static string[] _args;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            _args = args;
            new InstForm();
            Console.Beep();
        }
    }
}