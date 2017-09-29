using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkDriveMap networdrivehandler = new NetworkDriveMap();

            Console.WriteLine("Try to map K: drive.");
            Console.WriteLine(networdrivehandler.MapNetworkDrive("K:", "\\\\192.168.204.37\\trint", "delog\\backupuser", "8761234502.nagy-obb"));
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
