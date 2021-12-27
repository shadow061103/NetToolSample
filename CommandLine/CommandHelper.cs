using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    public class CommandHelper
    {
        public static string ExecuteCommand(string path, IEnumerable<string> commands)
        {
            using (Process p = new Process())
            {
                var startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.UseShellExecute = false;        //是否使用作業系統shell啟動
                startInfo.RedirectStandardInput = true;   //接受來自呼叫程式的輸入資訊
                startInfo.RedirectStandardOutput = true;  //由呼叫程式獲取輸出資訊
                startInfo.RedirectStandardError = true;   //重定向標準錯誤輸出
                startInfo.CreateNoWindow = true;          //不顯示程式視窗
                startInfo.WorkingDirectory = path;
                p.StartInfo = startInfo;
                p.Start();//啟動程式
                          //向cmd視窗寫入命令
                if (commands.Any())
                {
                    foreach (var command in commands)
                    {
                        var cmd = command.Trim();
                        p.StandardInput.WriteLine(cmd);
                    }
                }

                p.StandardInput.WriteLine("exit");
                p.StandardInput.AutoFlush = true;
                //獲取cmd視窗的輸出資訊
                StreamReader reader = p.StandardOutput;//擷取輸出流
                StreamReader error = p.StandardError;//擷取錯誤資訊
                string str = reader.ReadToEnd() + error.ReadToEnd();
                p.WaitForExit();//等待程式執行完退出程式
                p.Close();
                return str;
            }
        }
    }
}