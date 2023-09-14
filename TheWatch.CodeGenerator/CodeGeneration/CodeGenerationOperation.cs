
using System;
using System.Diagnostics;

namespace TheWatch.CodeGenerator.CodeGeneration
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A code generation operation. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class CodeGenerationOperation
    {
        /// <summary>   (Immutable) full pathname of the swagger file. </summary>
        private readonly string _swaggerFilePath;
        /// <summary>   (Immutable) pathname of the output directory. </summary>
        private readonly string _outputDirectory;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public CodeGenerationOperation()
        {
            // Absolute path to the swagger.json file in TheWatch.Shared
            _swaggerFilePath = @"B:\Elven\Fireline\ConsoleApp1\England\England.Blazor.United\TheWatch\TheWatch\TheWatch.Shared\OpenAPIs\swagger.json";

            // Absolute path to the output directory in TheWatch.CodeGenerator
            _outputDirectory = @"B:\Elven\Fireline\ConsoleApp1\England\England.Blazor.United\TheWatch\TheWatch.CodeGenerator\GeneratedCode\";
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Generates a code. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public void GenerateCode()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "openapi-generator",
                Arguments = $"generate -i {_swaggerFilePath} -g aspnetcore -o {_outputDirectory}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = startInfo };
            process.Start();

            while (!process.StandardOutput.EndOfStream && process != null)
            {
                string? line = process.StandardOutput.ReadLine() ?? "";
                Console.WriteLine(line);
            }

            process.WaitForExit();
        }
    }
}
