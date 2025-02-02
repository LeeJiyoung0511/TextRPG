using System.ComponentModel;

namespace TextRPG
{
    public enum Job
    {
        [Description("전사")]
        Warrior,
    }

    internal class State
    {
        public int Level;
        public string Name;
        public Job Job;
        public float AttackPower => baseAttackPower + AddAttackPower;
        public float baseAttackPower;
        public float AddAttackPower;
        public float DefensePower => baseDefensePower + AddDefensePower;
        public float baseDefensePower;
        public float AddDefensePower;

        public Hp Hp;

        public Gold Gold;

        public State()
        {
            Level = 1;
            Name = "플레이어";
            Job = Job.Warrior;
            baseAttackPower = 10;
            baseDefensePower = 5;
            AddAttackPower = 0;
            AddDefensePower = 0;
            Hp = new Hp(100);
            Gold = new Gold(1500);
        }
    }
}
