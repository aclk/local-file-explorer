using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LocalExplorer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                MessageBox.Show("File Path is Empty", "System Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            string filePath = args[0];

            // escape
            filePath = Uri.UnescapeDataString(filePath).Replace("/", "\\");

            // delete protocol
            filePath = filePath.Replace("localexplorer:", "");
            filePath = filePath.Replace("file:", "");
            // get right file path
            filePath = filePath.Substring(filePath.IndexOf('\\'));
            //Console.WriteLine(filePath);

            if (Directory.Exists(filePath) || File.Exists(filePath))
            {
                Process p = new Process();
                p.StartInfo.FileName = "explorer.exe";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;

                // hidden
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                p.EnableRaisingEvents = true;
                p.StartInfo.RedirectStandardError = true;

                if (File.Exists(filePath))
                {
                    p.StartInfo.Arguments = @"/select," + filePath;
                }
                else
                {
                    p.StartInfo.Arguments = filePath;
                }

                try
                {
                    p.Start();

                    // explorer.exe 异常结束时，会导致启动不断重启
                    p.WaitForExit();

                    if (p != null)
                    {
                        p.Close();
                        p.Dispose();
                        p = null;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Not Found Path : \n" + filePath, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
