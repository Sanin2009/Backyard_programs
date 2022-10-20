using System;
using System.Collections.Generic;
using System.Text;

namespace Test_puzzle
{
    internal class Info
    {
        public static int size = 5;
        public static PuzzleButton chosenButton;
        public static PuzzleButton showButton;

        public static List<System.Drawing.Color> freeColors = new List<System.Drawing.Color>();

        public static List<PuzzleButton> buttonField = new List<PuzzleButton>();
        public static void Init()
        {
            for (int i = 1; i <= size; i++) freeColors.Add(System.Drawing.Color.Blue);
            for (int i = 1; i <= size; i++) freeColors.Add(System.Drawing.Color.Red);
            for (int i = 1; i <= size; i++) freeColors.Add(System.Drawing.Color.Yellow);
        }
    }
}
