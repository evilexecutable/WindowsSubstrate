# Windows Substrate
Windows process and memory hacking framework developed in C#

#Installation
1. Clone the repository and compile the DLL.
2. Create a new C# console project and reference the WindowsSubstrate.dll.

#Example Usage

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
