namespace TextRPG
{
    internal class ActionBase
    {

        public Dictionary<int, ActionBase> NextActions = new Dictionary<int, ActionBase>();

        public int ActionNumber;
        public string ActionName;

        public Action<int> OnInputInvalidActionNumber = delegate { };

        public ActionBase(int actionNumber)
        {
            ActionNumber = actionNumber;
            ActionName = "";
            OnInputInvalidActionNumber = PrintErrorMessage;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"\n{ActionNumber}. {ActionName}");
        }

        public virtual void OnStart(string sceneName = "")
        {
            if (String.IsNullOrEmpty(sceneName))
            {
                sceneName = ActionName;
            }

            TextPrintManager.ColorWriteLine($"\n【{sceneName}】", ConsoleColor.DarkYellow);
            Display();
            InputNextAction();
        }

        //행동 표시
        public virtual void Display()
        {
            DisplayNextAction();
        }

        public void DisplayNextAction()
        {
            foreach (var action in NextActions)
            {
                action.Value.PrintInfo();
            }
        }

        //행동 선택
        public void InputNextAction()
        {
            while (true)
            {
                DisplayNextAction();
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out int sceneNumber))
                {
                    if (NextActions.ContainsKey(sceneNumber))
                    {
                        NextActions[sceneNumber].OnStart();
                        break;
                    }
                    OnInputInvalidActionNumber?.Invoke(sceneNumber);
                }
                else
                {
                    PrintErrorMessage(0);
                }
                continue;
            }
        }

        private void PrintErrorMessage(int number)
        {
            TextPrintManager.ColorWriteLine("\n잘못된 입력입니다.", ConsoleColor.DarkRed);
        }
    }
}
