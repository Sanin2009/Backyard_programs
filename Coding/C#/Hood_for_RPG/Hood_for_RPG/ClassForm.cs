using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hood_for_RPG
{
    public partial class ClassForm : Form
    {

        public ClassForm()
        {
            InitializeComponent();
        }

        private void btWarrior_Click(object sender, EventArgs e)
        {
            CharacterBases.classtype = classes.Warrior;
            Close();
        }

        private void btSoldier_Click(object sender, EventArgs e)
        {
            CharacterBases.classtype = classes.Soldier;
            Close();
        }

        private void btArcher_Click(object sender, EventArgs e)
        {
            CharacterBases.classtype = classes.Archer;
            Close();
        }

        private void btMercenary_Click(object sender, EventArgs e)
        {
            CharacterBases.classtype = classes.Mercenary;
            Close();
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {

        }
    }
}
