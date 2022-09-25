using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Hood_for_RPG
{
    public partial class NameForm : Form
    {

        public NameForm()
        {
            var classF = new ClassForm();
            classF.ShowDialog();
            InitializeComponent();
        }

        private void btDone_Click(object sender, EventArgs e)
        {
            if (tbCharacterName.Text.Length > 11)
            {
                MessageBox.Show("This name is too long!");
                return;
            }
            else if (tbCharacterName.Text == null || tbCharacterName.Text.Trim() == "")
            {
                MessageBox.Show("Name can't be empty!");
                return;
            }
            else if (tbCharacterName.Text.Length < 3)
            {
                MessageBox.Show("This name is too short!");
                return;
            }
            else
            {
                CharacterBases.characterName = tbCharacterName.Text.Trim().ToLower();
                Close();
            }
        }
    }
}
