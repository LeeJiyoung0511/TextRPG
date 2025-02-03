using TextRPG.Scene;

namespace TextRPG
{
    internal class RestScene : SceneBase
    {
        static readonly Dictionary<int, SceneBase> _nextScenes = new Dictionary<int, SceneBase>
        {
            {0,new ReturnScene(0) },
        };

        private long _RestPrice = 500;

        public RestScene(int number) : base(number)
        {
            SceneName = "휴식하기";
            NextScenes = _nextScenes;
        }

        public override void Display()
        {
            Console.WriteLine($"{_RestPrice}G를 내면 체력을 회복할 수 있습니다. (보유골드 : {GameData.Gold.Current}G)\n");
        }

        public override void InputNextAction()
        {
            Console.WriteLine("1. 휴식하기(。-ω-)zzz");

            while (true)
            {
                DisplayNextAction();
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                string inputNumber = Console.ReadLine();
                int actionNumber = int.Parse(inputNumber);

                if (_nextScenes.ContainsKey(actionNumber))
                {
                    _nextScenes[actionNumber].OnStart();
                    break;
                }

                if (actionNumber == 1)
                {
                    if (GameData.Gold.IsDecreaseGold(_RestPrice))
                    {
                        if (GameData.Player.Hp.Current == 100)
                        {
                            TextPrintManager.ColorWriteLine("\n풀피인데요? 500G 잘먹겠습니다!", ConsoleColor.Green);
                        }

                        GameData.Gold.DecreaseGold(_RestPrice);
                        TextPrintManager.ColorWriteLine("휴식을 완료했습니다.",ConsoleColor.Cyan);
                        GameData.Player.Hp.RecoverMaxHP();
                    }
                    else
                    {
                        TextPrintManager.ColorWriteLine("Gold가 부족합니다.",ConsoleColor.DarkRed);
                    }
                }
                continue;
            }
        }
    }
}
