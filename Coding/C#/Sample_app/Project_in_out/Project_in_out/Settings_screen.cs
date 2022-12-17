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
    public partial class Settings_screen : Form
    {
        public Settings_screen()
        {
            InitializeComponent();
            if (!System.IO.File.Exists("baseTable.json")) System.IO.File.Create("baseTable.json").Close();
            else
            {
                var json = System.IO.File.ReadAllText("baseTable.json");
                if (json != "") Global.table = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                else
                {
                    json = JsonConvert.SerializeObject(Global.table, Formatting.Indented);
                    System.IO.File.WriteAllText("baseTable.json", json);
                }
            }
            foreach (var key in Global.table) dgvSettings.Rows.Add(key.Key, key.Value);
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (Global.table.Count == 0) MessageBox.Show("Нужен как минимум один идентификатор");
            else
            {
                var json = JsonConvert.SerializeObject(Global.table, Formatting.Indented);
                System.IO.File.WriteAllText("baseTable.json", json);
                this.Close();
            }
        }

        private void Settings_screen_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void ShowTable()
        {
            dgvSettings.Rows.Clear();
            foreach (var key in Global.table) dgvSettings.Rows.Add(key.Key, key.Value);
        }

        private void Settings_screen_FormClosed(object sender, FormClosedEventArgs e)
        {
            App mainForm = new App();
            this.Hide();
            mainForm.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (tbId.Text.Length < 24) return;
            if (tbName.Text.Length < 1) return;
            if (!Global.table.ContainsKey(tbId.Text.ToUpper()))
            {
                Global.table.Add(tbId.Text.ToUpper(), tbName.Text);
                ShowTable();
            }
            tbId.Text = "";
            tbName.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (tbId.Text.Length < 24) return;
            if (Global.table.ContainsKey(tbId.Text.ToUpper()))
            {
                Global.table.Remove(tbId.Text);
                ShowTable();
            }
            tbId.Text = "";
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            Global.table.Clear();
            ShowTable();
        }
    }
}
