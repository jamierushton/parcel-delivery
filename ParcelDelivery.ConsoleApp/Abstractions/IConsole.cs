using System;

namespace ParcelDelivery.ConsoleApp.Abstractions
{
    public interface IConsole
    {
        void WriteLine(string value);
        ConsoleKeyInfo ReadKey(bool intercept);
    }
}