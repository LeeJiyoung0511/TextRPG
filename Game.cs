namespace TextRPG
{
    internal class Game
    {
        static readonly Dictionary<int, ActionBase> _nextScenes = new Dictionary<int, ActionBase>
        {
            {1,new State(1) },
            {2,new Inventory(2) },
            {3,new Shop(3) },
            {4,new Dungeon(4) },
            {5,new Rest(5) }
        };

        static void Main(string[] args)
        {
            //프로그램이 종료되는 시점에 저장
            AppDomain.CurrentDomain.ProcessExit += SaveData;

            //데이터 로드
            DataManager.Instance.Load();

            InputPlayerName();
            DisplayVillageMessage();
        }

        static void SaveData(object sender, EventArgs e)
        {
            DataManager.Instance.Save();
        }

        static public void InputPlayerName()
        {
            Console.WriteLine($"안녕하세요!!");
            Console.WriteLine($"용사님의 이름을 알려주세요");
            string name = Console.ReadLine();
            DataManager.Instance.Player.Name = name;
        }

        static public void DisplayVillageMessage()
        {
            TextPrintManager.ColorWriteLine("【마을】", ConsoleColor.DarkYellow);
            Console.WriteLine($"스파르타 마을에 오신 {DataManager.Instance.Player.Name}님 환영합니다." +
            "\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            ActionBase scene = new ActionBase(0);
            scene.NextActions = _nextScenes;
            scene.InputNextAction();
        }
    }
}
