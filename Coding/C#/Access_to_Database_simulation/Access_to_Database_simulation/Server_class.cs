using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;

namespace Access_to_Database_simulation
{
    public class Server_access_class
    {
        internal int readSpeed;
        internal int[] data = new int[10];
        internal int writeSpeed;
        internal int writeChance;
        internal int awaitPeriod;
        public System.Windows.Forms.Label lb_status;
        public void ChangeData(List<int> l)
        {
            string str = "";
            Random random = new Random();
            for (int i = 0; i < l.Count; i++)
            {
                data[i] += random.Next(10);
                l[i] = data[i];
                str += l[i] + " ";
            }
            Server.lbdata.Text = str;
        }
        public Server_access_class(int readSpeed, int writeSpeed, int writeChance, int awaitPeriod, System.Windows.Forms.Label lb)
        {
            this.readSpeed = readSpeed;
            this.writeSpeed = writeSpeed;   
            this.writeChance = writeChance;
            this.awaitPeriod = awaitPeriod;
            lb_status = lb;
        }
        public void Run()
        {
            while(true)
            {
                lb_status.Text = "Клиент закончил работу с данными, занят своими делами";
                Thread.Sleep(awaitPeriod);
                                                     // Клиент начинает работать с сервером
                Random random = new Random();
                if (writeChance > random.Next(100)) Server.ReadToWrite(this);
                else Server.ReadToRead(this);
            }

        }


    }
    public static class Server
    {
        private static bool wantToWrite = false;
        private static int currentlyReading=0;
        private static List<int> data = new List<int> () {1,2,3,4,5,9};
        public static System.Windows.Forms.Label lbdata;
        public static System.Windows.Forms.Label lbcount;
        public static void ShowData()
        {
            if (lbdata != null)
            {
                string str= "";
                for (int i = 0; i < data.Count; i++) str =str + data[i].ToString() + " ";
                Server.lbdata.Text = str;
            }
        }
        internal static void ReadToRead(Server_access_class s)
        {
            int ping = 1;
            while (wantToWrite)
            {
                s.lb_status.Text = ($"Клиент ждёт, пока кто-то закончит работать с данными, попытка {ping} (ожидание чтение)").ToString();
                Thread.Sleep(2900);
                s.lb_status.Text = "Клиент проверяет доступны ли данные (ожидание чтение)";
                Thread.Sleep(900);
                ping++;
                if (ping==6)
                {
                    s.lb_status.Text = "Данные заняты, отмена чтения";
                    Thread.Sleep(2000);
                    return;
                }
            }
            AddRead();
            s.lb_status.Text = "Клиент считывает данные";
            Thread.Sleep(s.readSpeed);
            data.CopyTo(s.data);
            RemoveRead();
        }
        private static void AddRead()
        {
            currentlyReading++;
            lbcount.Text = currentlyReading.ToString();
        }
        private static void RemoveRead()
        {
            currentlyReading--;
            lbcount.Text = currentlyReading.ToString();
        }

        internal static void ReadToWrite(Server_access_class s)
        {
            if (wantToWrite)
            {
                s.lb_status.Text = "Уже запланирована запись данных, отмена записи";
                Thread.Sleep(1500);
                return;
            }
            wantToWrite = true;
            while(currentlyReading!=0)
            {
                s.lb_status.Text = "Клиент ждёт, пока закончится чтение данных (ожидание запись)";
                Thread.Sleep(200);
            }
            s.lb_status.Text = "Клиент ждёт, пока кто-то закончит работать с данными (ожидание запись)";
            Monitor.Enter(data);
            wantToWrite = true;
            AddRead();
            s.lb_status.Text = "Клиент считывает данные... (запись)";
            Thread.Sleep(s.readSpeed);
            data.CopyTo(s.data);
            RemoveRead();
            s.lb_status.Text = "Клиент считал данные, начинает работу и запись... (запись)";
            Thread.Sleep(s.writeSpeed);
            s.ChangeData(data);
            wantToWrite = false;
            Monitor.Exit(data);
        }
    }
}
