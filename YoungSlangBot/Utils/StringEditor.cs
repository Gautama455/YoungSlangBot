using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoungSlangBot
{
    internal static class StringEditor
    {
        public static string ParseResponseUrl(string stringResponse)
        {
            return stringResponse.Split(",").Last().Replace("[", "").Replace("]", "").Replace("\"", "");
        }
    }
}
