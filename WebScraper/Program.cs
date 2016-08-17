using System;
using System.Collections.Generic;
using System.Linq;
using WebScraper.lib;
using WebScraper.Controller;
using System.Text.RegularExpressions;

namespace WebScraper
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Invalid arguments.\n" + Messages.RenderInstructions());
                return 1;
            }

            if (args.Length > 3)
            {
                Console.WriteLine("Too many arguments.\n" + Messages.RenderInstructions());
                return 1;
            }

            var options = new List<string>();

            if (args.Length == 3)
            {
                options = args[2].Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

                if (!Util.VerifyOptionalArgs(options))
                {
                    Console.WriteLine("Invalid optional arguments.\n" + Messages.RenderInstructions());
                    return 1;
                }
            }

            var urlController = new UrlController();

            List<string> urls;

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (urlController.ValidateFile(args[0], out urls))
            {
                foreach (var url in urls)
                {
                    data.Add(url, urlController.ReadPage(url));
                }
            }
            else
            {
               data.Add(args[0], urlController.ReadPage(args[0]));
            }

            List<string> words = new List<string>();

            words = args[1].Split(',').ToList<string>();

            foreach (var page in data)
            {
                Console.WriteLine("Seaarching {0}:", page.Key);
                if (options.Contains("c"))
                {
                    Console.WriteLine("Total characters {0}.", page.Value.Count());
                }

                foreach (var word in words)
                {
                    var matches = Regex.Matches(page.Value, string.Format(@"\b{0}\b",word), 
                        RegexOptions.IgnoreCase, new TimeSpan(0, 15,0));

                    if (matches.Count > 0)
                    {
                        Console.WriteLine("Word {0} found!", word);
                        if (options.Contains("w"))
                        {
                            Console.WriteLine("Total words {0} found: {1}", word, matches.Count);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matches found for word {0}.", word);
                    }
                }
            }

            Console.ReadKey();

            return 0;


        }
    }
}
