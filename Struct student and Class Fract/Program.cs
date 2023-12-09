using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laba3
{
    class Program
    {
        static void Main(string[] args)
        {
        savepoint:
            Console.WriteLine("Chouse Block: ");
            Console.WriteLine("1 - Block 1;");
            Console.WriteLine("2 - Block 2;");
            Console.WriteLine("0 - Exit.");
            int key;
            do
            {
                key = Int32.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1: Block1.Main1(); Console.WriteLine("\n\nDone!\n"); goto savepoint;
                    case 2: Block2.Main2(); Console.WriteLine("\n\nDone!\n"); goto savepoint;
                    default: break;
                }

            } while (key != 0);
        }
    }
}
