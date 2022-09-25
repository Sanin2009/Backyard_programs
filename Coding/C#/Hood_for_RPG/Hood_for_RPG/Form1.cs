using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hood_for_RPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var nameF = new NameForm();
            nameF.ShowDialog();
            InitializeComponent();

        }

        private void btGrowth_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CharacterBases.mainCharacter.ShowGrowth());
        }

        private void btLevelUp_Click(object sender, EventArgs e)
        {
            CharacterBases.mainCharacter.LevelUp();
            UpdateStats();
        }

        private void UpdateStats()
        {
            tbName.Text = CharacterBases.mainCharacter.name.ToString();
            tbClass.Text = CharacterBases.mainCharacter.baseclass.ToString();
            tbLevel.Text = CharacterBases.mainCharacter.baseLevel.ToString();
            tbHP.Text = CharacterBases.mainCharacter.baseHP.ToString();
            tbStrength.Text = CharacterBases.mainCharacter.baseStrength.ToString();
            tbSkill.Text = CharacterBases.mainCharacter.baseSkill.ToString();
            tbSpeed.Text = CharacterBases.mainCharacter.baseSpeed.ToString();
            tbLuck.Text = CharacterBases.mainCharacter.baseLuck.ToString();
            tbDefence.Text = CharacterBases.mainCharacter.baseDefence.ToString();
            tbCon.Text = CharacterBases.mainCharacter.baseCon.ToString();
            tbMove.Text = CharacterBases.mainCharacter.baseMove.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CharacterBases.characterName == null || CharacterBases.classtype == classes.Unknown)
            {
                Close(); //Close();
                Application.Exit();
            }
            else
            {
                tbName.Text = CharacterBases.characterName;
                tbClass.Text = CharacterBases.classtype.ToString();
                // Создать 4 базовых класса
                var baseSoldier = new CharacterClass(23, 4, 1, 8, 5, 6, 6, 7, 4, 80, 40, 45, 28, 33, 37, false, false, true, false, classes.Soldier);

                var baseArcher = new CharacterClass(20, 7, 1, 7, 8, 8, 5, 5, 4, 65, 50, 25, 38, 43, 30, true, false, false, false, classes.Archer);

                var baseWarrior = new CharacterClass(28, 5, 1, 7, 5, 6, 9, 10, 4, 75, 33, 30, 24, 37, 50, false, true, false, false, classes.Warrior);

                var baseMercenary = new CharacterClass(26, 6, 1, 6, 6, 7, 8, 11, 4, 70, 42, 32, 32, 40, 47, false, false, false, true, classes.Mercenary);
                // Унаследовать на класс игрока
                if (CharacterBases.classtype == classes.Soldier) CharacterBases.mainCharacter = new CharacterClass(CharacterBases.characterName, baseSoldier);

                if (CharacterBases.classtype == classes.Archer) CharacterBases.mainCharacter = new CharacterClass(CharacterBases.characterName, baseArcher);

                if (CharacterBases.classtype == classes.Warrior) CharacterBases.mainCharacter = new CharacterClass(CharacterBases.characterName, baseWarrior);

                if (CharacterBases.classtype == classes.Mercenary) CharacterBases.mainCharacter = new CharacterClass(CharacterBases.characterName, baseMercenary);
                UpdateStats();
            }
        }
    }
}
