using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pilot_game
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            SizeForm chooseSize = new SizeForm();
            chooseSize.ShowDialog();
            InitializeComponent();

            this.Size = new Size(180 + Info.size * 30, 180 + Info.size * 30);
            for (int i = 1; i <= Info.size; i++)
            {
                for (int j = 1; j <= Info.size; j++)
                {
                    Info.buttonField.Add(new PilotButton(i, j));
                    this.Controls.Add(Info.buttonField[j - 1 + (i - 1) * Info.size]);
                }
            }
            foreach (PilotButton button in Info.buttonField)
            {
                if (PilotButton.random.Next(2) == 1) foreach (PilotButton buttonTwo in Info.buttonField) buttonTwo.SwitchPosition(button.x, button.y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Info.size==0) this.Close();
            PilotButton.InitWin();
        }
    }
    public class PilotButton : System.Windows.Forms.Button
    {
        public readonly int x;
        public readonly int y;
        private bool position;
        public static readonly Random random = new Random();

        public PilotButton(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.UpdateBounds(50 + x * 30, 50 + y * 30, 25, 25);
            position = false;
            this.Text = "---";
        }

        protected override void OnClick(EventArgs e)
        {
            foreach (PilotButton button in Info.buttonField)
            {
                button.SwitchPosition(x, y);
            }
            // Your code here
            //...
            base.OnClick(e);
            InitWin();
        }
        public void SwitchPosition(int x, int y)
        {
            if (this.x==x || this.y==y)
            {
                if (position)
                {
                    position = false;
                    this.Text = "---";
                }
                else
                {
                    position = true;
                    this.Text = "|";
                }
            }

        }
        public static void InitWin()
        {
            var tempMatrix1 = Info.buttonField.FindAll(x => x.position == true);
            var tempMatrix2 = Info.buttonField.FindAll(x => x.position == false);
            if (Info.buttonField.Count == tempMatrix1.Count || Info.buttonField.Count == tempMatrix2.Count)
            {
                MessageBox.Show("You win!");
                Application.Exit();
            }
        }
    }
}
