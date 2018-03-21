using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace PythonScriptRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ScriptPath; // The python script file
                
                try { ScriptPath = args[0]; }
                catch (IndexOutOfRangeException x) // There is still a chance to enter the file name, if not provided as a CLI argument.
                {
                    Console.WriteLine(x.GetType().ToString());
                    Console.Write("You must enter a file name: ");
                    ScriptPath = Console.ReadLine();
                }
                if(!File.Exists(ScriptPath))
                {
                    Console.WriteLine("ERROR: File not found!");
                    Environment.Exit(-1);
                }
                
                string PythonPath = GetPythonPath(); // The python program file

                if (PythonPath == "ERROR")
                {
                    Console.WriteLine("Python is either not installed, or is not added system variables");
                    Environment.Exit(-2);
                }

                Console.WriteLine("\n*** Python Script Begins! ***\n");
                Process p = Process.Start(PythonPath, ScriptPath);
                p.WaitForExit();
                Console.WriteLine("\n*** End of script : The Dot Net Rises!! ***\n");
                
                // Console.ReadKey();
            }
            catch (Exception x) { Console.WriteLine("ERROR : " + x.ToString()); }
            
        }

        static string GetPythonPath()
        {
            if(Environment.OSVersion.ToString().Contains("Unix"))
                return "python";

            var environmentVariables = Environment.GetEnvironmentVariables();
            string pathVariable = environmentVariables["Path"] as string;
            if (pathVariable != null)
            {
                string[] allPaths = pathVariable.Split(';');
                foreach (var path in allPaths)
                {
                    string pythonPathFromEnv;
                    if(Environment.OSVersion.ToString().Contains("Unix"))
                        pythonPathFromEnv = Path.Combine(path, "python.exe");
                    else
                        pythonPathFromEnv = Path.Combine(path, "python");
                    if (File.Exists(pythonPathFromEnv))
                        return pythonPathFromEnv;
                }
            }
            return "ERROR";
        }
    }
    
}