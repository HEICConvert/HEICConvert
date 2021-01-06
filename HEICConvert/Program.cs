using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEICConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            var current = Directory.GetCurrentDirectory();
            Console.WriteLine(string.Format("Current Folder: {0}", current));

            string[] fileEntries = Directory.GetFiles(current, "*.heic");
            foreach (var i in fileEntries)
            {
                FileInfo fi = new FileInfo(i);
                var newFile = string.Concat(i.Substring(0, i.Length - 5), ".jpg");
                var newFi = new FileInfo(newFile);
                if (!newFi.Exists)
                {
                    using (MagickImage mi = new MagickImage(fi))
                    {
                        Console.WriteLine(string.Format("Converted: {0}", i));
                        mi.Format = MagickFormat.Jpg;
                        mi.Write(newFi);
                    }

                }    
            }
            Console.WriteLine("Done...");
            Console.ReadKey();

        }
    }
}
