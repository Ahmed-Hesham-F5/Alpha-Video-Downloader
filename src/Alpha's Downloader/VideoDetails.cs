using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class VideoDetails
    {
        public string? title {  get; set; }  
        public string? link { get; set; }
     
        public bool? download { get; set; }=true;
        public string? qualities { get; set; } // Store the image URL
       

    }
}
