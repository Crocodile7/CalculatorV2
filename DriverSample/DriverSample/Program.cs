using System;

namespace DriverSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo; //The key, pressed  from the keyboard
            var streamOfCharacters = new StreamOfCharacters();
            do
            {
                keyInfo = Console.ReadKey();
                streamOfCharacters.Add(keyInfo.KeyChar);
            }
            while (keyInfo.Key != ConsoleKey.Escape); //use ESC as exit

        }
    }
}
