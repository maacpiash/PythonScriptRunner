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
                string PythonPath = GetPythonPath();
                
                if (PythonPath == "ERROR")
                {
                    Console.WriteLine("Python is either not installed, or is not added system variables");
                    return;
                }

                string ScriptPath;
                
                try { ScriptPath = args[0]; }
                catch (IndexOutOfRangeException x) // There is still a chance to enter the file name, if not provided as a CLI argument.
                {
                    Console.Write("Please enter file name: ");
                    ScriptPath = Console.ReadLine();
                }

                Process p = Process.Start(PythonPath, ScriptPath);
                p.WaitForExit();
                
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