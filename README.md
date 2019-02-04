# Windows Substrate
Windows process and memory hacking framework developed in C#

# Installation
1. Clone the repository and compile the DLL.
2. Create a new C# console project and reference the WindowsSubstrate.dll.

# Features
Currently only 2 methods exist
1. Change the title of a window with the "ChangeWindowTitle" method
2. Get the base address of a process with "GetBaseAddress".

# Notes
Expect rapid development. Eventually this will become a full hacking framework for Windows.
Please feel free to clone/send pull requests.

# Example Usage
>Get the base address of a process in Int format. Run it over ToString("X") to get the hex value.

```using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSubstrate;

namespace SubstrateProcessPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var Hack = new Substrate();
            Int64 baseaddr = Hack.GetBaseAddress("Steam");
            Console.WriteLine(baseaddr);
            Console.Read();
        }
    }
}
```
