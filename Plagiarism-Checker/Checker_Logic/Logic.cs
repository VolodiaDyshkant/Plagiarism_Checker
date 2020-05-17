using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Checker_Logic
{
    public static class Logic
    {
        public static string check(string text1, string text2)
        {

            var psi = new ProcessStartInfo();

            psi.FileName = @"Checker_Logic\PY_Checker\Plagiarism_Checker.exe";
            string file1 = '\u0022' + text1 + '\u0022';
            string file2 = '\u0022' + text2 + '\u0022';
            psi.Arguments = file1 + " " + file2;

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;


            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }
            return results;

        }
    }
}
