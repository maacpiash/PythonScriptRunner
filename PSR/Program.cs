using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace PSR
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // string x = Environment.GetEnvironmentVariable("python");
                // DirectoryInfo info = new DirectoryInfo(".");
                string PythonPath = GetPythonPath();

                if (PythonPath == "ERROR")
                {
                    Console.WriteLine("Python is not installed, or is not added system variables");
                    return;
                }

                string arg = args[0];
                string prog = PythonPath;
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = "/C " + PythonPath + " " + args[0],
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                Console.WriteLine("FileName: " + psi.FileName);
                Console.WriteLine("Arguments: " + psi.Arguments);
                Process process = Process.Start(psi);
                //process.WaitForExit();
                //Console.ReadLine();
                //Console.ReadKey();
            }
            catch (Exception x) { Console.WriteLine("ERROR : " + x.ToString()); }
            
        }

        static string GetPythonPath()
        {
            var environmentVariables = Environment.GetEnvironmentVariables();
            string pathVariable = environmentVariables["Path"] as string;
            if (pathVariable != null)
            {
                string[] allPaths = pathVariable.Split(';');
                foreach (var path in allPaths)
                {
                    string pythonPathFromEnv = Path.Combine(path, "python.exe");
                    if (File.Exists(pythonPathFromEnv))
                        return pythonPathFromEnv;
                }
            }
            return "ERROR";
        }
    }
    
}