using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebScraper.lib
{
    public static class Util
    {
        static List<string> validOptions = new List<string>()
        {
            "w",
            "c"
        };

        public static bool VerifyOptionalArgs(List<string> args)
        {
            var result = from a in args
                         where !(from v in validOptions
                                 select v).Contains(a)
                         select a;

            if (result.Count() > 0)
            {
                return false;
            }

            return true;
        }


    }
}
