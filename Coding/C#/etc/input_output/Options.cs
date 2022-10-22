// класс реализации загрузки и сохранения в игре 100_ROUNDS

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Form
{
    public class Options
    {
        public static class Option
        {
            public static int font;
            public static bool time;
            public static int rounds;
            public static double res;
            public static void load()
            {
                if (File.Exists("options.dll"))
                {
                    var data = File
                                       .ReadAllLines("options.dll")
                                       .Select(x => x.Split('='))
                                       .Where(x => x.Length > 1)
                                       .ToDictionary(x => x[0].Trim(), x => x[1]);
                    font = Int32.Parse(data["font"]);
                    time = bool.Parse(data["time"]);
                    rounds = Int32.Parse(data["rounds"]);
                    rounds -= 1024;
                    res = double.Parse(data["res"]);
                    data.Clear();
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter("options.dll"))
                    {
                        writer.WriteLine("font = {0}", 16);
                        writer.WriteLine("time = {0}", true);
                        writer.WriteLine("rounds = {0}", 1024);
                        writer.WriteLine("res = {0}", 0);
                    }
                }
            }

            public static void save_opt(int fontout, bool showtime)
            {
                //string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                using (StreamWriter writer = new StreamWriter("options.dll"))
                {
                    writer.WriteLine("font = {0}", fontout);
                    writer.WriteLine("time = {0}", showtime);
                    writer.WriteLine("rounds = {0}", rounds+1024);
                    writer.WriteLine("res = {0}", res);
                }

            }
            public static void save_res(int rounds_ingame, double restime)
            {
                //string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                using (StreamWriter writer = new StreamWriter("options.dll"))
                {
                    if (rounds_ingame == 100)
                    {
                        if ((rounds==100 && restime < res) || (rounds<100))
                        {
                            writer.WriteLine("font = {0}", font);
                            writer.WriteLine("time = {0}", time);
                            writer.WriteLine("rounds = {0}", 1124);
                            writer.WriteLine("res = {0}", restime);
                            rounds = 100;
                            res = restime;
                        }
                        else
                        {
                            writer.WriteLine("font = {0}", font);
                            writer.WriteLine("time = {0}", time);
                            writer.WriteLine("rounds = {0}", 1124);
                            writer.WriteLine("res = {0}", res);
                            rounds = 100;
                        }
                    }
                    else
                    if (rounds_ingame == 99 && rounds<=99 && (restime < res || res==0))
                    {
                        writer.WriteLine("font = {0}", font);
                        writer.WriteLine("time = {0}", time);
                        writer.WriteLine("rounds = {0}", 1123);
                        writer.WriteLine("res = {0}", restime);
                        rounds = 99;
                        res = restime;
                    }
                    else if (rounds_ingame > rounds)
                    {
                        writer.WriteLine("font = {0}", font);
                        writer.WriteLine("time = {0}", time);
                        writer.WriteLine("rounds = {0}", rounds_ingame + 1024);
                        writer.WriteLine("res = {0}", 0);
                        rounds = rounds_ingame;
                    }
                    else
                    {
                        writer.WriteLine("font = {0}", font);
                        writer.WriteLine("time = {0}", time);
                        writer.WriteLine("rounds = {0}", rounds + 1024);
                        writer.WriteLine("res = {0}", res);
                    }
                }
            }
        }
    }
}
