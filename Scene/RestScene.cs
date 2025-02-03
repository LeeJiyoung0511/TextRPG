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
            Console.WriteLine($"{_RestPrice}G를 내면 체력을 회복할 수 있습니다. (보유골드 : {GameManager.Gold.Current}G)\n");
        }

        public override void InputNextAction()
        {
            Console.WriteLine("1. 휴식하기(。-ω-)zzz\n");
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                string inputNumber = Console.ReadLine();
                int actionNumber = int.Parse(inputNumber);

                if (actionNumber == 1)
                {
                    if (GameManager.Gold.IsDecreaseGold(_RestPrice))
                    {
                        GameManager.Gold.DecreaseGold(_RestPrice);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("휴식을 완료했습니다");
                        GameManager.Player.Hp.RecoverMaxHP();
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Gold가 부족합니다");
                        Console.ResetColor();
                    }

                    GameManager.DisplayScene(_nextScenes);
                    continue;
                }
                else
                {
                    _nextScenes[0].OnStart();
                    break;
                }
            }
        }
    }
}
