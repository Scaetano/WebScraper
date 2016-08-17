using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Controller
{
    public class UrlController
    {  

        public string ReadPage(string arg)
        {

            using (var client = new WebClient())
            {
                string strPage;

                try
                {
                    strPage = client.DownloadString(arg);
                }
                catch (Exception)
                {
                    strPage = "Unable to read the requested page.\n" +
                        "Please check your url and try again.";                     
                }

                return strPage;
            }
        }

        public bool ValidateFile(string path, out List<string> urls)
        {
            try
            {
                urls = File.ReadAllLines(path).ToList<string>();

                if (urls.Count == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                urls = null;
                return false;
            }
        }
    }
}
