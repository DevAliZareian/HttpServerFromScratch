using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.Utils
{
    public class Cmd
    {
        public static void Execute(string command)
        {
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = command;
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
        }
    }
}
