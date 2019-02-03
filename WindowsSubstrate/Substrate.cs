using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Diagnostics; //Needed for accessing Windows Processes.
using System.Runtime.InteropServices; //Needed for it's DLL Imports.

namespace WindowsSubstrate
{
    public class Substrate
    {
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            PROCESS_VM_READ = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            PROCESS_QUERY_INFORMATION = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }
        //Import the user32.dll at the correct function and make
        //the function public.
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern int SetWindowText(IntPtr hWnd, String text);
        //public static extern int WriteProcessMemory(IntPtr hProcess, String lpBaseAddress, String lpBuffer);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern int FindWindow(String ClassName, String WindowName);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern uint GetWindowThreadProcessId(int hWnd, IntPtr ProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        //Simple method for changing Window Title.
        public void ChangeWindowTitle(String ProcessName, String NewTitle)
        {
            //Get the chosen process and see if it exists.
            Process[] ChosenProcess = Process.GetProcessesByName(ProcessName);
            if (ChosenProcess.Length > 0)
            {
                //Call the function we imported earlier.
                SetWindowText(ChosenProcess[0].MainWindowHandle, NewTitle);
                Console.WriteLine("Process " + ProcessName + " title changed to " + NewTitle);
            } else
            {
                Console.WriteLine("Process not found.");
            }
        }

        //Get the passed process name and fetch its base address.
        public Int64 GetBaseAddress(string NewProcessName)
        {
            Process[] processes = System.Diagnostics.Process.GetProcessesByName(NewProcessName);
            Int64 baseAddr = processes[0].MainModule.BaseAddress.ToInt64();

            //Return the base address to the call as an 64bit Int.
            return baseAddr;
        }
    }
}
