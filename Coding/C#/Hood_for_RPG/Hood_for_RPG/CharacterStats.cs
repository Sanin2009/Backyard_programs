using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Hood_for_RPG
{
    public enum classes
    {
        Unknown,Soldier,Warrior,Archer,Mercenary
    }
    public class CharacterClass
    {
        public int baseHP;
        public int baseSkill;
        public int baseLevel;
        public int baseDefence;
        public int baseLuck;
        public int baseSpeed;
        public int baseStrength;
        public int baseCon;
        public int baseMove;
        public int baseHPGrowth;
        public int baseSkillGrowth;
        public int baseDefenceGrowth;
        public int baseLuckGrowth;
        public int baseSpeedGrowth;
        public int baseStrengthGrowth;
        public Random randomGrowth;
        public string name = null;
        public bool canUseSpear;
        public bool canUseAxe;
        public bool canUseSword;
        public bool canUseBow;
        public const int levelCap = 40;
        public const int statCap = 27;
        public classes baseclass = classes.Unknown;

        public CharacterClass(int baseHP, int baseSkill,int baseLevel, int baseDefence, int baseLuck, int baseSpeed, int baseStrength, 
                              int baseCon, int baseMove, int baseHPGrowth, int baseSkillGrowth, int baseDefenceGrowth, int baseLuckGrowth, 
                              int baseSpeedGrowth, int baseStrengthGrowth, bool canUseBow, bool canUseAxe, bool canUseSpear, bool canUseSword, classes baseclass)
        {
            this.baseHP = baseHP;
            this.baseSkill = baseSkill;
            this.baseLevel = baseLevel;
            this.baseDefence = baseDefence;
            this.baseLuck = baseLuck;
            this.baseSpeed = baseSpeed;
            this.baseStrength = baseStrength;
            this.baseCon = baseCon;
            this.baseMove = baseMove;
            this.baseHPGrowth = baseHPGrowth;
            this.baseSkillGrowth = baseSkillGrowth;
            this.baseLuckGrowth = baseLuckGrowth;
            this.baseDefenceGrowth = baseDefenceGrowth;
            this.baseSpeedGrowth = baseSpeedGrowth;
            this.baseStrengthGrowth = baseStrengthGrowth;
            this.name = "enemy";
            this.canUseBow = canUseBow;
            this.canUseAxe = canUseAxe;
            this.canUseSpear = canUseSpear;
            this.canUseSword = canUseSword;
            this.baseclass = baseclass;
        }
        public CharacterClass(string name, CharacterClass baseClass)
        {
            this.name = name;
            randomGrowth = new Random(GetRandom(name));
            this.baseHP = baseClass.baseHP + randomGrowth.Next(5) - 2;
            this.baseSkill = baseClass.baseSkill + randomGrowth.Next(3) - 1;
            this.baseLevel = baseClass.baseLevel;
            this.baseDefence = baseClass.baseDefence + randomGrowth.Next(3) - 1;
            this.baseLuck = baseClass.baseLuck + randomGrowth.Next(3) - 1;
            this.baseSpeed = baseClass.baseSpeed + randomGrowth.Next(3) - 1;
            this.baseStrength = baseClass.baseStrength + randomGrowth.Next(3) - 1;
            this.baseCon = baseClass.baseCon + randomGrowth.Next(3) - 1;
            this.baseMove = baseClass.baseMove;
            this.baseHPGrowth = baseClass.baseHPGrowth + randomGrowth.Next(21) - 10;
            this.baseSkillGrowth = baseClass.baseSkillGrowth + randomGrowth.Next(11) - 5;
            this.baseLuckGrowth = baseClass.baseLuckGrowth + randomGrowth.Next(11) - 5;
            this.baseDefenceGrowth = baseClass.baseDefenceGrowth + randomGrowth.Next(11) - 5;
            this.baseSpeedGrowth = baseClass.baseSpeedGrowth + randomGrowth.Next(11) - 5;
            this.baseStrengthGrowth = baseClass.baseStrengthGrowth + randomGrowth.Next(11) - 5;
            this.canUseBow = baseClass.canUseBow;
            this.canUseAxe = baseClass.canUseAxe;
            this.canUseSpear = baseClass.canUseSpear;
            this.canUseSword = baseClass.canUseSword;
            this.baseclass = baseClass.baseclass;
            // Копия
        }

        private int GetRandom(string name)
        {
            char[] nameChar = name.ToLower().ToCharArray();
            string numberstr = "";
            numberstr += (int)nameChar[0];
            numberstr += (int)nameChar[name.Length-1];
            numberstr += (int)nameChar[(name.Length) / 2];
            return Int32.Parse(numberstr);
        }
        public void LevelUp()
        {
            if (baseLevel<levelCap)
            {
                if (randomGrowth.Next(100) < baseHPGrowth) baseHP++;
                if (randomGrowth.Next(100) < baseStrengthGrowth && baseStrength<statCap) baseStrength++;
                if (randomGrowth.Next(100) < baseSkillGrowth && baseSkill < statCap) baseSkill++;
                if (randomGrowth.Next(100) < baseSpeedGrowth && baseSpeed < statCap) baseSpeed++;
                if (randomGrowth.Next(100) < baseDefenceGrowth && baseDefence < statCap) baseDefence++;
                if (randomGrowth.Next(100) < baseLuckGrowth && baseLuck < statCap) baseLuck++;
                baseLevel++;
            }
            
        }
        public string ShowGrowth()
        {
            return ($" HP: {baseHPGrowth}% \n Str: {baseStrengthGrowth}% \n Skl: {baseSkillGrowth}% \n Spd: {baseSpeedGrowth}% \n Def: {baseDefenceGrowth}% \n Luk: {baseLuckGrowth}% ");
        }
    }
}
