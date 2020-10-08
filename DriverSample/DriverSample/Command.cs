using System;

namespace DriverSample
{
    class DriverCommand
    {
        private static readonly char PACKET_SEP = ':';
        private readonly char PARAMS_SEP = ',';
        private string fCommand;
        private string[] fParams;

        public DriverCommand(string command)
        {
            var parseArr = command.Split(PACKET_SEP);
            if (parseArr.Length == 3)
            {
                fCommand = parseArr[0].Substring(1, parseArr[0].Length - 1);
                fParams = parseArr[1].Split(PARAMS_SEP);
                Execute();
            }
        }

        public void Execute()
        {
            Console.WriteLine();
            switch (fCommand)
            {
                case "T":
                {
                    Console.WriteLine($"ACK {fCommand}:{fParams[0]} --> writing '{fParams[0]}'");
                    break;
                }

                case "S":
                {
                    Console.WriteLine($"ACK {fCommand}:{fParams[0]},{fParams[1]} --> playing sound ");
                    int freq;
                    int duration;
                    if (!Int32.TryParse(fParams[0], out freq))
                    {
                        Console.WriteLine($"Unable to parse freq: {fParams[0]}");
                        return;
                    }

                    if (!Int32.TryParse(fParams[1], out duration))
                    {
                        Console.WriteLine($"Unable to parse duration: {fParams[1]}");
                        return;
                    }

                    Console.Beep(freq, duration);
                    break;
                }

                default:
                {
                    Console.WriteLine($"NACK {fCommand}:");
                    for (int i = 0; i < fParams.Length; i++)
                    {
                        if (i == 0)
                        {
                            Console.Write($"{fParams[i]}");
                        }
                        else
                        {
                            Console.Write($",{fParams[i]}");
                        }
                    }
                    break;
                }
            }
        }
    }
}