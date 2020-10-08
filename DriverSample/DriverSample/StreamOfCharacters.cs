using System.Collections.Generic;

namespace DriverSample
{
    class StreamOfCharacters
    {
        private static readonly byte FIRST_ASCII = 32;
        private static readonly byte LAST_ASCII = 127;
        public static readonly char PACKET_START = 'P';
        public static readonly char PACKET_END = 'E';
        private List<char> fStream;

        private bool Validate(char key)
        {
            return (((byte) key >= FIRST_ASCII) && ((byte) key <= LAST_ASCII));
        }

        public StreamOfCharacters()
        {
            fStream = new List<char>();
        }

        public void Add(char key)
        {
            string command;
            if (Validate(key))
            {
                fStream.Add(key);
                command = GetCommand();
                if (!string.IsNullOrEmpty(command))
                {
                    fStream.Clear();
                    var driverCommand = new DriverCommand(command);
                    //Console.WriteLine($">>>{command}");
                }
            }
        }

        public string GetCommand()
        {
            string result = string.Empty;
            if (fStream.Contains(PACKET_START) && fStream.Contains(PACKET_END))
            {
                int startIndex = 0;
                int endIndex = 0;

                for(int i=0;i<fStream.Count;i++)
                {
                    if (fStream[i] == PACKET_START)
                    {
                        startIndex = i;
                    }

                    if (fStream[i] == PACKET_END)
                    {
                        endIndex = i;
                    }
                }

                for (int i = startIndex; i <= endIndex; i++)
                {
                    result += fStream[i];
                }
            }

            return result;
        }

    }
}