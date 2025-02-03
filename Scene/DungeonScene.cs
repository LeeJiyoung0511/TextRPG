namespace TextRPG
{
    internal class DungeonScene : SceneBase
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {0,new ReturnScene(0) },
        };

        public DungeonScene(int number) : base(number)
        {
            SceneName = "던전입장";
            NextScenes = _nextScenes;
        }

        public override void Display()
        {
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            DisplayDungeonList();
        }

        private void DisplayDungeonList()
        {
            for (int i = 0; i < DataManager.DungeonDatas.Length; i++)
            {
                Dungeon dungeon = DataManager.DungeonDatas[i];
                dungeon.Id = i + 1;
                Console.WriteLine($"\n{i + 1}.{DataManager.DungeonDatas[i].GetDungeonInfo()}");
            }
        }

        public override void InputNextAction()
        {
            string inputNumber = "";
            int number = 0;

            Dungeon selectedDungeon;

            while (true)
            {
                GameManager.DisplayScene(_nextScenes);

                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                inputNumber = Console.ReadLine();
                number = int.Parse(inputNumber);

                if (_nextScenes.ContainsKey(number))
                {
                    _nextScenes[number].OnStart();
                    break;
                }

                selectedDungeon = DataManager.DungeonDatas.FirstOrDefault(x=>x.Id == number);
                if (selectedDungeon == null)
                {
                    TextPrintManager.ColorWriteLine("잘못된 입력입니다", ConsoleColor.DarkRed);
                }
                else
                {
                    int currentAP = GameManager.State.AttackPower;
                    int currentDP = GameManager.State.DefensePower;
                    selectedDungeon.EntryDungeon(currentDP,currentAP);
                }
                continue;
            }
        }
    }
}
