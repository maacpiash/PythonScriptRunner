using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonScriptRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process p = new Process();
                string arg = string.Format(@"C:\Users\maac\Desktop\another.py");
                string prog = string.Format(@"C:\Users\maac\AppData\Local\Programs\Python\Python36\python.exe");
                p.StartInfo = new ProcessStartInfo(prog, arg);
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                // যদি পাইথন স্ক্রিপ্টের আউটপুট নতুন উইন্ডোতে দেখতে চান
                // তাহলে উপরের লাইনটা কমেন্ট-আউট করে দিন।
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.RedirectStandardError = false;
                Process processChild = Process.Start(p.StartInfo);
                Console.ReadLine();
            }
            catch (Exception x) { Console.WriteLine(x); }
        }
    }
}
