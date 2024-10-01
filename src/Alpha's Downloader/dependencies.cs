using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_s_Downloader
{
    public static class dependencies
    {
        public static async Task validate_dependencies(main_Form form1)
        {
            form1.dowload_btn.Enabled = false;
            form1.search_button.Enabled = false;
            form1.wait_label.Text = "Validating dependencies... please wait";

            await validate_youtube_dl(form1); // Await this method to ensure it completes before proceeding

            await validate_ffmpeg(form1); // Await this method to ensure it completes before proceeding

            form1.dowload_btn.Enabled = true; // Enable buttons after validation
            form1.search_button.Enabled = true;
            form1.wait_label.Text = "";
        }
        static async Task DownloadFileAsync(string url, string savePath)
        {
            using (HttpClient client = new HttpClient())
            {
                // Send a GET request to the specified URL
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode(); // Throw if not a success code.

                    // Read the response content and write it to a file
                    using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                                  fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await contentStream.CopyToAsync(fileStream);
                    }
                }
            }
        }

        static string ComputeMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private static async Task validate_youtube_dl(main_Form form1)
        {
            string file_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\yt-dlp.exe";
            if (File.Exists(file_path))
            {
                string correctMD5 = "0ac2445332ff4d2e3cc3877973710d51";
                
                string ComputedMD5 = ComputeMD5(file_path);

                if (correctMD5 != ComputedMD5)
                {
                    form1.wait_label.Text = "Downloading dependencies... please wait";
                    File.Delete(file_path);
                    await download_youtube_dl(); // Await the download
                }
            }
            else
            {
                form1.wait_label.Text = "Downloading dependencies... please wait";
                await download_youtube_dl(); // Await the download
            }
        }
        private static async Task download_youtube_dl()
        {
            string fileUrl = "https://github.com/Ahmed-Hesham-F5/Alpha-Video-Downloader/raw/refs/heads/main/Dependencies/yt-dlp.exe";
            string savePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\yt-dlp.exe";
            await DownloadFileAsync(fileUrl, savePath);
        }

        private static async Task validate_ffmpeg(main_Form form1)
        {
            string file_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ffmpeg.exe";
            if (File.Exists(file_path))
            {
                string correctMD5 = "0cebe8ed6fc37c0bfc418461d4261d49";
                
                string ComputedMD5 = ComputeMD5(file_path);

                if (correctMD5 != ComputedMD5)
                {
                    form1.wait_label.Text = "Downloading dependencies... please wait";
                    File.Delete(file_path);
                    await download_ffmpeg(); // Await the download
                }
            }
            else
            {
                form1.wait_label.Text = "Downloading dependencies... please wait";
                await download_ffmpeg(); // Await the download
            }
        }
        private static async Task download_ffmpeg()
        {
            string fileUrl = "https://github.com/Ahmed-Hesham-F5/Alpha-Video-Downloader/raw/refs/heads/main/Dependencies/ffmpeg.exe";
            string savePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ffmpeg.exe";
            await DownloadFileAsync(fileUrl, savePath);
        }
    }
}
