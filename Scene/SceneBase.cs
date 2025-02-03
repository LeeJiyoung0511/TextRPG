namespace TextRPG
{
    internal class SceneBase
    {

        public Dictionary<int, SceneBase> NextScenes = new Dictionary<int, SceneBase>();

        public int SceneNumber;
        public string SceneName;

        public SceneBase(int actionNumber)
        {
            SceneNumber = actionNumber;
            SceneName = "";
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

            TextPrintManager.ColorWriteLine($"\n【{sceneName}】",ConsoleColor.DarkYellow);
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
        public virtual void InputNextAction()
        {
            string inputSceneNumber = "";
            int sceneNumber = 0;

            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                inputSceneNumber = Console.ReadLine();
                sceneNumber = int.Parse(inputSceneNumber);

                if (!NextScenes.ContainsKey(sceneNumber))
                {
                    TextPrintManager.ColorWriteLine("\n잘못된 입력입니다.", ConsoleColor.DarkRed);
                    Display();
                    continue;
                }
                else
                {
                    NextScenes[sceneNumber].OnStart();
                    break;
                }
            }
        }
    }
}
