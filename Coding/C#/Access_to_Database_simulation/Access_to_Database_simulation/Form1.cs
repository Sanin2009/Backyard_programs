using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Access_to_Database_simulation
{
    
    public partial class Form1 : Form
    {
        public delegate void RunClients();
        public RunClients rc;
        public Form1()
        {
            InitializeComponent();
            Server.lbdata = lb_Data;
            Server.lbcount = lb_Reading;
            Server.ShowData();
            MyFormControl();

        }

        private void MyFormControl()
        {
            var c1 = new Server_access_class(10000, 10000, 15, 20000, lb_c1);
            var c2 = new Server_access_class(5000, 10000, 0, 10000, lb_c2);
            var c3 = new Server_access_class(2000, 10000, 0, 5000, lb_c3);
            var c4 = new Server_access_class(1000, 15000, 30, 35000, lb_c4);
            var c5 = new Server_access_class(8000, 12000, 40, 19000, lb_c5);

            CheckForIllegalCrossThreadCalls = false; // На самом деле так делать плохо

            Task.Run(c1.Run);
            Task.Run(c2.Run);
            Task.Run(c3.Run);
            Task.Run(c4.Run);
            Task.Run(c5.Run);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
