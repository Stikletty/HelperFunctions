using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace HelperFunctions
{
    class NetworkDriveMap
    {

        //Source: http://www.blackwasp.co.uk/mapdriveletter.aspx

        // This must be used if NETRESOURCE is defined as a struct
        [DllImport("mpr.dll")]
        public static extern uint WNetAddConnection2(ref NETRESOURCE netResource,
           string password, string username, uint flags);

        // This must be used if NETRESOURCE is defined as a class
        [DllImport("mpr.dll")]
        public static extern uint WNetAddConnection2(NETRESOURCE netResource,
           string password, string username, uint flags);
        
        //Removing drive letter
        [DllImport("mpr.dll")]
        static extern uint WNetCancelConnection2(string lpName, uint dwFlags, bool bForce);

        [StructLayout(LayoutKind.Sequential)]
        public struct NETRESOURCE
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            public string lpLocalName;
            public string lpRemoteName;
            public string lpComment;
            public string lpProvider;
        }

        const uint RESOURCETYPE_DISK = 1;

        
        /*  Connection flags
         *  ================
         *  Flag Name	            Value	 Description
         *  CONNECT_UPDATE_PROFILE	0x1	     If this flag is set, the operating system is instructed to remember the mapping of the drive letter in the user's profile. This means that if the user logs off, when they log on again at a later date, an attempt to restore the connection will be made.
         *  CONNECT_INTERACTIVE	    0x8	     When this flag is set, the operating system is permitted to ask the user for authentication information before attempting to map the drive letter.
         *  CONNECT_PROMPT	        0x10	 When set, this flag indicates that any default user name and password credentials will not be used without first giving the user the opportunity to override them. This flag is ignored if CONNECT_INTERACTIVE is not also specified.
         *  CONNECT_REDIRECT        0x80 	 This flag forces the redirection of a local device when making the connection. For the functionality described in this article the flag has no effect. It is included here for completeness.
         *  CONNECT_COMMANDLINE     0x800	 This flag indicates that if the operating system needs to ask for a user name and password, it should do so using the command line rather than by using dialog boxes. This flag is ignored if CONNECT_INTERACTIVE is not also specified. It is not available to Windows 2000 or earlier versions of the operating system.
         *  CONNECT_CMD_SAVECRED	0x1000	 If set, this flag specifies that any credentials entered by the user will be saved. If it is not possible to save the credentials or the CONNECT_INTERACTIVE is not also specified then the flag is ignored.
         */
        const uint CONNECT_UPDATE_PROFILE = 0x1;
        const uint CONNECT_INTERACTIVE = 0x8;
        const uint CONNECT_PROMPT = 0x10;
        const uint CONNECT_REDIRECT = 0x80;
        const uint CONNECT_COMMANDLINE = 0x800;
        const uint CONNECT_CMD_SAVECRED = 0x1000;

      

        public uint MapNetworkDrive(string pDriveLetter, string pRemoteName, string pUserName, string pPassword)
        {
            //Error handler            
            //example: result = WNetAddConnection2(ref lpNetResource, lpPassword, lpUserName, dwFlags);
            NETRESOURCE networkResource = new NETRESOURCE();
            networkResource.dwType = RESOURCETYPE_DISK;
            networkResource.lpLocalName = pDriveLetter;
            networkResource.lpRemoteName = pRemoteName;
            networkResource.lpProvider = null;
            uint flags = CONNECT_CMD_SAVECRED | CONNECT_UPDATE_PROFILE;

            //DEBUG
            //Console.WriteLine("Parameters: " + pDriveLetter + ", " + pRemoteName + ", " + pUserName + ", " + pPassword);

            uint result = WNetAddConnection2(ref networkResource, pPassword, pUserName, flags);

            return result;
        }

        public uint DisconnectNetworkDrive(string pDriveLetter)
        {
            //Error handler
            ErrorHandler ErrorHND = new ErrorHandler();
            uint result = WNetCancelConnection2(pDriveLetter, CONNECT_UPDATE_PROFILE, false);
            return result;

        }

    }
}
