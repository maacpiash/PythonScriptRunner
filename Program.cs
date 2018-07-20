using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

using static System.Console;

namespace PythonScriptRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ScriptPath; // The python script file
                bool noFun = false;

                try { ScriptPath = args[0]; }
                catch (IndexOutOfRangeException x) // There is still a chance to enter the file name, if not provided as a CLI argument.
                {
                    WriteLine(x.GetType().ToString());
                    Write("You must enter a file name: ");
                    ScriptPath = Console.ReadLine();
                }
                
                if(args.Length > 1)
                {
                    if(args[1] == "n" || args[1] == "N")
                        noFun = true;
                }

                if(!File.Exists(ScriptPath))
                {
                    WriteLine("ERROR: File not found!");
                    Environment.Exit(-1);
                }
                
                string PythonPath = GetPythonPath(); // The python program file

                if (PythonPath == "ERROR")
                {
                    WriteLine("Python is either not installed, or is not added system variables");
                    Environment.Exit(-2);
                }

                if(!noFun)
                    WriteLine("\n~~~~~~ Python Script Begins! ~~~~~~\n");

                Process p = Process.Start(PythonPath, ScriptPath);
                p.WaitForExit();

                if(!noFun)
                    WriteLine("\n~~~~~~ End of script : The Dot Net Rises!! ~~~~~~\n");
                
                WriteLine("Press any key to exit...");
                //ReadKey();
            }
            catch (Exception x) { WriteLine("ERROR : " + x.ToString()); }
            
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
                    pythonPathFromEnv = Path.Combine(path, "python.exe");
                    if (File.Exists(pythonPathFromEnv))
                        return pythonPathFromEnv;
                }
            }
            return "ERROR";
        }
    }
    
}