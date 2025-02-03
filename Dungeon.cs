using System.ComponentModel;

namespace TextRPG
{
    public enum DungeonLevel
    {
        [Description("쉬운 던전")]
        Easy,
        [Description("일반 던전")]
        Normal,
        [Description("어려운 던전")]
        Hard,
    }

    internal class Dungeon
    {
        public int Id { get; set; }
        public int RecommendDP;
        public DungeonLevel DungeonLevel;
        public long BaseRewardGold;

        private int _BaseUseMinHp = 20;
        private int _BaseUseMaxHp = 35;
        private int _FailurePer = 40;

        public Dungeon(int dp, DungeonLevel level, long gold)
        {
            RecommendDP = dp;
            DungeonLevel = level;
            BaseRewardGold = gold;
        }

        public string GetDungeonInfo()
        {
            return $"{TextPrintManager.GetDescription(DungeonLevel)}\t| 방어력 {RecommendDP} 이상 권장";
        }

        public void EntryDungeon(int currentDP, int currentAP)
        {
            if (currentDP < RecommendDP)
            {
                int rate = new Random().Next(1, 101);

                if (rate <= _FailurePer)
                {
                    Failure();
                }
                else
                {
                    Clear(currentDP, currentAP);
                }
            }
            else
            {
                Clear(currentDP, currentAP);
            }
        }

        private void Clear(int currentDP, int currentAP)
        {
            TextPrintManager.ColorWriteLine("★던전 클리어★", ConsoleColor.Green);
            Console.WriteLine($"축하합니다!!");
            Console.WriteLine($"{TextPrintManager.GetDescription(DungeonLevel)}을 클리어 하였습니다.");

            Console.WriteLine("\n[탐험결과]");

            int useHp = GetUseHp(currentDP);
            Console.WriteLine($"\n체력 {GameManager.State.Hp.CurrentHp} -> {GameManager.State.Hp.CurrentHp - useHp}");
            GameManager.State.Hp.DecreaseHp(useHp);

            int rewardGold = GetReceiveRewardGold(currentAP);
            Console.WriteLine($"\nGold {GameManager.State.Gold.CurrentGold} -> {GameManager.State.Gold.CurrentGold + rewardGold}");
            GameManager.State.Gold.IncreaseGold(rewardGold);
        }

        private int GetUseHp(int currentDP)
        {
            int addRangeAmount = RecommendDP - currentDP;

            int useMinHp = _BaseUseMinHp + addRangeAmount;
            int useMaxHp = _BaseUseMaxHp + addRangeAmount;

            return new Random().Next(useMinHp, useMaxHp + 1);
        }

        private int GetReceiveRewardGold(int currentAP)
        {
            int addRewardMinVaule = currentAP;
            int addRewardMaxVaule = currentAP * 2;

            float addRewardRate = new Random().Next(addRewardMinVaule, addRewardMaxVaule + 1) * 0.01f;

            return (int)(BaseRewardGold * addRewardRate);
        }

        private void Failure()
        {
            TextPrintManager.ColorWriteLine("던전 실패",ConsoleColor.DarkRed);
            Console.WriteLine($"체력이 반으로 감소합니다");
            Console.WriteLine("\n[탐험결과]");

            int currentHp = GameManager.State.Hp.CurrentHp;
            int decreaseHp = (int)(currentHp * 0.5f);

            Console.WriteLine($"\n체력 {currentHp} -> {decreaseHp}");
            GameManager.State.Hp.DecreaseHp(decreaseHp);
        }
    }
}
