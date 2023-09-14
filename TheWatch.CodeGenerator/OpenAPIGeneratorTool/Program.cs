//using System;
//using System.Diagnostics;

//namespace TheWatch.CodeGenerator
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var swaggerFilePath = @"..\TheWatch.Shared\OpenAPIs\swagger.json"; // Update with the exact filename if it's different
//            var outputDirectory = @"..\TheWatch.Shared\GeneratedCode";  // Adjust as needed for your desired output directory

//            GenerateAspNetCoreCode(swaggerFilePath, outputDirectory);
//        }

//        static void GenerateAspNetCoreCode(string swaggerFilePath, string outputDirectory)
//        {
//            var startInfo = new ProcessStartInfo
//            {
//                FileName = "openapi-generator",
//                Arguments = $"generate -i {swaggerFilePath} -g aspnetcore -o {outputDirectory}",
//                RedirectStandardOutput = true,
//                UseShellExecute = false,
//                CreateNoWindow = true
//            };

//            using var process = new Process { StartInfo = startInfo };
//            process.Start();

//            while (!process.StandardOutput.EndOfStream)
//            {
//                string line = process.StandardOutput.ReadLine();
//                Console.WriteLine(line);
//            }

//            process.WaitForExit();
//        }
//    }
//}
