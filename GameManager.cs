namespace TextRPG
{
    internal class GameManager
    {
        static public Player Player { get; set; }

        static public Gold Gold { get; set; }

        //행동 표시
        static public void DisplayScene(Dictionary<int, SceneBase> dic)
        {
            foreach (var action in dic)
            {
                action.Value.PrintInfo();
            }
        }

        //행동 선택
        static public void SelectScene(Dictionary<int, SceneBase> dic)
        {
            string inputSceneNumber = "";
            int sceneNumber = 0;

            while (true)
            {
                Console.Write("\n원하시는 행동을 입력해주세요.\n>>");
                inputSceneNumber = Console.ReadLine();
                sceneNumber = int.Parse(inputSceneNumber);

                if (!dic.ContainsKey(sceneNumber))
                {
                    TextPrintManager.ColorWriteLine("\n잘못된 입력입니다.", ConsoleColor.DarkRed);
                    DisplayScene(dic);
                    continue;
                }
                else
                {
                    dic[sceneNumber].OnStart();
                    break;
                }
            }
        }
    }
}
