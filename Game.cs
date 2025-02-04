namespace TextRPG
{
    internal class Game
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {1,new StateScene(1) },
            {2,new InventoryScene(2) },
            {3,new ShopScene(3) },
            {4,new DungeonScene(4) },
            {5,new RestScene(5) }
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

            SceneBase scene = new SceneBase(0);
            scene.NextScenes = _nextScenes;
            scene.InputNextAction();
        }
    }
}
