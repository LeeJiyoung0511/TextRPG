using Newtonsoft.Json;
using System.ComponentModel;

namespace TextRPG
{
    public enum Job
    {
        [Description("전사")]
        Warrior,
    }

    internal class Player
    {
        [JsonIgnore]
        public int Level => _Level;

        public string Name { get; set; }

        public Job Job { get; set; }

        public Stat Stat { get; set; }

        public Hp Hp { get; set; }

        private int _DefaultHp = 100;

        [JsonProperty]
        private int _Level = 1;

        public Player(string name, Job job, float aP, float dP)
        {
            Name = name;
            Job = job;
            Stat = new Stat(aP,dP);
            Hp = new Hp(_DefaultHp);
        }

        public void LevelUp()
        {
            _Level++;
            Stat.baseAttackPower += 0.5f;
            Stat.baseDefensePower += 1;
            TextPrintManager.ColorWriteLine("\n레벨업 했습니다.",ConsoleColor.Cyan);
            Console.WriteLine($"현재 레벨은 Lv.{_Level}입니다");
        }
    }
}
