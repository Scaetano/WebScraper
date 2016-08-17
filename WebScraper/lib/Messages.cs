using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.lib
{
    public static class Messages
    {
        public static string RenderInstructions()
        {
            var sb = new StringBuilder();

            sb.Append("System usage: \n");
            sb.Append("WebScraper [url] [words] [optional args]\n");
            sb.Append("     URL: A valid URL that you want to search. --required \n");
            sb.Append("     Words: Word or Words that you want to find separeted by comma. --required \n");
            sb.Append("     Optional Args: \n");
            sb.Append("         -w: number of occurrences of given word(s).\n");
            sb.Append("         -c: number of the characters of each page.\n");


            return sb.ToString();
        }
    }
}
