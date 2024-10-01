using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_s_Downloader
{
    public class loadimage
    {
        public static async Task<Image> LoadImageAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(url); // Get image data as byte array
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return Image.FromStream(ms); // Create an image from the byte array
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes

                //MessageBox.Show($"Error loading image from {url}: {ex.Message}");
                return null; // Return null if loading fails
            }
        }
    }
}
