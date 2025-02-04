namespace TextRPG
{
    internal class Dungeon : ActionBase
    {
        static readonly Dictionary<int, ActionBase> _nextActions = new Dictionary<int, ActionBase>
        {
            {0,new Return(0) },
        };

        public Dungeon(int number) : base(number)
        {
            ActionName = "던전입장";
            NextActions = _nextActions;
            OnInputInvalidActionNumber = EntryDungeon;
        }

        public override void Display()
        {
            Console.WriteLine("\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            DisplayDungeonList();
        }

        private void DisplayDungeonList()
        {
            for (int i = 0; i < DataManager.Instance.DungeonDatas.Count; i++)
            {
                DungeonData dungeon = DataManager.Instance.DungeonDatas[i + 1];
                Console.WriteLine($"\n{i + 1}.{dungeon.GetDungeonInfo()}");
            }
        }

        private void EntryDungeon(int number)
        {
            if (!GameData.IsCanEntryDungeon)
            {
                TextPrintManager.ColorWriteLine("이대로 가다간 기절해요! 회복하고 오세요!", ConsoleColor.DarkRed);
                return;
            }

            DungeonData selectedDungeon = DataManager.Instance.DungeonDatas[number];
            if (selectedDungeon == null)
            {
                TextPrintManager.ColorWriteLine("잘못된 입력입니다", ConsoleColor.DarkRed);
            }
            else
            {
                float currentAP = GameData.Player.Stat.AttackPower;
                float currentDP = GameData.Player.Stat.DefensePower;
                selectedDungeon.EntryDungeon(currentDP, currentAP);
            }
        }
    }
}
