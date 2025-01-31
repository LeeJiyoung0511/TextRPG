namespace TextRPG
{
    internal class StartScene
    {
        static Dictionary<int,Action> actions = new Dictionary<int,Action>();

        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다." +
                "\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            DisplayAction();
            SelectAction();
        }

        static public void DisplayAction()
        {
            actions.Add(1,new PlayerState(1));
            actions.Add(2,new Inventory(2));
            actions.Add(3,new Shop(3));

            foreach (var action in actions)
            {
                action.Value.PrintInfo();
            }
        }

        static private void SelectAction()
        {
            string inputActionNumber = "";
            int actionNumber = 0;

            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                inputActionNumber = Console.ReadLine();
                actionNumber = int.Parse(inputActionNumber);

                if (!actions.ContainsKey(actionNumber))
                {
                    Console.WriteLine("잘못된 입력입니다");
                    continue;
                }
                else
                {
                    if (actions.TryGetValue(actionNumber,out Action action))
                    {
                        action.Select();
                    }
                    break;
                }
            }
        }
    }
}
