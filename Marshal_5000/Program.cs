// See https://aka.ms/new-console-template for more information
// Assuming you have multiple console apps named App1, App2, and App3 etc.
// You can run them in order with the following code.

using System.Diagnostics;

Process process1 = new Process();
process1.StartInfo.FileName = "App1.exe";
process1.Start();
process1.WaitForExit();

Process process2 = new Process();
process2.StartInfo.FileName = "App2.exe";
process2.Start();
process2.WaitForExit();

Process process3 = new Process();
process3.StartInfo.FileName = "App3.exe";
process3.Start();
process3.WaitForExit();
Console.WriteLine("Hello, World!");
