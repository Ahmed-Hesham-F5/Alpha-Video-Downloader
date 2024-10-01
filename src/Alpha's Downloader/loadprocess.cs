using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_s_Downloader
{
    public class loadprocess
    {
        public static string default_quality="720p";
       public static async Task<BindingList<VideoDetails>> load_playlist(string url)
        {
            BindingList<VideoDetails> list = new BindingList<VideoDetails>();

            var arguments = $"--get-title --get-id {url}";

            string appLocation = Assembly.GetExecutingAssembly().Location;

            string appDirectory = Path.GetDirectoryName(appLocation);

            string youtubeDlPath = Path.Combine(appDirectory, "yt-dlp.exe");
            //  MessageBox.Show(youtubeDlPath);
            // return;
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = youtubeDlPath, // Full path to youtube-dl.exe
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true // Prevent the command window from popping up
            };


            //            processInfo.Verb = "runas";
            var process = new Process { StartInfo = processInfo };

            try
            {
                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();
                await process.WaitForExitAsync();
                //  Console.WriteLine(output);
                string[] videoIds = output.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);


                for (int i = 0; i < videoIds.Length; i += 2)
                {
                    VideoDetails videoDetails = new VideoDetails
                    {
                        title = videoIds[i],
                        link = $"https://www.youtube.com/watch?v={videoIds[i + 1]}",
                        download = true,
                        qualities = default_quality

                    };
                    if (!main_Form.is_youtubeplaylist && !url.StartsWith(@"https://www.youtube.com/playlist"))
                    {
                        videoDetails.link=url;
                    }

                    list.Add(videoDetails);
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return list;
        }
    }
}
