using System;

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
            Initialize();
            Display();
        }

        static private void Initialize()
        {
            GameData.Player = new Player("플레이어",Job.Warrior,10,5);
            GameData.Gold = new Gold(1500);
        }

        static public void Display()
        {
            TextPrintManager.ColorWriteLine("【마을】", ConsoleColor.DarkYellow);

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다." +
                "\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            SceneBase scene = new SceneBase(0);
            scene.NextScenes = _nextScenes;

            scene.Display();
            scene.InputNextAction();
        }
    }
}
