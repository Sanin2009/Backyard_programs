using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilot_game
{
    internal static class Info
    {
        public static int size = 0;
        public const int MIN_SIZE= 2;
        public const int MAX_SIZE = 29;

        public static List<PilotButton> buttonField = new List<PilotButton>();
    }
}
