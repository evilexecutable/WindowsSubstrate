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
        //Import the user32.dll at the correct function and make
        //the function public.
        [DllImport("user32.dll", EntryPoint = "SetWindowText", CharSet = CharSet.Ansi)]
        public static extern int SetWindowText(IntPtr hWnd, String text);

        public void ChangeWindowTitle(String ProcessName, String NewTitle)
        {
            //Get the chosen process and see if it exists.
            Process[] ChosenProcesses = Process.GetProcessesByName(ProcessName);
            if (ChosenProcesses.Length > 0)
            {
                //Call the function we imported earlier.
                SetWindowText(ChosenProcesses[0].MainWindowHandle, NewTitle);
                Console.WriteLine("Process " + ProcessName + " title changed to " + NewTitle);
            } else
            {
                Console.WriteLine("Process not found.");
            }
        }
    }
}
