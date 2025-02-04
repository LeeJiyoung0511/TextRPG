namespace TextRPG
{
    internal class SceneBase
    {

        public Dictionary<int, SceneBase> NextScenes = new Dictionary<int, SceneBase>();

        public int SceneNumber;
        public string SceneName;

        public Action<int> OnInputInvalidActionNumber = delegate { };

        public SceneBase(int actionNumber)
        {
            SceneNumber = actionNumber;
            SceneName = "";
            OnInputInvalidActionNumber = PrintErrorMessage;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"\n{SceneNumber}. {SceneName}");
        }

        public virtual void OnStart(string sceneName = "")
        {
            if (String.IsNullOrEmpty(sceneName))
            {
                sceneName = SceneName;
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
            foreach (var action in NextScenes)
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
                    if (NextScenes.ContainsKey(sceneNumber))
                    {
                        NextScenes[sceneNumber].OnStart();
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
