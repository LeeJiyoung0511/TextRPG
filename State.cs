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

        public float Hp;
        public long Gold => _Gold;

        private long _Gold;

        public State()
        {
            Level = 1;
            Name = "플레이어";
            Job = Job.Warrior;
            baseAttackPower = 10;
            baseDefensePower = 5;
            AddAttackPower = 0;
            AddDefensePower = 0;
            Hp = 100;
            _Gold = 1500;
        }

        public void DecreaseGold(long gold)
        {
            if (IsDecreaseGold(gold))
            {
                _Gold -= gold;
                Console.WriteLine($"보유 골드는 {Gold}G 입니다\n");
            }
        }

        public bool IsDecreaseGold(long gold)
        {
            return _Gold - gold >= 0;
        }
    }
}
