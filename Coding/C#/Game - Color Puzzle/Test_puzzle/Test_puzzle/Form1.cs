using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Info.Init();
            this.Size = new Size(130 + Info.size * 60, 250 + Info.size * 60);
            for (int i = 1; i <= Info.size; i++)
            {
                for (int j = 1; j <= Info.size; j++)
                {
                    Info.buttonField.Add(new PuzzleButton(i, j));
                }
            }
            Info.buttonField.Add(new PuzzleButton(1, Info.size + 1));
            Info.buttonField.Add(new PuzzleButton(3, Info.size + 1));
            Info.buttonField.Add(new PuzzleButton(5, Info.size + 1));
            Info.showButton = new PuzzleButton(3, Info.size + 2);
            Info.buttonField.Add(Info.showButton);
            foreach (PuzzleButton button in Info.buttonField) Controls.Add(button);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class PuzzleButton : System.Windows.Forms.Button
    {
        public readonly int x;
        public readonly int y;
        public static readonly Random random = new Random();

        public PuzzleButton(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.UpdateBounds(x * 60, y * 60, 50, 50);
            this.Text = " ";
            this.BackColor = System.Drawing.Color.Gray;
            if (x%2==1 && y<6)
            {
                int temp = random.Next(Info.freeColors.Count);
                this.BackColor = Info.freeColors[temp];
                Info.freeColors.Remove(this.BackColor);
            }
            if (x%2==0 && y%2==1)
            {
                this.Enabled = false;
                this.BackColor = System.Drawing.Color.Black;
            }
            if (y == 6)
            {
                this.Enabled = false;
                if (x == 1) this.BackColor = System.Drawing.Color.Yellow;
                if (x == 3) this.BackColor = System.Drawing.Color.Blue;
                if (x == 5) this.BackColor = System.Drawing.Color.Red;
            }
            if (y==7)
            {
                this.Enabled = false;
                this.BackColor = System.Drawing.Color.White;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (Info.showButton.BackColor == System.Drawing.Color.White && this.BackColor!= System.Drawing.Color.Gray)
            {
                Info.chosenButton = this;
                Info.showButton.BackColor = this.BackColor;
            }
            else if (Info.chosenButton!=null)
            {
                if (this.BackColor==System.Drawing.Color.Gray)
                {
                    if ((Math.Abs(this.x-Info.chosenButton.x) + Math.Abs(this.y - Info.chosenButton.y)) == 1)
                    {
                        ChooseButton(this);
                    }
                }
                Info.chosenButton = null;
                Info.showButton.BackColor = System.Drawing.Color.White;
            }
            base.OnClick(e);
            InitWin();
        }
        public void ChooseButton(PuzzleButton thisButton)
        {
            thisButton.BackColor = Info.showButton.BackColor;
            Info.chosenButton.BackColor = System.Drawing.Color.Gray;
        }
        public static void InitWin()
        {
            foreach (PuzzleButton button in Info.buttonField)
            {
                if (button.x == 1 && button.BackColor != System.Drawing.Color.Yellow) return;
                if (button.x == 3 && button.BackColor != System.Drawing.Color.Blue && button.y<6) return;
                if (button.x == 5 && button.BackColor != System.Drawing.Color.Red) return;
            }
            MessageBox.Show("You win!");
            Application.Exit();
        }
    }
}
