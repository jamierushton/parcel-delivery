using System;
using ParcelDelivery.ConsoleApp.Abstractions;

namespace ParcelDelivery.ConsoleApp
{
    public sealed class ConsoleImpl : IConsole
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }
    }
}