using System;

namespace TextRPG
{
    internal class Game
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {1,new StateScene(1) },
            {2,new InventoryScene(2) },
            {3,new ShopScene(3) }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다." +
                "\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            Initialize();
        }

        static public void Initialize()
        {
            GameManager.DisplayScene(_nextScenes);
            GameManager.SelectScene(_nextScenes);
        }
    }
}
