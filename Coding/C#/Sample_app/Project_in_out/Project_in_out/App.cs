using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_in_out
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
            ChangeSizes();
            if (!System.IO.File.Exists("jsonInput.json")) System.IO.File.Create("jsonInput.json").Close();
            if (!System.IO.File.Exists("jsonOutput.json")) System.IO.File.Create("jsonOutput.json").Close();
            var jsonInput = System.IO.File.ReadAllText("jsonInput.json");
            var jsonOutput = System.IO.File.ReadAllText("jsonOutput.json");
            if (jsonInput.Length > 4) Global.input = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonInput);
            if (jsonOutput.Length > 4) Global.output = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonOutput);
            ShowInputTable();
            ShowOutputTable();
        }

        private void ShowInputTable()
        {
            dgvInput.Rows.Clear();
            if(Global.input!=null) foreach (KeyValuePair<string, int> key in Global.input) dgvInput.Rows.Add(key.Key, key.Value);
        }

        private void ShowOutputTable()
        {
            dgvOutput.Rows.Clear();
            if (Global.output != null)  foreach (KeyValuePair<string, int> key in Global.output) dgvOutput.Rows.Add(key.Key, key.Value);
        }

        private void AddObject (string input, Dictionary<string, int> mainTable, Dictionary<string, int> secondaryTable, bool isInputTable)
        {
            input= input.ToUpper();
            if (!Global.table.ContainsKey(input)) return;
            if (mainTable!=null && mainTable.ContainsKey(input))
            {
                mainTable[input]++;
                if (isInputTable) ShowInputTable();
                else ShowOutputTable();
            }
            else
            {
                mainTable.Add(input, 1);
                if (isInputTable) ShowInputTable();
                else ShowOutputTable();
            }
            if (secondaryTable!=null && secondaryTable.ContainsKey(input)) {
                if (secondaryTable[input] > 1)
                {
                    secondaryTable[input]--;
                    if (!isInputTable) ShowInputTable();
                    else ShowOutputTable();
                }

                else
                {
                    secondaryTable.Remove(input);
                    if (!isInputTable) ShowInputTable();
                    else ShowOutputTable();
                }
            };
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ChangeSizes();
        }
        private void ChangeSizes()
        {
            ChangeTB1();
            ChangeTB2();
            ChangeButtonIn();
            ChangeButtonOut();
            ChangeButtonClear();
            ChangeListIn();
            ChangeListOut();
            ChangeTextIn();
            ChangeTextOut();
        }

        private void ChangeTextOut()
        {
            lbOutput.Location = new Point(ClientRectangle.Width / 2, (ClientRectangle.Height / 4)-20);
        }

        private void ChangeTextIn()
        {
            lbinput.Location = new Point(ClientRectangle.Width / 10, (ClientRectangle.Height / 4)-20);
        }

        private void ChangeListOut()
        {
            dgvOutput.Location = new Point((ClientRectangle.Width-50)*5 / 9, (ClientRectangle.Height + 400) / 4);
        }

        private void ChangeListIn()
        {
            dgvInput.Location = new Point((ClientRectangle.Width-400) / 5, (ClientRectangle.Height+400) / 4);
        }

        private void ChangeButtonClear()
        {
            buttonClear.Location = new Point((ClientRectangle.Width) / 14, (ClientRectangle.Height*5) / 6);
        }

        private void ChangeButtonOut()
        {
            buttonOutput.Location = new Point(((ClientRectangle.Width + 60) * 5 / 9), (ClientRectangle.Height / 4) + 50);
        }

        private void ChangeButtonIn()
        {
            buttonInput.Location = new Point(((ClientRectangle.Width-100) /5), (ClientRectangle.Height / 4) + 50);
        }

        private void ChangeTB2()
        {
            outputBox.Location = new Point(ClientRectangle.Width / 2, ClientRectangle.Height / 4);
            outputBox.Size = new Size(ClientRectangle.Width / 3, 20);
        }

        private void ChangeTB1()
        {
            inputBox.Location = new Point(ClientRectangle.Width / 10, ClientRectangle.Height / 4);
            inputBox.Size = new Size(ClientRectangle.Width / 3, 20);
        }

        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fullInput = inputBox.Text.Trim().Split(' ');
                foreach (string input in fullInput) AddObject(input, Global.input, Global.output, true);
                inputBox.Text = "";
            }
    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string jsonInput = JsonConvert.SerializeObject(Global.input, Formatting.Indented);
            string jsonOutput = JsonConvert.SerializeObject(Global.output, Formatting.Indented);
            System.IO.File.WriteAllText("jsonInput.json", jsonInput);
            System.IO.File.WriteAllText("jsonOutput.json", jsonOutput);
            Application.Exit();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dgvOutput.Rows.Clear();
            dgvInput.Rows.Clear();
            Global.input.Clear();
            Global.output.Clear();
        }

        private void outputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fullInput = outputBox.Text.Trim().Split(' ');
                foreach (string input in fullInput) AddObject(input, Global.output, Global.input, false);
                outputBox.Text = "";
            }
        }
    }
}
