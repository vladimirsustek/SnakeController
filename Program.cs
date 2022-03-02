using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace SnakeController
{
    internal class Program
    {
        static SerialPort port = new SerialPort();
        static void Main(string[] args)
        {
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("Program automatically opens port, may send W A S D P to console, ESC closes port and quits");
            port.PortName = ports[0];
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 57600;

            try
            {
                port.Open();
                Console.WriteLine("Port Opened: " + port.PortName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            ReadKey();
        }
        private static void ReadKey()
        {
            ConsoleKey key;
            do
            {
                while (!Console.KeyAvailable) ;

                key = Console.ReadKey(true).Key;

                if(key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D || key == ConsoleKey.P || key == ConsoleKey.Q || key == ConsoleKey.R)
                {
                    port.Write(key.ToString());
                }

            } while (key != ConsoleKey.Escape);

            try
            {
                port.Close();
                Console.WriteLine("Port Closed: " + port.PortName);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Thread.Sleep(1000);
            }
        }

    }
}
