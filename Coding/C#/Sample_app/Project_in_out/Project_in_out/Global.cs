using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_in_out
{
    public static class Global
    {
        public static Dictionary<string, int> input = new Dictionary<string, int>();
        public static Dictionary<string, int> output = new Dictionary<string, int>();
        public static Dictionary<string, string> table = new Dictionary<string, string>()
        {
            {"000000000000000000000001", "Bag"},
            {"000000000000000000000002", "Shoes"},
            {"000000000000000000000003", "Hat"},
            {"000000000000000000000004", "Gloves"},
            {"000000000000000000000005", "Shorts"},
        };
    }
}
