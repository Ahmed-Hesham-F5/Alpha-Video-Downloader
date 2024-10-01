using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Alpha_s_Downloader
{
    public class saveprocess
    {
        public static string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        public static async Task savefile(string url, string max_quality)
        {
           
            max_quality = max_quality.Remove(max_quality.Length - 1);


            string outputFormat = $"-o \"{downloadPath}\\%(title)s.%(ext)s\"";
            string formatString = $"-f \"bv * [ext = mp4][height <= {max_quality}] + ba[ext = m4a] / b[height <= {max_quality}] / bv * [height <= 480] + ba / b[height <= {max_quality}] / wv * +ba / w\"";
            if(max_quality == "mp")
            {
                formatString = "--extract-audio --audio-format mp3";
            }
            string arguments = $"{url} {outputFormat} {formatString}";

            string appLocation = Assembly.GetExecutingAssembly().Location;

            // Optionally, get just the directory (without the executable name)
            string appDirectory = Path.GetDirectoryName(appLocation);

            string youtubeDlPath = Path.Combine(appDirectory, "yt-dlp.exe");
          //  MessageBox.Show(youtubeDlPath);
            // return;
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = youtubeDlPath, // Full path to youtube-dl.exe
                Arguments = arguments,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                UseShellExecute = false,
                CreateNoWindow = true // Prevent the command window from popping up
            };

            // Start the process
            using (Process process = Process.Start(psi))
            {

                // Wait for the process to exit
                process.WaitForExit();

                
            }


        }
    }
}
