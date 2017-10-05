using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperFunctions
{
    public class Program
    {

        static void TesztNetworkDriveMap()
        {
            NetworkDriveMap networdrivehandler = new NetworkDriveMap();

            ErrorHandler ErrorHND = new ErrorHandler();            
            Console.WriteLine("Try to map K: drive.");
            uint connectResult = networdrivehandler.MapNetworkDrive("K:", "\\\\192.168.204.37\\trint", "delog\\backupuser", "8761234502.nagy-obb");
            if (connectResult > 0)
            {
                Console.WriteLine(ErrorHND.ErrorHandlerByNumber(int.Parse(connectResult.ToString())) + ". Error Number: " + connectResult.ToString());
            }
            else
            {
                Console.WriteLine("Sikeres csatlakoztatás");
            }
            Console.WriteLine();
            Console.WriteLine("Meghajtó lecsatolása.");
            uint disconnectResult = networdrivehandler.DisconnectNetworkDrive("K:");

            if (disconnectResult > 0)
            {
                Console.WriteLine(ErrorHND.ErrorHandlerByNumber(int.Parse(disconnectResult.ToString())) + ". Error Number: " + disconnectResult.ToString());
            }
            else
            {
                Console.WriteLine("Kapcsolat sikeresen bontva.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {

            //Network drive map test
            TesztNetworkDriveMap();
            
            
        }
    }
}
